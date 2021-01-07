using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AzBreak.AmazonMWS;
using Microsoft.Extensions.DependencyInjection;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class IAmazonMWSBuilderExtensions
    {
        public static IAmazonMWSBuilder AddAmazonMWSClients(this IAmazonMWSBuilder builder)
            => AddAmazonMWSClients(builder, null);

        public static IAmazonMWSBuilder AddAmazonMWSClients(this IAmazonMWSBuilder builder, Action<AmazonMWSClientOptions> configure)
        {
            if (builder == null)
                throw new ArgumentNullException(nameof(builder));

            if (configure != null)
            {
                builder.Services.Configure(configure);
            }

            return builder.AddFeedsClient()
                          .AddOrdersClient()
                          .AddReportsClient()
                          .AddSellersClient();
        }
    }
}
