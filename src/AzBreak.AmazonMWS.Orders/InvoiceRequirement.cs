using AzBreak.AmazonMWS.Core;
using System.Xml.Serialization;

namespace AzBreak.AmazonMWS.Orders
{
    public class InvoiceRequirement : AmazonMWSEnumeration
    {
        public static implicit operator InvoiceRequirement(string value) => new InvoiceRequirement { Value = value };

        /// <summary>
        /// Buyer requested a separate invoice for each order item in the order
        /// </summary>
        public const string Individual = nameof(Individual);

        /// <summary>
        /// Buyer requested one invoice to include all of the order items in the order
        /// </summary>
        public const string Consolidated = nameof(Consolidated);

        /// <summary>
        /// Buyer did not request an invoice
        /// </summary>
        public const string MustNotSend = nameof(MustNotSend);
    }
}