using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AzBreak.AmazonMWS
{
    [XmlRoot]
    public class ResponseMetadata
    {
        public string RequestId { get; set; }
    }
}
