using AzBreak.AmazonMWS.Core.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzBreak.AmazonMWS.Orders
{
    public class ListOrdersRequest
    {

        /// <summary>
        /// A date used for selecting orders created after (or at) a specified time.
        /// </summary>
        /// <remarks>
        /// Must be no later than two minutes before the time that the request was submitted.
        /// </remarks>
        public DateTimeOffset? CreatedAfter { get; set; }

        /// <summary>
        /// A date used for selecting orders created before (or at) a specified time.	
        /// </summary>
        /// <remarks>
        /// Must be later than CreatedAfter.	
        /// Must be no later than two minutes before the time that the request was submitted.
        /// </remarks>
        public DateTimeOffset? CreatedBefore { get; set; }

        /// <summary>
        /// A date used for selecting orders that were last updated after (or at) a specified time. An update is defined as any change in order status, including the creation of a new order. Includes updates made by Amazon and by the seller.	
        /// </summary>
        /// <remarks>
        /// Must be no later than two minutes before the time that the request was submitted.
        /// </remarks>
        public DateTimeOffset? LastUpdatedAfter { get; set; }

        /// <summary>
        /// A list of OrderStatus values. Used to select orders with a current status that matches one of the status values that you specify.	
        /// </summary>
        public IEnumerable<OrderStatus> OrderStatuses { get; set; }

        /// <summary>
        /// A list of MarketplaceId values. Used to select orders that were placed in the Marketplaces that you specify.
        /// </summary>
        /// <remarks>
        /// Any Marketplace in which the seller is registered to sell.
        /// Maximum: 50
        /// </remarks>
        public IEnumerable<string> MarketplaceIds { get; set; }

        /// <summary>
        /// A list that indicates how an order was fulfilled.	
        /// </summary>
        public IEnumerable<FulfillmentChannel> FulfillmentChannels { get; set; }

        /// <summary>
        /// A list of PaymentMethod values. Used to select orders paid for with the payment methods that you specify.
        /// </summary>
        public IEnumerable<PaymentMethod> PaymentMethods { get; set; }

        /// <summary>
        /// The e-mail address of a buyer. Used to select only the orders that contain the specified e-mail address.
        /// </summary>
        /// <remarks>
        /// If BuyerEmail is specified, then FulfillmentChannel, OrderStatus, PaymentMethod, LastUpdatedAfter, LastUpdatedBefore, and SellerOrderId cannot be specified.
        /// </remarks>
        public string BuyerEmail { get; set; }

        /// <summary>
        /// An order identifier that is specified by the seller. Not an Amazon order identifier. Used to select only the orders that match a seller-specified order identifier.	
        /// </summary>
        /// <remarks>
        /// If SellerOrderId is specified, then FulfillmentChannel, OrderStatus, PaymentMethod, LastUpdatedAfter, LastUpdatedBefore, and BuyerEmail cannot be specified
        /// </remarks>
        public string SellerOrderId { get; set; }

        /// <summary>
        /// A number that indicates the maximum number of orders that can be returned per page.	
        /// </summary>
        /// <remarks>
        /// Value must be 1 - 100.
        /// </remarks>
        public int? MaxResultsPerPage { get; set; }

        public IDictionary<string, object> ToParametersDictionary()
          => new ParameterDictionaryBuilder()
                .Add(nameof(CreatedAfter), CreatedAfter)
                .Add(nameof(CreatedBefore), CreatedBefore)
                .Add(nameof(LastUpdatedAfter), LastUpdatedAfter)
                .Add("OrderStatus.Status", OrderStatuses)
                .Add("MarketplaceId.Id", MarketplaceIds)
                .Add("FulfillmentChannel.Channel", FulfillmentChannels)
                .Add("PaymentMethod.Method", PaymentMethods)
                .Add(nameof(BuyerEmail), BuyerEmail)
                .Add(nameof(SellerOrderId), SellerOrderId)
                .Add(nameof(MaxResultsPerPage), MaxResultsPerPage)
                .Parameters;
    }
}
