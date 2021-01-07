using AzBreak.AmazonMWS.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AzBreak.AmazonMWS.Orders
{
    public class OrderStatus : AmazonMWSEnumeration
    {
        public static implicit operator OrderStatus(string value) => new OrderStatus { Value = value };

        /// <summary>
        /// This status is available for pre-orders only. The order has been placed, payment has not been authorized, and the release date of the item is in the future. The order is not ready for shipment. Note that Preorder is a possible OrderType value in Japan (JP) only.
        /// </summary>
        public const string PendingAvailability = nameof(PendingAvailability);
        /// <summary>
        /// The order has been placed but payment has not been authorized. The order is not ready for shipment. Note that for orders with OrderType = Standard, the initial order status is Pending. For orders with OrderType = Preorder (available in JP only), the initial order status is PendingAvailability, and the order passes into the Pending status when the payment authorization process begins.
        /// </summary>
        public const string Pending = nameof(Pending);
        /// <summary>
        /// Payment has been authorized and order is ready for shipment, but no items in the order have been shipped.
        /// </summary>
        public const string Unshipped = nameof(Unshipped);
        /// <summary>
        /// One or more (but not all) items in the order have been shipped.
        /// </summary>
        public const string PartiallyShipped = nameof(PartiallyShipped);
        /// <summary>
        /// All items in the order have been shipped.
        /// </summary>
        public const string Shipped = nameof(Shipped);
        /// <summary>
        /// All items in the order have been shipped. The seller has not yet given confirmation to Amazon that the invoice has been shipped to the buyer. Note: This value is available only in China (CN).
        /// </summary>
        public const string InvoiceUnconfirmed = nameof(InvoiceUnconfirmed);
        /// <summary>
        /// The order was canceled.
        /// </summary>
        public const string Canceled = nameof(Canceled);
        /// <summary>
        /// The order cannot be fulfilled. This state applies only to Amazon-fulfilled orders that were not placed on Amazon's retail web site.
        /// </summary>
        public const string Unfulfillable = nameof(Unfulfillable);
    }
}
