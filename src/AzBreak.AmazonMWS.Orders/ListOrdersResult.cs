using AzBreak.AmazonMWS.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AzBreak.AmazonMWS.Orders
{
    [Serializable]
    [XmlRoot(Namespace = "https://mws.amazonservices.com/Orders/2013-09-01")]
    public class ListOrdersResult
    {
        /// <summary>
        /// A generated string used to pass information to your next request. If NextToken is returned, pass the value of NextToken to ListOrdersByNextToken. If NextToken is not returned, there are no more orders to return.	
        /// </summary>
        public string NextToken { get; set; }
        /// <summary>
        /// A date returned if you used the LastUpdatedAfter request parameter. If you also used the LastUpdatedBefore request parameter, the date you provided with that request parameter is returned. Otherwise the default value of the LastUpdatedBefore request parameter is returned: the time of your request minus two minutes.
        /// </summary>
        public AmazonMWSDateTime LastUpdatedBefore { get; set; }
        /// <summary>
        /// A date returned if you used the CreatedAfter request parameter. If you also used the CreatedBefore request parameter, the date you provided with that request parameter is returned. Otherwise the default value of the CreatedBefore request parameter is returned: the time of your request minus two minutes.	
        /// </summary>
        public AmazonMWSDateTime CreatedBefore { get; set; }
        /// <summary>
        /// A list of orders
        /// </summary>
        public List<Order> Orders { get; set; }
    }
}
