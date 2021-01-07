using System;

namespace AzBreak.AmazonMWS.Reports
{
    public class ManageReportScheduleResult
    {
        /// <summary>
        /// A non-negative integer that represents the total number of report requests.
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// Detailed information about a report schedule.
        /// </summary>
        public ReportSchedule ReportSchedule { get; set; }
    }
}