using AzBreak.AmazonMWS;
using AzBreak.AmazonMWS.Feeds;
using AzBreak.AmazonMWS.Orders;
using AzBreak.AmazonMWS.Reports;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class AmazonMWSServicesExtensions
    {
        public static IAmazonMWSBuilder AddAmazonMWSClients(this IServiceCollection services)
            => AddAmazonMWSClients(services, null);

        public static IAmazonMWSBuilder AddAmazonMWSClients(this IServiceCollection services, Action<AmazonMWSClientOptions> configure)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            var builder = services.AddAmazonMWS(configure)
                                  .AddAmazonMWSClients();

            return builder;
        }
    }
}
