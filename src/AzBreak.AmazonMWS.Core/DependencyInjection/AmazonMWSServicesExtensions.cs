using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AzBreak.AmazonMWS;
using AzBreak.AmazonMWS.Core;
using AzBreak.AmazonMWS.Core.Internal;
using AzBreak.AmazonMWS.Core.RetryPolicies;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class AmazonMWSServicesExtensions
    {
        public static IAmazonMWSBuilder AddAmazonMWS(this IServiceCollection services)
            => AddAmazonMWS(services, null);

        public static IAmazonMWSBuilder AddAmazonMWS(this IServiceCollection services, Action<AmazonMWSClientOptions> configure)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            if (configure != null)
            {
                services.Configure(configure);
            }

            services.AddOptions();
            services.TryAddScoped<IExecutionRetryPolicy, NetworkErrorExecutionRetryPolicy>();
            services.TryAddScoped<IAmazonMWSChannel, AmazonMWSChannel>();

            return new AmazonMWSBuilder(services);
        }
    }
}
