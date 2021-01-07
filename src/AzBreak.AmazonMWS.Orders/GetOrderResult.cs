using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AzBreak.AmazonMWS.Orders
{
    [Serializable]
    [XmlRoot("GetOrderResult", Namespace = "https://mws.amazonservices.com/Orders/2013-09-01")]
    public class GetOrderResult
    {
        public List<Order> Orders { get; set; }    
    }
}
