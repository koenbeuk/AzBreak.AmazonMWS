using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using AzBreak.AmazonMWS.Core.Internal;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using AzBreak.AmazonMWS.Core.RetryPolicies;

namespace AzBreak.AmazonMWS.Core
{
    public sealed class AmazonMWSChannel : IAmazonMWSChannel
    {
        /// <summary>
        ///  shared http client for all instances
        /// </summary>
        static readonly HttpClient httpClient = new HttpClient();

        const string mwsTimestampHeaderName = "x-mws-timestamp";
        const string mwsQuotaMaxHeaderName = "x-mws-quota-max";
        const string mwsQuotaRemainingHeaderName = "x-mws-quota-remaining";
        const string mwsQuotaResetsOnHeaderName = "x-mws-quota-resetsOn";

        readonly IOptionsSnapshot<AmazonMWSClientOptions> options;
        readonly ILogger<AmazonMWSChannel> logger;
        readonly IExecutionRetryPolicy executionRetryPolicy;

        ResponseQuota ParseQuota(HttpResponseMessage responseMessage, DateTimeOffset serverDate)
        {
            var quotaMax = responseMessage.Headers.GetSingleHeaderValueAsInt(mwsQuotaMaxHeaderName);
            var quotaRemaining = responseMessage.Headers.GetSingleHeaderValueAsInt(mwsQuotaRemainingHeaderName);
            var quotaResetsOn = responseMessage.Headers.GetSingleHeaderValueAsDateTime(mwsQuotaResetsOnHeaderName);

            if (quotaMax != null && quotaRemaining != null)
            {
                return new ResponseQuota
                {
                    Max = quotaMax.Value,
                    Remaining = quotaRemaining.Value,
                    ResetsOn = quotaResetsOn.Value,
                    ServerDate = serverDate
                };
            }
            else
            {
                return null;
            }
        }

        public AmazonMWSChannel(IOptionsSnapshot<AmazonMWSClientOptions> options, ILogger<AmazonMWSChannel> logger, IExecutionRetryPolicy executionRetryPolicy)
        {
            this.options = options ?? throw new ArgumentNullException(nameof(options));
            this.executionRetryPolicy = executionRetryPolicy ?? throw new ArgumentNullException(nameof(executionRetryPolicy));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public AmazonMWSClientOptions Options => options.Value;

        public Task<Response<TResult>> Execute<TResult>(Request request, CancellationToken cancellationToken) => ExecuteWithRetryPolicy(request, cancellationToken, ExecuteInternal<TResult>);

        public Task<StreamedResponse> Execute(Request request, CancellationToken cancellationToken) => ExecuteWithRetryPolicy(request, cancellationToken, ExecuteInternal);

        async Task<TResponse> ExecuteWithRetryPolicy<TResponse>(Request request, CancellationToken cancellationToken, Func<Request, CancellationToken, Task<TResponse>> invoke)
            where TResponse : Response => await this.executionRetryPolicy.Execute<TResponse>(request, cancellationToken, invoke);

        private async Task<Response<TResult>> ExecuteInternal<TResult>(Request request, CancellationToken cancellationToken)
        {
            var responseMessage = await ExecuteRequest(request, cancellationToken);

            var response = new Response<TResult>()
            {
                StatusCode = responseMessage.StatusCode,
                Timestamp = responseMessage.Headers.GetSingleHeaderValueAsDateTime(mwsTimestampHeaderName) ?? DateTimeOffset.UtcNow
            };
            response.Quota = ParseQuota(responseMessage, response.Timestamp);

            if (response.Success)
            {

                await ReadXmlContent(responseMessage, response);
            }
            else
            {
                await ReadError(responseMessage, response);
            }

            return response;
        }

        private async Task<StreamedResponse> ExecuteInternal(Request request, CancellationToken cancellationToken)
        {
            var responseMessage = await ExecuteRequest(request, cancellationToken);
            var response = new StreamedResponse(async () =>
            {
                var contentStream = await responseMessage.Content.ReadAsStreamAsync();

                // if there is a content-hash header value, we'll have to verify the returned stream with that hash 
                var expectedHash = responseMessage.Content.Headers.ContentMD5;
                if (expectedHash != null)
                {
                    return new MD5VerifiedStream(contentStream, expectedHash);
                }
                else
                {
                    return contentStream;
                }
            }, responseMessage.Content.Headers.ContentLength)
            {
                StatusCode = responseMessage.StatusCode,
                Timestamp = responseMessage.Headers.GetSingleHeaderValueAsDateTime(mwsTimestampHeaderName) ?? DateTimeOffset.UtcNow
            };

            response.Quota = ParseQuota(responseMessage, response.Timestamp);

            if (!response.Success)
            {
                await ReadError(responseMessage, response);
            }

            return response;
        }

        async Task<HttpResponseMessage> ExecuteRequest(Request request, CancellationToken cancellationToken)
        {
            var options = request.ClientOptions ?? this.options.Value;
            options.EnsureValid();

            var requestBuilder = new AmazonMWSV2RequestUrlBuilder(SignatureMethod.HmacSHA256);
            var requestUri = requestBuilder.CreateRequestUri(request, options);

            var requestMessage = new HttpRequestMessage(HttpMethod.Post, requestUri);
            requestMessage.Headers.UserAgent.TryParseAdd(options.UserAgent);

            if (request.Body != null)
            {
                await AppendBody(requestMessage, request.Body, cancellationToken);
            }

            var responseMessage = await httpClient.SendAsync(requestMessage, HttpCompletionOption.ResponseHeadersRead, cancellationToken);
            return responseMessage;
        }

        async Task AppendBody(HttpRequestMessage requestMessage, Stream body, CancellationToken cancellationToken)
        {
            if (!body.CanSeek)
            {
                // we need to compute the ContentHash for this body meaning that we need to have seekable version, hence copy to a memory stream first
                var memoryStream = new MemoryStream();
                await body.CopyToAsync(memoryStream, 81920, cancellationToken);
                memoryStream.Position = 0;
                body = memoryStream;
            }

            var bodyStartPosition = body.Position;
            var contentHashBytes = await ContentHashHelper.ComputeMD5HashBytes(body, cancellationToken);
            body.Position = bodyStartPosition;

            requestMessage.Content = new StreamContent(body);
            requestMessage.Content.Headers.ContentMD5 = contentHashBytes;
        }

        async Task ReadXmlContent<TResult>(HttpResponseMessage httpResponseMessage, Response<TResult> response)
        {
            using (var contentStream = await httpResponseMessage.Content.ReadAsStreamAsync())
            using (var xmlReader = XmlReader.Create(contentStream, new XmlReaderSettings { Async = true }))
            {
                // move to the root node
                await xmlReader.MoveToContentAsync();
                response.ResponseType = xmlReader.Name;
                response.DefaultNamespace = xmlReader.NamespaceURI;

                while (await xmlReader.ReadAsync())
                {
                    if (xmlReader.IsStartElement())
                    {
                        switch (xmlReader.Name)
                        {
                            case nameof(ResponseMetadata):
                                response.Metadata = DeserializeAs<ResponseMetadata>(xmlReader, response.DefaultNamespace);
                                break;
                            default:
                                response.Result = DeserializeAs<TResult>(xmlReader, response.DefaultNamespace);
                                break;
                        }
                    }
                }
            }
        }

        async Task ReadError(HttpResponseMessage httpResponseMessage, Response response)
        {
            using (var contentStream = await httpResponseMessage.Content.ReadAsStreamAsync())
            using (var xmlReader = XmlReader.Create(contentStream, new XmlReaderSettings { Async = true }))
            {
                // move to the root node
                await xmlReader.MoveToContentAsync();
                var defaultNamespace = xmlReader.NamespaceURI;

                while (await xmlReader.ReadAsync())
                {
                    if (xmlReader.IsStartElement())
                    {
                        switch (xmlReader.Name)
                        {
                            case "RequestID":
                            case "RequestId":
                                response.Metadata = new ResponseMetadata { RequestId = await xmlReader.ReadElementContentAsStringAsync() };
                                break;
                            default:
                                response.Error = DeserializeAs<ErrorResult>(xmlReader, defaultNamespace);
                                break;
                        }
                    }
                }
            }
        }

        static TModel DeserializeAs<TModel>(XmlReader reader, string defaultNamespace)
        {
            var serializer = new XmlSerializer(typeof(TModel), defaultNamespace);
            return (TModel)serializer.Deserialize(reader);
        }
    }
}
