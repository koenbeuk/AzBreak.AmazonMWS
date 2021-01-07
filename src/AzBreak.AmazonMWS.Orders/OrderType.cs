using AzBreak.AmazonMWS.Core;
using System.Xml.Serialization;

namespace AzBreak.AmazonMWS.Orders
{
    public class OrderType : AmazonMWSEnumeration
    {
        public static implicit operator OrderType(string value) => new OrderType { Value = value };

        /// <summary>
        /// An order that contains items for which you currently have inventory in stock.
        /// </summary>
        public const string StandardOrder = nameof(StandardOrder);
        /// <summary>
        /// An order that contains items with a release date that is in the future.
        /// </summary>
        public const string Preorder = nameof(Preorder);
    }
}