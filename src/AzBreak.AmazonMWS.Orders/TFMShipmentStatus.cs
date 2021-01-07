using AzBreak.AmazonMWS.Core;
using System.Xml.Serialization;

namespace AzBreak.AmazonMWS.Orders
{
    public class TFMShipmentStatus : AmazonMWSEnumeration
    {
        public static implicit operator TFMShipmentStatus(string value) => new TFMShipmentStatus { Value = value };

        public const string PendingPickUp = nameof(PendingPickUp);
        public const string LabelCanceled = nameof(LabelCanceled);
        public const string PickedUp = nameof(PickedUp);
        public const string AtDestinationFC = nameof(AtDestinationFC);
        public const string Delivered = nameof(Delivered);
        public const string RejectedByBuyer = nameof(RejectedByBuyer);
        public const string Undeliverable = nameof(Undeliverable);
        public const string ReturnedToSeller = nameof(ReturnedToSeller);
    }
}