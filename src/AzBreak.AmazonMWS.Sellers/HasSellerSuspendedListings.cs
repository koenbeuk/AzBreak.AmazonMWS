using AzBreak.AmazonMWS.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzBreak.AmazonMWS.Sellers
{
    public class HasSellerSuspendedListings : AmazonMWSEnumeration
    {
        public static implicit operator HasSellerSuspendedListings(string value) => new HasSellerSuspendedListings { Value = value };

        public const string Yes = "Yes";
        public const string No = "No";
    }
}
