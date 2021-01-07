using AzBreak.AmazonMWS.Core;

namespace AzBreak.AmazonMWS.Reports
{
    public class ReportRequestInfo
    {
        /// <summary>
        /// A unique identifier for the report request.
        /// </summary>
        public string ReportRequestId { get; set; }

        /// <summary>
        /// The ReportType value requested.
        /// </summary>
        public ReportType ReportType { get; set; }

        /// <summary>
        /// The start of a date range used for selecting the data to report.
        /// </summary>
        public AmazonMWSDateTime StartDate { get; set; }

        /// <summary>
        /// The end of a date range used for selecting the data to report.
        /// </summary>
        public AmazonMWSDateTime EndDate { get; set; }

        /// <summary>
        /// A Boolean value that indicates if a report is scheduled. The value is true if the report was scheduled; otherwise false.
        /// </summary>
        public bool Scheduled { get; set; }

        /// <summary>
        /// The date when the report was submitted.
        /// </summary>
        public AmazonMWSDateTime SubmittedDate { get; set; }

        /// <summary>
        /// The processing status of the report.
        /// </summary>
        public ReportProcessingStatus ReportProcessingStatus { get; set; }

        /// <summary>
        /// The report identifier used to retrieve the report.
        /// </summary>
        public string GeneratedReportId { get; set; }

        /// <summary>
        /// The date when the report processing started.
        /// </summary>
        public AmazonMWSDateTime StartedProcessingDate { get; set; }

        /// <summary>
        /// The date when the report processing completed.
        /// </summary>
        public AmazonMWSDateTime CompletedDate { get; set; }

        public bool IsComplete => ReportProcessingStatus == ReportProcessingStatus.Cancelled || ReportProcessingStatus == ReportProcessingStatus.Done || ReportProcessingStatus == ReportProcessingStatus.DoneNoData;
    }
}