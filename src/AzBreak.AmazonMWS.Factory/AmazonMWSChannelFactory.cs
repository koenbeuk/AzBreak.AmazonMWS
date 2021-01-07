using System;
using AzBreak.AmazonMWS.Core;
using AzBreak.AmazonMWS.Core.RetryPolicies;
using AzBreak.AmazonMWS.Factory;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;

namespace AzBreak.AmazonMWS
{
    public static class AmazonMWSChannelFactory
    {
        public static IAmazonMWSChannel Create(AmazonMWSClientOptions options, ILoggerFactory loggerFactory = null, IExecutionRetryPolicy retryPolicy = null)
        {
            var services = new ServiceCollection();
            services.AddAmazonMWS();

            if (loggerFactory == null)
            {
                loggerFactory = new NullLoggerFactory();
            }
            if (retryPolicy == null)
            {
                retryPolicy = new NoExecutionRetryPolicy();
            }

            return new AmazonMWSChannel(new OptionsSnapshotWrappper<AmazonMWSClientOptions>(options), loggerFactory.CreateLogger<AmazonMWSChannel>(), retryPolicy);
        }
    }
}
