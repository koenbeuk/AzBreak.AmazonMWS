using AzBreak.AmazonMWS.Core.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzBreak.AmazonMWS.Feeds
{
    public class CancelFeedSubmissionsRequest
    {
        /// <summary>
        /// A structured list of FeedSubmmissionId values. If you pass in FeedSubmmissionId values in a request, other query conditions are ignored.	
        /// </summary>
        public IEnumerable<string> FeedSubmissionIds { get; set; }

        /// <summary>
        /// A structured list of one or more FeedType values by which to filter the list of feed submissions.	
        /// </summary>
        public IEnumerable<FeedType> FeedTypes { get; set; }

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
                .Add("FeedSubmissionIdList.Id", FeedSubmissionIds)
                .Add("FeedTypeList.Type", FeedTypes)
                .Add("SubmittedFromDate", SubmittedFromDate)
                .Add("SubmittedToDate", SubmittedToDate)
                .Parameters;
    }
}
