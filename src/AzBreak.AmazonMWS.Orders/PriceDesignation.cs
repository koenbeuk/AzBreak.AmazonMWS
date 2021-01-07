using AzBreak.AmazonMWS.Core;
using System.Xml.Serialization;

namespace AzBreak.AmazonMWS.Orders
{
    public class PriceDesignation : AmazonMWSEnumeration
    {
        public static implicit operator PriceDesignation(string value) => new PriceDesignation { Value = value };

        public const string BusinessPrice = nameof(BusinessPrice);
    }
}