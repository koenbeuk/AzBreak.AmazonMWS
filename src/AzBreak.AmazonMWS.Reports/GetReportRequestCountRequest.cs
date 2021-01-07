using AzBreak.AmazonMWS.Core.Internal;
using System;
using System.Collections.Generic;

namespace AzBreak.AmazonMWS.Reports
{
    public class GetReportRequestCountRequest
    {
        /// <summary>
        /// A structured list of ReportType enumeration values.	
        /// </summary>
        public IEnumerable<ReportType> ReportTypes { get; set; }

        /// <summary>
        /// A structured list of report processing statuses by which to filter report requests.	
        /// </summary>
        public IEnumerable<ReportProcessingStatus> ReportProcessingStatuses { get; set; }


        /// <summary>
        /// The start of the date range used for selecting the data to report
        /// </summary>
        /// <remarks>
        /// Default: 90 days
        /// </remarks>
        public DateTimeOffset? RequestedFromDate { get; set; }

        /// <summary>
        /// The end of the date range used for selecting the data to report
        /// </summary>
        /// <remarks>
        /// Default: now
        /// </remarks>
        public DateTimeOffset? RequestedToDate { get; set; }

        internal IDictionary<string, object> ToParametersDictionary()
            => new ParameterDictionaryBuilder()
                .Add("ReportTypeList.Type", ReportTypes)
                .Add("ReportProcessingStatusList.Status", ReportProcessingStatuses)
                .Add("RequestedFromDate", RequestedFromDate)
                .Add("RequestedToDate", RequestedToDate)
                .Parameters;
    }
}