﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AzBreak.AmazonMWS.Orders;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class IAmazonMWSBuilderExtensions
    {
        public static IAmazonMWSBuilder AddOrdersClient(this IAmazonMWSBuilder builder)
        {
            if (builder == null)
                throw new ArgumentNullException(nameof(builder));

            builder.Services.TryAddScoped<IAmazonMWSOrdersClient, AmazonMWSOrdersClient>();
            return builder;
        }
    }
}
