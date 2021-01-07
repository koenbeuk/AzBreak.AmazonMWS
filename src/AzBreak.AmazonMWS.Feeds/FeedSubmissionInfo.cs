using AzBreak.AmazonMWS.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzBreak.AmazonMWS.Feeds
{
    public class FeedSubmissionInfo
    {
        /// <summary>
        /// A unique identifier for the feed submission.
        /// </summary>
        public string FeedSubmissionId { get; set; }

        /// <summary>
        /// The type of feed submitted. This is the FeedType value that was provided to the SubmitFeed operation.
        /// </summary>
        public FeedType FeedType { get; set; }

        /// <summary>
        /// The date and time when the feed was submitted.
        /// </summary>
        public AmazonMWSDateTime SubmittedDate { get; set; }

        /// <summary>
        /// The processing status of the feed submission. For more information, see FeedProcessingStatus enumeration.
        /// </summary>
        public FeedProcessingStatus FeedProcessingStatus { get; set; }

        /// <summary>
        /// The date when the feed processing started.
        /// </summary>
        public AmazonMWSDateTime StartedProcessingDate { get; set; }

        /// <summary>
        /// The date when the feed processing completed.
        /// </summary>
        public AmazonMWSDateTime CompletedProcessingDate { get; set; }
    }
}
