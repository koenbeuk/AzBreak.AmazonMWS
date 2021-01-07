using AzBreak.AmazonMWS.Core;

namespace AzBreak.AmazonMWS.Reports
{
    public sealed class Schedule : AmazonMWSEnumeration
    {
        public static implicit operator Schedule(string value) => new Schedule { Value = value };

        public const string Every15Minutes = "_15_MINUTES_";
        public const string Every30Minutes = "_30_MINUTES_";
        public const string EveryHour = "_1_HOUR_";
        public const string Every2Hours = "_2_HOURS_";
        public const string Every4Hours = "_4_HOURS_";
        public const string Every8Hours = "_8_HOURS_";
        public const string Every12Hours = "_12_HOURS_";
        public const string EveryDay = "_1_DAY_";
        public const string Every2Days = "_2_DAYS_";
        public const string Every3Days = "_72_HOURS_";
        public const string EveryWeek = "_1_WEEK_";
        public const string Every14Days	= "_14_DAYS_";
        public const string Every15Days = "_15_DAYS_";
        public const string Every30Days = "_30_DAYS_";
        public const string Never = "_NEVER_";
    }
}