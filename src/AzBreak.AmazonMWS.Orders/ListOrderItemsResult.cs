using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzBreak.AmazonMWS.Orders
{
    public class ListOrderItemsResult
    {
        /// <summary>
        /// A generated string used to pass information to your next request. If NextToken is returned, pass the value of NextToken to ListOrderItemsByNextToken. If NextToken is not returned, there are no more order items to return.	
        /// </summary>
        public string NextToken { get; set; }
        
        /// <summary>
        ///An Amazon-defined order identifier, in 3-7-7 format.	
        /// </summary>
        public string AmazonOrderId { get; set; }
        
        /// <summary>
        /// A list of orders
        /// </summary>
        public List<OrderItem> OrderItems { get; set; }
    }
}
