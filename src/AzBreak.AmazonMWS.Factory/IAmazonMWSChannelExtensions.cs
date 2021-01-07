using AzBreak.AmazonMWS.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzBreak.AmazonMWS
{
    public static class IAmazonMWSChannelExtensions
    {
        public static Feeds.IAmazonMWSFeedsClient CreateFeedsClient(this IAmazonMWSChannel channel)
            => new Feeds.AmazonMWSFeedsClient(channel);

        public static Reports.IAmazonMWSReportsClient CreateReportsClient(this IAmazonMWSChannel channel)
            => new Reports.AmazonMWSReportsClient(channel);

        public static Orders.IAmazonMWSOrdersClient CreateOrdersClient(this IAmazonMWSChannel channel)
            => new Orders.AmazonMWSOrdersClient(channel);

        public static Sellers.IAmazonMWSSellersClient CreateSellersClient(this IAmazonMWSChannel channel)
            => new Sellers.AmazonMWSSellersClient(channel);
    }
}
