using AzBreak.AmazonMWS.Core.Internal;
using System;
using System.Collections.Generic;

namespace AzBreak.AmazonMWS.Reports
{
    public class GetReportCountRequest
    {
        /// <summary>
        /// A Boolean value that indicates if an order report has been acknowledged by a prior call to UpdateReportAcknowledgements. Set to true to list order reports that have been acknowledged; set to false to list order reports that have not been acknowledged. This filter is valid only with order reports; it does not work with listing reports.	
        /// </summary>
        public bool? Acknowledged { get; set; }

        /// <summary>
        /// A structured list of ReportType enumeration values.	
        /// </summary>
        public IEnumerable<ReportType> ReportTypes { get; set; }

        /// <summary>
        /// The start of the date range used for selecting the data to report
        /// </summary>
        /// <remarks>
        /// Default: 90 days
        /// </remarks>
        public DateTimeOffset? AvailableFromDate { get; set; }

        /// <summary>
        /// The end of the date range used for selecting the data to report
        /// </summary>
        /// <remarks>
        /// Default: now
        /// </remarks>
        public DateTimeOffset? AvailableToDate { get; set; }

        internal IDictionary<string, object> ToParametersDictionary()
            => new ParameterDictionaryBuilder()
                .Add("Acknowledged", Acknowledged)
                .Add("ReportTypeList.Type", ReportTypes)
                .Add("AvailableFromDate", AvailableFromDate)
                .Add("AvailableToDate", AvailableToDate)
                .Parameters;
    }
}