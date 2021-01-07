using System.Collections.Generic;
using System.Xml.Serialization;

namespace AzBreak.AmazonMWS.Reports
{
    public class UpdateReportAcknowledgementsResult
    {
        /// <summary>
        /// A non-negative integer that represents the total number of report requests.
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// Detailed information about each report.
        /// </summary>
        [XmlElement(nameof(ReportInfo))]
        public List<ReportInfo> ReportInformations { get; set; }
    }
}