using AzBreak.AmazonMWS.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;

namespace AzBreak.AmazonMWS.TestSuite
{
    public class AmazonMWSChannelStub : IAmazonMWSChannel
    {
        object configuredResult;

        public AmazonMWSClientOptions Options => new AmazonMWSClientOptions();

        public AmazonMWSChannelStub RespondWithError(ErrorCode? code = null, string type = null, string message = null)
            => RespondWith(new ErrorResult { Code = code.GetValueOrDefault(), Type = type, Message = message });

        public AmazonMWSChannelStub RespondWith(object result)
        {
            configuredResult = result;
            return this;
        }

        public Task<Response<TResult>> Execute<TResult>(Request request, CancellationToken cancellationToken = default)
        {
            var response = new Response<TResult>();
            if (configuredResult is ErrorResult errorResult)
            {
                response.Error = errorResult;
                response.StatusCode = System.Net.HttpStatusCode.OK;
            }
            else if (configuredResult is TResult result)
            {
                response.Result = result;
                response.StatusCode = System.Net.HttpStatusCode.InternalServerError;
            }
            else
            {
                throw new InvalidOperationException("No expected result configured");
            }


            return Task.FromResult(response);
        }

        public Task<StreamedResponse> Execute(Request request, CancellationToken cancellationToken = default)
        {
            if (configuredResult is Stream stream)
            {
                var expectedLength = stream.CanSeek ? (long?)stream.Length : null;
                var response = new StreamedResponse(() => Task.FromResult(stream), expectedLength)
                {
                    StatusCode = System.Net.HttpStatusCode.OK
                };
                return Task.FromResult(response);
            }
            else
            {
                throw new InvalidOperationException("No expected stream configured");
            }

        }
    }
}
