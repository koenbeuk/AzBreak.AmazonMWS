using AzBreak.AmazonMWS.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AzBreak.AmazonMWS.Orders
{
    public interface IAmazonMWSOrdersClient
    {
        /// <summary>
        /// Returns the operational status of the Orders API section.
        /// </summary>
        /// <remarks>
        /// The GetServiceStatus operation returns the operational status of the Orders API section of Amazon Marketplace Web Service. Status values are GREEN, YELLOW, and RED.
        /// The GetServiceStatus operation has a maximum request quota of two and a restore rate of one request every five minutes.For definitions of throttling terminology, see Orders API.
        /// </remarks>
        Task<Response<ServiceStatusResult>> GetServiceStatus(AmazonMWSClientOptions clientOptions = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Returns orders created or updated during a time frame that you specify.
        /// </summary>
        /// <remarks>
        /// The ListOrders operation returns a list of orders created or updated during a time frame that you specify. You define that time frame using the CreatedAfter parameter or the LastUpdatedAfter parameter. You must use one of these parameters, but not both. You can also apply a range of filtering criteria to narrow the list of orders that is returned. The ListOrders operation includes order information for each order returned, including AmazonOrderId, OrderStatus, FulfillmentChannel, and LastUpdateDate.
        /// </remarks>
        Task<Response<ListOrdersResult>> ListOrders(ListOrdersRequest request, AmazonMWSClientOptions clientOptions = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Returns the next page of orders using the NextToken parameter.
        /// </summary>
        /// <remarks>
        /// The ListOrdersByNextToken operation returns the next page of orders using the NextToken value that was returned by your previous request to either ListOrders or ListOrdersByNextToken. If NextToken is not returned, there are no more pages to return.
        /// </remarks>
        Task<Response<ListOrdersResult>> ListOrdersByNextToken(string nextToken, AmazonMWSClientOptions clientOptions = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Returns orders based on the AmazonOrderId values that you specify.
        /// </summary>
        /// <remarks>
        /// The GetOrder operation returns an order for each AmazonOrderId that you specify, up to a maximum of 50. The GetOrder operation includes order information for each order returned, including PurchaseDate, OrderStatus, FulfillmentChannel, and LastUpdateDate.
        /// </remarks>
        Task<Response<GetOrderResult>> GetOrders(GetOrderRequest request, AmazonMWSClientOptions clientOptions = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Returns order items based on the AmazonOrderId that you specify.
        /// </summary>
        /// <remarks>
        /// The ListOrderItems operation returns order item information for an AmazonOrderId that you specify. The order item information includes Title, ASIN, SellerSKU, ItemPrice, ShippingPrice, as well as tax and promotion information.
        /// You can retrieve order item information by first using the ListOrders operation to find orders created or updated during a time frame that you specify.An AmazonOrderId is included with each order that is returned.You can then use these AmazonOrderId values with the ListOrderItems operation to get detailed order item information for each order.
        /// Note: When an order is in the Pending state (the order has been placed but payment has not been authorized), the ListOrderItems operation does not return information about pricing, taxes, shipping charges, gift wrapping, or promotions for the order items in the order.After an order leaves the Pending state (this occurs when payment has been authorized) and enters the Unshipped, Partially Shipped, or Shipped state, the ListOrderItems operation returns information about pricing, taxes, shipping charges, gift wrapping, and promotions for the order items in the order.
        /// The following response elements are not available for orders with an OrderStatus of Pending but are available for orders with an OrderStatus of Unshipped, Partially Shipped, or Shipped state:
        ///     ItemTax
        ///     GiftWrapPrice
        ///     ItemPrice
        ///     PromotionDiscount
        ///     GiftWrapTax
        ///     ShippingTax
        ///     ShippingPrice
        ///     ShippingDiscount
        /// </remarks>
        Task<Response<ListOrderItemsResult>> ListOrderItems(string amazonOrderId, AmazonMWSClientOptions clientOptions = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Returns the next page of order items using the NextToken parameter.
        /// </summary>
        /// <remarks>
        /// The ListOrderItemsByNextToken operation returns the next page of order items using the NextToken value that was returned by your previous request to either ListOrderItems or ListOrderItemsByNextToken. If NextToken is not returned, there are no more pages to return.
        /// </remarks>
        Task<Response<ListOrderItemsResult>> ListOrderItemsByNextToken(string nextToken, AmazonMWSClientOptions clientOptions = null, CancellationToken cancellationToken = default);
    }
}
