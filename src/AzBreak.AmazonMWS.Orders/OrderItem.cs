using AzBreak.AmazonMWS.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzBreak.AmazonMWS.Orders
{
    public class OrderItem
    {
        /// <summary>
        /// The Amazon Standard Identification Number (ASIN) of the item
        /// </summary>
        public string ASIN { get; set; }

        /// <summary>
        /// An Amazon-defined order item identifier.	
        /// </summary>
        public string OrderItemId { get; set; }

        /// <summary>
        /// The seller SKU of the item.	
        /// </summary>
        public string SellerSKU { get; set; }

        /// <summary>
        /// Buyer information for custom orders from the Amazon Custom program.	
        /// </summary>
        public BuyerCustomizedInfo BuyerCustomizedInfo { get; set; }

        /// <summary>
        /// The name of the item.	
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// The number of items in the order.	
        /// </summary>
        public int? QuantityOrdered { get; set; }

        /// <summary>
        /// The number of items in the order.	
        /// </summary>
        public int? QuantityShipped { get; set; }

        /// <summary>
        /// The number and value of Amazon Points granted with the purchase of an item (available only in Japan).
        /// </summary>
        /// <remarks>
        /// PointsGranted is a response element only in Japan (JP).
        /// </remarks>
        public PointsGranted PointsGranted { get; set; }

        /// <summary>
        /// The selling price of the order item. Note that an order item is an item and a quantity. This means that the value of ItemPrice is equal to the selling price of the item multiplied by the quantity ordered. Note that ItemPrice excludes ShippingPrice and GiftWrapPrice. For a more detailed explanation of an order item, see Orders API.	
        /// </summary>
        public Money ItemPrice { get; set; }

        /// <summary>
        /// The shipping price of the item.	
        /// </summary>
        public Money ShippingPrice { get; set; }

        /// <summary>
        /// The gift wrap price of the item.	
        /// </summary>
        public Money GiftWrapPrice { get; set; }

        /// <summary>
        /// The tax on the item price.		
        /// </summary>
        public Money ItemTax { get; set; }

        /// <summary>
        /// The tax on the shipping price.		
        /// </summary>
        public Money ShippingTax { get; set; }

        /// <summary>
        /// The tax on the gift wrap price.	
        /// </summary>
        public Money GiftWrapTax { get; set; }

        /// <summary>
        /// The discount on the shipping price.	
        /// </summary>
        public Money ShippingDiscount { get; set; }

        /// <summary>
        /// The total of all promotional discounts in the offer.	
        /// </summary>
        public Money PromotionDiscount { get; set; }

        /// <summary>
        /// A list of PromotionId elements.	
        /// </summary>
        public List<string> PromotionIds { get; set; }

        /// <summary>
        /// The fee charged for COD service.
        /// </summary>
        /// <remarks>
        /// CODFee is a response element only in Japan (JP).
        /// </remarks>
        public Money CODFee { get; set; }

        /// <summary>
        /// The discount on the COD fee.
        /// </summary>
        /// <remarks>
        /// CODFeeDiscount is a response element only in Japan (JP).
        /// </remarks>
        public Money CODFeeDiscount { get; set; }

        /// <summary>
        /// A gift message provided by the buyer.
        /// </summary>
        public string GiftMessageText { get; set; }

        /// <summary>
        /// The gift wrap level specified by the buyer.	
        /// </summary>
        public string GiftWrapLevel { get; set; }

        /// <summary>
        /// Invoice information (available only in China).
        /// </summary>
        public InvoiceData InvoiceData { get; set; }

        /// <summary>
        /// The condition of the item as described by the seller.	
        /// </summary>
        public string ConditionNote { get; set; }

        /// <summary>
        /// The condition of the item.
        /// </summary>
        public ConditionId ConditionId { get; set; }

        /// <summary>
        /// The subcondition of the item.
        /// </summary>
        public ConditionSubtypeId ConditionSubtypeId { get; set; }

        /// <summary>
        /// The start date of the scheduled delivery window in the time zone of the order destination
        /// </summary>
        /// <remarks>
        /// Scheduled delivery is available only in Japan (JP).
        /// </remarks>
        public AmazonMWSDateTime ScheduledDeliveryStartDate { get; set; }

        /// <summary>
        /// The end date of the scheduled delivery window in the time zone of the order destination
        /// </summary>
        /// <remarks>
        /// Scheduled delivery is available only in Japan (JP).
        /// </remarks>
        public AmazonMWSDateTime ScheduledDeliveryEndDate { get; set; }

        /// <summary>
        /// Indicates that the selling price is a special price that is available only for Amazon Business orders. For more information about the Amazon Business Seller Program, see the Amazon Business website.
        /// </summary>
        public PriceDesignation PriceDesignation { get; set; }
    }
}
