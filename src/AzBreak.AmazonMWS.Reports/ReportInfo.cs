using AzBreak.AmazonMWS.Core;

namespace AzBreak.AmazonMWS.Reports
{
    public class ReportInfo
    {
        /// <summary>
        /// A unique identifier for the report.
        /// </summary>
        public string ReportId { get; set; }

        /// <summary>
        /// The ReportType value requested.
        /// </summary>
        public ReportType ReportType { get; set; }

        /// <summary>
        /// A unique identifier for the report request.
        /// </summary>
        public string ReportRequestId { get; set; }

        /// <summary>
        /// The date the report is available.
        /// </summary>
        public AmazonMWSDateTime AvailableDate { get; set; }

        /// <summary>
        /// A Boolean value that indicates if the report was acknowledged by this call to the UpdateReportAcknowledgements operation. The value is true if the report was acknowledged; otherwise false.
        /// </summary>
        public bool Acknowledged { get; set; }

        /// <summary>
        /// The date the report was acknowledged.
        /// </summary>
        public AmazonMWSDateTime AcknowledgedDate { get; set; }
    }
}