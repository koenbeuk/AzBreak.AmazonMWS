using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzBreak.AmazonMWS.Orders
{
    public class TaxClassification
    {
        /// <summary>
        /// The type of tax.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The buyer's tax identifier.
        /// </summary>
        public string Value { get; set; }
    }
}
