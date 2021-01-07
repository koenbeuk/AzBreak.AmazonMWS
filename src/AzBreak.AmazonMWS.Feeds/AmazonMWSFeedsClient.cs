using AzBreak.AmazonMWS.Core;
using AzBreak.AmazonMWS.Core.Internal;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AzBreak.AmazonMWS.Feeds
{
    public class AmazonMWSFeedsClient : IAmazonMWSFeedsClient
    {
        const string resourceName = "Feeds";
        const string version = "2009-01-01";

        readonly IAmazonMWSChannel channel;

        public AmazonMWSFeedsClient(IAmazonMWSChannel channel)
        {
            this.channel = channel ?? throw new ArgumentNullException(nameof(channel));
        }
        
        public Task<Response<SubmitFeedResult>> SubmitFeed(SubmitFeedRequest request, Stream feedContent, AmazonMWSClientOptions clientOptions, CancellationToken cancellationToken)
            => channel.Execute<SubmitFeedResult>(new Request { Resource = resourceName, Version = version, Action = "SubmitFeed", Parameters = request.ToParametersDictionary(), Body = feedContent, ClientOptions = clientOptions }, cancellationToken);

        public Task<Response<GetFeedSubmissionListResult>> GetFeedSubmissionList(GetFeedSubmissionListRequest request, AmazonMWSClientOptions clientOptions, CancellationToken cancellationToken)
            => channel.Execute<GetFeedSubmissionListResult>(new Request { Resource = resourceName, Version = version, Action = "GetFeedSubmissionList", Parameters = request.ToParametersDictionary(), ClientOptions = clientOptions }, cancellationToken);

        public Task<Response<GetFeedSubmissionListResult>> GetFeedSubmissionListByNextToken(string nextToken, AmazonMWSClientOptions clientOptions, CancellationToken cancellationToken)
            => channel.Execute<GetFeedSubmissionListResult>(new Request { Resource = resourceName, Version = version, Action = "GetFeedSubmissionListByNextToken", Parameters = new ParameterDictionaryBuilder().Add("NextToken", nextToken).Parameters, ClientOptions = clientOptions }, cancellationToken);

        public Task<Response<GetFeedSubmissionCountResult>> GetFeedSubmissionCount(GetFeedSubmissionCountRequest request, AmazonMWSClientOptions clientOptions, CancellationToken cancellationToken)
            => channel.Execute<GetFeedSubmissionCountResult>(new Request { Resource = resourceName, Version = version, Action = "GetFeedSubmissionCount", Parameters = request.ToParametersDictionary(), ClientOptions = clientOptions }, cancellationToken);

        public Task<StreamedResponse> GetFeedSubmissionResult(string feedSubmissionId, AmazonMWSClientOptions clientOptions, CancellationToken cancellationToken)
            => channel.Execute(new Request { Resource = resourceName, Version = version, Action = "GetFeedSubmissionResult", Parameters = new ParameterDictionaryBuilder().Add("FeedSubmissionId", feedSubmissionId).Parameters, ClientOptions = clientOptions }, cancellationToken);

        public Task<Response<CancelFeedSubmissionsResult>> CancelFeedSubmissions(CancelFeedSubmissionsRequest request, AmazonMWSClientOptions clientOptions, CancellationToken cancellationToken)
            => channel.Execute<CancelFeedSubmissionsResult>(new Request { Resource = resourceName, Version = version, Action = "GetFeedSubmissionCount", Parameters = request.ToParametersDictionary(), ClientOptions = clientOptions }, cancellationToken);
    }
}
