using AzBreak.AmazonMWS.Core.Internal;
using System;
using System.Collections.Generic;

namespace AzBreak.AmazonMWS.Reports
{
    public class ManageReportScheduleRequest
    {
        /// <summary>
        /// A value of the ReportType that indicates the type of report to request.	
        /// </summary>
        public ReportType ReportType { get; set; }

        /// <summary>
        /// A value of the Schedule that indicates how often a report request should be created.
        /// </summary>
        /// <remarks>
        /// Default: None
        /// </remarks>
        public Schedule Schedule { get; set; }

        /// <summary>
        /// The date when the next report request is scheduled to be submitted.	
        /// </summary>
        /// <remarks>
        /// Default: Now
        /// Value can be no more than 366 days in the future.
        /// </remarks>
        public DateTimeOffset? ScheduleDate { get; set; }

        internal IDictionary<string, object> ToParametersDictionary()
            => new ParameterDictionaryBuilder()
                .Add("ReportType", ReportType)
                .Add("Schedule", Schedule)
                .Add("ScheduleDate", ScheduleDate)
                .Parameters;
    }
}