using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AzBreak.AmazonMWS.Reports;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class IAmazonMWSBuilderExtensions
    {
        public static IAmazonMWSBuilder AddReportsClient(this IAmazonMWSBuilder builder)
        {
            if (builder == null)
                throw new ArgumentNullException(nameof(builder));

            builder.Services.TryAddScoped<IAmazonMWSReportsClient, AmazonMWSReportsClient>();
            return builder;
        }
    }
}
