using AzBreak.AmazonMWS.Core;
using AzBreak.AmazonMWS.Core.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzBreak.AmazonMWS.Feeds
{
    public class GetFeedSubmissionListRequest
    {
        /// <summary>
        /// A structured list of no more than 100 FeedSubmmissionId values. If you pass in FeedSubmmissionId values in a request, other query conditions are ignored.	
        /// </summary>
        public IEnumerable<string> FeedSubmissionIds { get; set; }

        /// <summary>
        /// A non-negative integer that indicates the maximum number of feed submissions to return in the list. If you specify a number greater than 100, the request is rejected.	
        /// </summary>
        public int? MaxCount { get; set; }

        /// <summary>
        /// A structured list of one or more FeedType values by which to filter the list of feed submissions.	
        /// </summary>
        public IEnumerable<FeedType> FeedTypes { get; set; }

        /// <summary>
        /// A structured list of one or more feed processing statuses by which to filter the list of feed submissions.	
        /// </summary>
        public IEnumerable<FeedProcessingStatus> FeedProcessingStatuses { get; set; }

        /// <summary>
        /// The earliest submission date that you are looking for
        /// </summary>
        public AmazonMWSDateTime SubmittedFromDate { get; set; }

        /// <summary>
        /// The latest submission date that you are looking for
        /// </summary>
        public AmazonMWSDateTime SubmittedToDate { get; set; }

        internal IDictionary<string, object> ToParametersDictionary()
            => new ParameterDictionaryBuilder()
                .Add("FeedSubmissionIdList.Id", FeedProcessingStatuses)
                .Add("MaxCount", MaxCount)
                .Add("FeedTypeList.Type", FeedTypes)
                .Add("FeedProcessingStatusList.Status", FeedProcessingStatuses)
                .Add("SubmittedFromDate", SubmittedFromDate)
                .Add("SubmittedToDate", SubmittedToDate)
                .Parameters;
    }
}
