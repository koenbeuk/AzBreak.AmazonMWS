using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzBreak.AmazonMWS.Sellers
{
    public class Participation
    {
        public string MarketplaceId { get; set; }
        public string SellerId { get; set; }
        public HasSellerSuspendedListings HasSellerSuspendedListings { get; set; }
    }
}
