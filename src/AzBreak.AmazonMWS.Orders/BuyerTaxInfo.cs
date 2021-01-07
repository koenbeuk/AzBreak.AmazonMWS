using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzBreak.AmazonMWS.Orders
{
    public class BuyerTaxInfo
    {
        /// <summary>
        /// The legal name of the company
        /// </summary>
        public string CompanyLegalName { get; set; }

        /// <summary>
        /// The country or region imposing the tax
        /// </summary>
        public string TaxingRegion { get; set; }

        /// <summary>
        /// A list of tax classifications
        /// </summary>
        public List<TaxClassification> TaxClassifications { get; set; }
    }
}
