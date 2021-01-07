using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzBreak.AmazonMWS
{
    public sealed class Response<TResult> : Response
    {
        public string ResponseType { get; set; }
        public string DefaultNamespace { get; set; }
        public TResult Result { get; set; }
    }
}
