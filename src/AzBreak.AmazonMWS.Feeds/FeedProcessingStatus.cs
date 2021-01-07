using AzBreak.AmazonMWS.Core;

namespace AzBreak.AmazonMWS.Feeds
{
    /// <summary>
    /// The FeedProcessingStatus enumeration describes the processing status of a submitted feed.
    /// </summary>
    public class FeedProcessingStatus : AmazonMWSEnumeration
    {
        public static implicit operator FeedProcessingStatus(string value) => new FeedProcessingStatus { Value = value };

        /// <summary>
        /// The request is being processed, but is waiting for external information before it can complete.
        /// </summary>
        public const string AwaitingAsynchronousReply = "_AWAITING_ASYNCHRONOUS_REPLY_";
        /// <summary>
        /// The request has been aborted due to a fatal error.
        /// </summary>
        public const string Cancelled = "_CANCELLED_";
        /// <summary>
        /// The request has been processed. You can call the GetFeedSubmissionResult operation to receive a processing report that describes which records in the feed were successful and which records generated errors.
        /// </summary>
        public const string Done = "_DONE_";
        /// <summary>
        /// The request is being processed.
        /// </summary>
        public const string InProgress = "_IN_PROGRESS_";
        /// <summary>
        /// The request is being processed, but the system has determined that there is a potential error with the feed (for example, the request will remove all inventory from a seller's account.) An Amazon seller support associate will contact the seller to confirm whether the feed should be processed.
        /// </summary>
        public const string InSafetyNet = "_IN_SAFETY_NET_";
        /// <summary>
        /// The request has been received, but has not yet started processing.
        /// </summary>
        public const string Submitted = "_SUBMITTED_";
        /// <summary>
        /// The request is pending.
        /// </summary>
        public const string Unconfirmed = "_UNCONFIRMED_";    
    }
}