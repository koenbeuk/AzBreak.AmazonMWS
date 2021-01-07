using AzBreak.AmazonMWS.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzBreak.AmazonMWS.Orders
{
    public class PaymentMethod : AmazonMWSEnumeration
    {
        public static implicit operator PaymentMethod(string value) => new PaymentMethod { Value = value };

        /// <summary>
        /// Cash on delivery. Available only in China (CN) and Japan (JP).
        /// </summary>
        public const string COD = nameof(COD);
        /// <summary>
        /// Convenience store payment
        /// </summary>
        public const string CVS = nameof(CVS);
        /// <summary>
        /// Gift Card. Available only in CN and JP.
        /// </summary>
        public const string GC = nameof(GC);
        /// <summary>
        /// Amazon Points. Available only in JP.
        /// </summary>
        public const string PointsAccount = nameof(PointsAccount);
        /// <summary>
        /// Any payment method other than COD or CVS
        /// </summary>
        public const string Other = nameof(Other);
    }
}
