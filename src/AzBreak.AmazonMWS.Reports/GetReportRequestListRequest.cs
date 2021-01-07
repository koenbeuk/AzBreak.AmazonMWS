using AzBreak.AmazonMWS.Core.Internal;
using System;
using System.Collections.Generic;

namespace AzBreak.AmazonMWS.Reports
{
    public class GetReportRequestListRequest
    {
        /// <summary>
        /// A structured list of ReportRequestId values. If you pass in ReportRequestId values, other query conditions are ignored.	
        /// </summary>
        public IEnumerable<string> ReportRequestIds { get; set; }

        /// <summary>
        /// A structured list of ReportType enumeration values.	
        /// </summary>
        public IEnumerable<ReportType> ReportTypes { get; set; }

        /// <summary>
        /// A structured list of report processing statuses by which to filter report requests.	
        /// </summary>
        public IEnumerable<ReportProcessingStatus> ReportProcessingStatuses { get; set; }

        /// <summary>
        /// A non-negative integer that represents the maximum number of report requests to return. If you specify a number greater than 100, the request is rejected.	
        /// </summary>
        public int? MaxCount { get; set; }

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
                .Add("ReportRequestIdList.Id", ReportRequestIds)
                .Add("ReportTypeList.Type", ReportTypes)
                .Add("ReportProcessingStatusList.Status", ReportProcessingStatuses)
                .Add("MaxCount", MaxCount)
                .Add("RequestedFromDate", RequestedFromDate)
                .Add("RequestedToDate", RequestedToDate)
                .Parameters;
    }
}