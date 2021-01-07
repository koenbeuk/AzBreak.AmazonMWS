using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AzBreak.AmazonMWS.Core.RetryPolicies;
using Microsoft.Extensions.DependencyInjection;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class IAmazonMWSBuilderExtensions
    {
        public static IAmazonMWSBuilder ConfigureNoExecutionRetryPolicy(this IAmazonMWSBuilder builder)
            => ConfigureExecutionRetryPolicy<NoExecutionRetryPolicy>(builder);

        public static IAmazonMWSBuilder ConfigureThrottleExecutionRetryPolicy(this IAmazonMWSBuilder builder, Action<RetryPolicyOptions> configure = null)
            => ConfigureExecutionRetryPolicy<ThrottleExecutionRetryPolicy>(builder, configure);

        public static IAmazonMWSBuilder ConfigureNetworkErrorExecutionRetryPolicy(this IAmazonMWSBuilder builder, Action<RetryPolicyOptions> configure = null)
            => ConfigureExecutionRetryPolicy<NetworkErrorExecutionRetryPolicy>(builder, configure);

        public static IAmazonMWSBuilder ConfigureThrottleAndNetworkErrorExecutionRetryPolicy(this IAmazonMWSBuilder builder, Action<RetryPolicyOptions> configure = null)
            => ConfigureExecutionRetryPolicy<ThrottleAndNetworkErrorExecutionRetryPolicy>(builder, configure); 

        public static IAmazonMWSBuilder ConfigureExecutionRetryPolicy<TExecutionRetryPolicy>(this IAmazonMWSBuilder builder, Action<RetryPolicyOptions> configure = null)
            where TExecutionRetryPolicy : class, IExecutionRetryPolicy
        {
            if (builder == null)
                throw new ArgumentNullException(nameof(builder));

            var existingRetryPolicies = builder.Services.Where(x => typeof(IExecutionRetryPolicy).IsAssignableFrom(x.ServiceType)).ToArray();
            foreach (var existingRetryPolicy in existingRetryPolicies)
            {
                builder.Services.Remove(existingRetryPolicy);
            }

            builder.Services.AddScoped<IExecutionRetryPolicy, TExecutionRetryPolicy>();

            if (configure != null)
                builder.Services.Configure(configure);

            return builder;
        }
    }
}
