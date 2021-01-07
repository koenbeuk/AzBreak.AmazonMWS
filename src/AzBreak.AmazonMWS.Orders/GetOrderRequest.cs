using AzBreak.AmazonMWS.Core.Internal;
using System.Collections.Generic;

namespace AzBreak.AmazonMWS.Orders
{
    public class GetOrderRequest
    {
        /// <summary>
        /// A list of AmazonOrderId values. An AmazonOrderId is an Amazon-defined order identifier, in 3-7-7 format.	
        /// </summary>
        public IEnumerable<string> AmazonOrderIds { get; set; }

        public IDictionary<string, object> ToParametersDictionary()
          => new ParameterDictionaryBuilder()
                .Add("AmazonOrderId.Id", AmazonOrderIds)
                .Parameters;
    }
}