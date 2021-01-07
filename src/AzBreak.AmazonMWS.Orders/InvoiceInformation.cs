using AzBreak.AmazonMWS.Core;
using System.Xml.Serialization;

namespace AzBreak.AmazonMWS.Orders
{
    public class InvoiceInformation : AmazonMWSEnumeration
    {
        public static implicit operator InvoiceInformation(string value) => new InvoiceInformation { Value = value };

        /// <summary>
        /// Buyer did not request an invoice.
        /// </summary>
        public const string NotApplicable = nameof(NotApplicable);

        /// <summary>
        /// BuyerSelectedInvoiceCategory Amazon recommends using the BuyerSelectedInvoiceCategory value returned by this operation for the invoice category on the invoice.
        /// </summary>
        public const string BuyerSelectedInvoiceCategory = nameof(BuyerSelectedInvoiceCategory);

        /// <summary>
        /// ProductTitleAmazon recommends using the product title for invoice category on the invoice.
        /// </summary>
        public const string ProductTitleAmazon = nameof(ProductTitleAmazon);
    }
}