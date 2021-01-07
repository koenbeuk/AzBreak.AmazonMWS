using System.Collections.Generic;
using System.Xml.Serialization;

namespace AzBreak.AmazonMWS.Reports
{
    public class CancelReportRequestsResult
    {
        /// <summary>
        /// A non-negative integer that represents the total number of report requests that were canceled.
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// Detailed information about a report request that was canceled.
        /// </summary>
        [XmlElement(nameof(ReportRequestInfo))]
        public List<ReportRequestInfo> ReportRequestInformations { get; set; }
    }
}