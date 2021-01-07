using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Extensions.DependencyInjection
{
    public interface IAmazonMWSBuilder
    {
        /// <summary>
        /// Gets the <see cref="IServiceCollection"/> where AmazonMWS services are configured.
        /// </summary>
        IServiceCollection Services { get; }
    }
}
