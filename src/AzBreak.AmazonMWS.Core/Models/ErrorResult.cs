using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AzBreak.AmazonMWS
{
    [XmlRoot("Error")]
    public class ErrorResult
    {
        public string Type { get; set; }
        public ErrorCode Code { get; set; }
        public string Message { get; set; }
        public string Detail { get; set; }
    }
}
