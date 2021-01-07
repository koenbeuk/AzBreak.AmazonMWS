using AzBreak.AmazonMWS.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AzBreak.AmazonMWS.Orders
{
    public class FulfillmentChannel : AmazonMWSEnumeration
    {
        /// <summary>
        /// Fulfilled by Amazon
        /// </summary>
        public const string AFN = nameof(AFN);
        /// <summary>
        /// Fulfilled by the seller
        /// </summary>
        public const string MFN = nameof(MFN);

    }
}
