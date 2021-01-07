using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzBreak.AmazonMWS.Orders
{
    public class PaymentExecutionDetail
    {
        /// <summary>
        /// The amount paid using the sub-payment method indicated by the sibling PaymentMethod response element.	
        /// </summary>
        public Money Payment { get; set; }

        /// <summary>
        /// A sub-payment method for a COD order.
        /// </summary>
        public PaymentMethod PaymentMethod { get; set; }
    }
}
