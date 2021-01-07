using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AzBreak.AmazonMWS.Orders
{
    [Serializable]
    [XmlRoot("GetServiceStatusResult", Namespace = "https://mws.amazonservices.com/Orders/2013-09-01")]
    public class ServiceStatusResult
    {
        public enum StatusType
        {
            [XmlEnum("GREEN")] Green,
            [XmlEnum("YELLOW")] Yellow,
            [XmlEnum("RED")] Red
        }

        public class Message
        {
            public string Locale { get; set; }
            public string Text { get; set; }
        }

        public StatusType Status { get; set; }
        public DateTime Timestamp { get; set; }
        public string MessageId { get; set; }
        public List<Message> Messages { get; set; }
    }
}
