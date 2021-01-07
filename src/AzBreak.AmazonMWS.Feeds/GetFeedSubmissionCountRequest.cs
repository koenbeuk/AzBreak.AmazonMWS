using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AzBreak.AmazonMWS.Core.Internal;

namespace AzBreak.AmazonMWS.Feeds
{
    public class GetFeedSubmissionCountRequest
    {
        /// <summary>
        /// A structured list of one or more FeedType values by which to filter the list of feed submissions.	
        /// </summary>
        public IEnumerable<FeedType> FeedTypes { get; set; }

        /// <summary>
        /// A structured list of one or more feed processing statuses by which to filter the list of feed submissions.	
        /// </summary>
        public IEnumerable<FeedProcessingStatus> FeedProcessingStatuses { get; set; }

        /// <summary>
        /// The earliest submission date that you are looking for, in ISO8601 date format.	
        /// </summary>
        public DateTimeOffset? SubmittedFromDate { get; set; }

        /// <summary>
        /// The latest submission date that you are looking for, in ISO8601 date format.
        /// </summary>
        public DateTimeOffset? SubmittedToDate { get; set; }

        internal IDictionary<string, object> ToParametersDictionary()
            => new ParameterDictionaryBuilder()
                .Add("FeedProcessingStatusList.Status", FeedProcessingStatuses)
                .Add("FeedTypeList.Type", FeedTypes)
                .Add("SubmittedFromDate", SubmittedFromDate)
                .Add("SubmittedToDate", SubmittedToDate)
                .Parameters;
    }
}
