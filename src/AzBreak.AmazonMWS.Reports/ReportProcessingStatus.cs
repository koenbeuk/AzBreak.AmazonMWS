using AzBreak.AmazonMWS.Core;

namespace AzBreak.AmazonMWS.Reports
{
    public sealed class ReportProcessingStatus : AmazonMWSEnumeration
    {
        public static implicit operator ReportProcessingStatus(string value) => new ReportProcessingStatus { Value = value };

        public const string Submitted = "_SUBMITTED_";
        public const string InProgress = "_IN_PROGRESS_";
        public const string Cancelled = "_CANCELLED_";
        public const string Done = "_DONE_";
        public const string DoneNoData = "_DONE_NO_DATA_";
    }
}