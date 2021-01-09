using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace AzBreak.AmazonMWS.Core.Internal
{
    public class AmazonMWSBuilder : IAmazonMWSBuilder
    {
        public AmazonMWSBuilder(IServiceCollection services)
        {
            Services = services;
        }

        public IServiceCollection Services { get; }
    }
}
