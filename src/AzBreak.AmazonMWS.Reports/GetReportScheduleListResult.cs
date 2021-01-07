using System.Collections.Generic;
using System.Xml.Serialization;

namespace AzBreak.AmazonMWS.Reports
{
    public class GetReportScheduleListResult
    {
        /// <summary>
        /// This element will never be returned for this operation because there can never be more than 100 report types scheduled.
        /// </summary>
        public string NextToken { get; set; }

        /// <summary>
        /// A Boolean value that is always returned false because there can never be more than 100 report types scheduled.
        /// </summary>
        public bool HasNext { get; set; }

        /// <summary>
        /// Detailed information about a report schedule.
        /// </summary>
        [XmlElement(nameof(ReportSchedule))]
        public List<ReportSchedule> ReportSchedules { get; set; }
    }
}