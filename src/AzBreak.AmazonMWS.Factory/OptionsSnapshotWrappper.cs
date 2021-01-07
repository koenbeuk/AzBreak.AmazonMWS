using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace AzBreak.AmazonMWS.Factory
{
    struct OptionsSnapshotWrappper<TOptions> : IOptionsSnapshot<TOptions>
        where TOptions : class, new()
    {
        private readonly TOptions value;

        public OptionsSnapshotWrappper(TOptions value)
        {
            this.value = value;
        }

        public TOptions Value => value;

        public TOptions Get(string name) => value;
    }
}
