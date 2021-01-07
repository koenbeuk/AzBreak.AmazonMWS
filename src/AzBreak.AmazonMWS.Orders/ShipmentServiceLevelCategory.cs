using AzBreak.AmazonMWS.Core;
using System.Xml.Serialization;

namespace AzBreak.AmazonMWS.Orders
{
    public class ShipmentServiceLevelCategory : AmazonMWSEnumeration
    {
        public const string Expedited = nameof(Expedited);
        public const string FreeEconomy = nameof(FreeEconomy);
        public const string NextDay = nameof(NextDay);
        public const string SameDay = nameof(SameDay);
        public const string SecondDay = nameof(SecondDay);
        public const string Scheduled = nameof(Scheduled);
        public const string Standard = nameof(Standard);
    }
}