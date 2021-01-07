using AzBreak.AmazonMWS.Core.Internal;
using System.Collections.Generic;

namespace AzBreak.AmazonMWS.Reports
{
    public class UpdateReportAcknowledgementsRequest
    {
        /// <summary>
        /// A structured list of Report Ids. The maximum number of reports that can be specified is 100
        /// </summary>
        public IEnumerable<string> ReportIds { get; set; }

        /// <summary>
        /// A Boolean value that indicates that you have received and stored a report. Specify true to set the acknowledged status of a report to true. Specify false to set the acknowledged status of a report to false.	
        /// </summary>
        public bool? Acknowledged { get; set; }

        internal IDictionary<string, object> ToParametersDictionary()
            => new ParameterDictionaryBuilder()
                .Add("ReportIdList.Id", ReportIds)
                .Add("Acknowledged", Acknowledged)
                .Parameters;
    }
}