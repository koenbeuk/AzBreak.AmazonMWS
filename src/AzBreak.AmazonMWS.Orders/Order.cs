using AzBreak.AmazonMWS.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzBreak.AmazonMWS.Orders
{
    public class Order
    {
        /// <summary>
        /// An Amazon-defined order identifier, in 3-7-7 format.
        /// </summary>
        public string AmazonOrderId { get; set; }

        /// <summary>
        /// A seller-defined order identifier.	
        /// </summary>
        public string SellerOrderId { get; set; }

        /// <summary>
        /// The date when the order was created.	
        /// </summary>
        public AmazonMWSDateTime PurchaseDate { get; set; }

        /// <summary>
        /// The date when the order was last updated.
        /// LastUpdateDate is returned with an incorrect date for orders that were last updated before 2009-04-01.
        /// </summary>
        public AmazonMWSDateTime LastUpdateDate { get; set; }

        /// <summary>
        /// The current order status.	
        /// </summary>
        public OrderStatus OrderStatus { get; set; }

        /// <summary>`
        /// How the order was fulfilled: by Amazon (AFN) or by the seller (MFN).
        /// </summary>
        public FulfillmentChannel FulfillmentChannel { get; set; }

        /// <summary>
        /// The sales channel of the first item in the order.
        /// </summary>
        public string SalesChannel { get; set; }

        /// <summary>
        /// The order channel of the first item in the order.	
        /// </summary>
        public string OrderChannel { get; set; }

        /// <summary>
        /// The shipment service level of the order.
        /// </summary>
        public string ShipServiceLevel { get; set; }

        /// <summary>
        /// The shipping address for the order.	
        /// </summary>
        public Address ShippingAddress { get; set; }

        /// <summary>
        /// The total charge for the order.
        /// </summary>
        public Money OrderTotal { get; set; }

        /// <summary>
        /// The number of items shipped.	
        /// </summary>
        public int? NumberOfItemsShipped { get; set; }

        /// <summary>
        /// The number of items unshipped.	
        /// </summary>
        public int? NumberOfItemsUnshipped { get; set; }

        /// <summary>
        /// A list of payment methods for the order.	
        /// </summary>
        public List<PaymentExecutionDetail> PaymentMethodDetails { get; set; }

        /// <summary>
        /// Indicates if this is a replacement order.
        /// </summary>
        public bool? IsReplacementOrder { get; set; }

        /// <summary>
        /// The AmazonOrderId value for the order that is being replaced.
        /// </summary>
        public string ReplacedOrderId { get; set; }

        /// <summary>
        /// The anonymized identifier for the Marketplace where the order was placed.
        /// </summary>
        public string MarketplaceId { get; set; }

        /// <summary>
        /// The anonymized e-mail address of the buyer.	
        /// </summary>
        public string BuyerEmail { get; set; }

        /// <summary>
        /// The name of the buyer.
        /// </summary>
        public string BuyerName { get; set; }

        /// <summary>
        /// The county of the buyer.		
        /// This element is used only in the Brazil marketplace.
        /// </summary>
        public string BuyerCounty { get; set; }

        /// <summary>
        /// Tax information about the buyer.
        /// </summary>
        public BuyerTaxInfo BuyerTaxInfo { get; set; }

        /// <summary>
        /// The shipment service level category of the order.
        /// </summary>
        public ShipmentServiceLevelCategory ShipmentServiceLevelCategory { get; set; }

        /// <summary>
        /// Indicates if the order was shipped by the Amazon Transportation for Merchants (Amazon TFM) service.
        /// </summary>
        /// <remarks>
        /// Amazon TFM is available only in China (CN).
        /// </remarks>
        public bool? ShippedByAmazonTFM { get; set; }

        /// <summary>
        /// The status of the Amazon TFM order. Returned only if ShippedByAmazonTFM = True. Note that even if ShippedByAmazonTFM = True, TFMShipmentStatus will not be returned if you have not yet created the shipment.
        /// </summary>
        public TFMShipmentStatus TFMShipmentStatus { get; set; }

        /// <summary>
        /// A seller-customized shipment service level that is mapped to one of the four standard shipping settings supported by Checkout by Amazon (CBA). For more information, see the Setting Up Flexible Shipping Options topic of the Amazon Payments Help for your marketplace.
        /// </summary>
        /// <remarks>
        /// CBA is available only to sellers in the United States (US), the United Kingdom (UK), and Germany (DE).
        /// </remarks>
        public string CbaDisplayableShippingLabel { get; set; }

        /// <summary>
        /// The type of the order.
        /// </summary>
        public OrderType OrderType { get; set; }

        /// <summary>
        /// The start of the time period that you have committed to ship the order.
        /// </summary>
        /// <remarks>
        /// EarliestShipDate might not be returned for orders placed before February 1, 2013.
        /// </remarks>
        public AmazonMWSDateTime EarliestShipDate { get; set; }

        /// <summary>
        /// The end of the time period that you have committed to ship the order. 
        /// </summary>
        /// <remarks>
        /// LatestShipDate might not be returned for orders placed before February 1, 2013.
        /// </remarks>
        public AmazonMWSDateTime LatestShipDate { get; set; }

        /// <summary>
        /// The start of the time period that you have commited to fulfill the order.
        /// </summary>
        public AmazonMWSDateTime EarliestDeliveryDate { get; set; }

        /// <summary>
        /// The end of the time period that you have commited to fulfill the order.
        /// </summary>
        public AmazonMWSDateTime LatestDeliveryDate { get; set; }

        /// <summary>
        /// Indicates that the order is an Amazon Business order. An Amazon Business order is an order where the buyer is a Verified Business Buyer and the seller is an Amazon Business Seller. For more information about the Amazon Business Seller Program, see the Amazon Business website.
        /// </summary>
        public bool? IsBusinessOrder { get; set; }

        /// <summary>
        /// The purchase order (PO) number entered by the buyer at checkout.
        /// </summary>
        public string PurchaseOrderNumber { get; set; }

        /// <summary>
        /// Indicates that the order is a seller-fulfilled Amazon Prime order.
        /// </summary>
        public bool? IsPrime { get; set; }

        /// <summary>
        /// Indicates that the order has a Premium Shipping Service Level Agreement. For more information about Premium Shipping orders, see "Premium Shipping Options" in the Seller Central Help for your marketplace.
        /// </summary>
        public bool? IsPremiumOrder { get; set; }
    }
}
