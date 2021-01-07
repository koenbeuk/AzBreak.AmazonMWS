using System.IO;
using System.Threading;
using System.Threading.Tasks;
using AzBreak.AmazonMWS.Core;

namespace AzBreak.AmazonMWS.Feeds
{
    public interface IAmazonMWSFeedsClient
    {
        /// <summary>
        /// Uploads a feed for processing by Amazon MWS.
        /// </summary>
        /// <remarks>
        /// The SubmitFeed operation uploads a file and any necessary metadata for processing. Note that you must calculate a Content-MD5 value for the submitted file. For more information about creating a Content-MD5 value, see Using the Content-MD5 hash with the SubmitFeed and GetFeedSubmissionResult operations.
        /// Feed size is limited to 2 GB (231-1, or 2,147,483,647 bytes) per feed. If you have a large amount of data to submit, you should submit feeds smaller than the feed size limit by breaking up the data, or submit the feeds over a period of time. For optimal performance, a good practice is to submit feeds with a size limit of 30,000 records/items, or submit feeds over a period of time, such as every few hours.
        /// </remarks>
        Task<Response<SubmitFeedResult>> SubmitFeed(SubmitFeedRequest request, Stream feedContent, AmazonMWSClientOptions clientOptions = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Returns a list of all feed submissions submitted in the previous 90 days.
        /// </summary>
        /// <remarks>
        /// The GetFeedSubmissionList operation returns a list of feed submissions submitted in the previous 90 days that match the query parameters. Use this operation to determine the status of a feed submission by passing in the FeedProcessingId that was returned by the SubmitFeed operation.
        /// The GetFeedSubmissionList request can return a maximum of 100 results.If there are additional results to return, HasNext is returned in the response with a true value.To retrieve all the results, you can pass the value of the NextToken parameter to the GetFeedSubmissionListByNextToken operation and repeat until HasNext is false.
        /// </remarks>
        Task<Response<GetFeedSubmissionListResult>> GetFeedSubmissionList(GetFeedSubmissionListRequest request, AmazonMWSClientOptions clientOptions = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Returns a list of feed submissions using the NextToken parameter.
        /// </summary>
        /// <remarks>
        /// The GetFeedSubmissionListByNextToken operation returns a list of feed submissions that match the query parameters. It uses the NextToken, which was supplied in a previous request to either the GetFeedSubmissionListByNextToken operation or the GetFeedSubmissionList operation where the value of HasNext was true.
        /// </remarks>
        Task<Response<GetFeedSubmissionListResult>> GetFeedSubmissionListByNextToken(string nextToken, AmazonMWSClientOptions clientOptions = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Returns a count of the feeds submitted in the previous 90 days.
        /// </summary>
        Task<Response<GetFeedSubmissionCountResult>> GetFeedSubmissionCount(GetFeedSubmissionCountRequest request, AmazonMWSClientOptions clientOptions = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Returns the feed processing report and the Content-MD5 header.
        /// </summary>
        /// <remarks>
        /// The GetFeedSubmissionResult operation returns the feed processing report and the Content-MD5 header for the returned HTTP body.
        /// You should compute the MD5 hash of the HTTP body of the report that Amazon MWS returned to you, and compare that with the Content-MD5 header value that is returned.If the computed hash value and the returned hash value do not match, the report body was corrupted during transmission.You should discard the result and automatically retry the request for up to three more times.Please notify Amazon MWS if you receive a corrupted report body. For more information on the Content-MD5 header, see Using the Content-MD5 hash with the SubmitFeed and GetFeedSubmissionResult operations.
        /// </remarks>
        Task<StreamedResponse> GetFeedSubmissionResult(string feedSubmissionId, AmazonMWSClientOptions clientOptions = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Cancels one or more feed submissions and returns a count of the feed submissions that were canceled.
        /// </summary>
        /// <remarks>
        /// The CancelFeedSubmissions operation cancels one or more feed submissions and returns a count of the canceled feed submissions and the feed submission information. Note that if you do not specify a FeedSubmmissionId, all feed submissions are canceled.
        /// Information is returned for the first 100 feed submissions in the list. To return information for more than 100 canceled feed submissions, use the GetFeedSubmissionList operation.
        /// If a feed has begun processing, it cannot be canceled.
        /// </remarks>
        Task<Response<CancelFeedSubmissionsResult>> CancelFeedSubmissions(CancelFeedSubmissionsRequest request, AmazonMWSClientOptions clientOptions = null, CancellationToken cancellationToken = default);
    }
}