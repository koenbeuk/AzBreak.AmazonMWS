namespace AzBreak.AmazonMWS.Orders
{
    public class InvoiceData
    {
        /// <summary>
        /// The invoice requirement information
        /// </summary>
        public InvoiceRequirement InvoiceRequirement { get; set; }

        /// <summary>
        /// Invoice category information selected by the buyer at the time the order was placed
        /// </summary>
        public string BuyerSelectedInvoiceCategory { get; set; }

        /// <summary>
        /// The buyer-specified invoice title
        /// </summary>
        public string InvoiceTitle { get; set; }

        /// <summary>
        /// The invoice information
        /// </summary>
        public InvoiceInformation InvoiceInformation { get; set; }
    }
}