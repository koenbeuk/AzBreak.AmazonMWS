using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzBreak.AmazonMWS
{
    public class Request
    {
        public string Resource { get; set; }
        public string Version { get; set; }
        public string Action { get; set; }
        public IDictionary<string, object> Parameters { get; set; }
        public AmazonMWSClientOptions ClientOptions { get; set; }
        public Stream Body { get; set; }
    }
}
