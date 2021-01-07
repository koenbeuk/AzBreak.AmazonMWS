using AzBreak.AmazonMWS.Core;

namespace AzBreak.AmazonMWS.Feeds
{
    public class FeedType : AmazonMWSEnumeration
    {
        public static implicit operator FeedType(string value) => new FeedType { Value = value };

        #region Product and inventory feeds

        public const string ProductFeed = "_POST_PRODUCT_DATA_";
        public const string InventoryFeed = "_POST_INVENTORY_AVAILABILITY_DATA_";
        public const string OverridesFeed = "_POST_PRODUCT_OVERRIDES_DATA_";
        public const string PricingFeed = "_POST_PRODUCT_PRICING_DATA_";
        public const string ProductImagesFeed = "_POST_PRODUCT_IMAGE_DATA_";
        public const string RelationshipsFeed = "_POST_PRODUCT_RELATIONSHIP_DATA_";
        public const string FlatFileInventoryLoaderFeed = "_POST_FLAT_FILE_INVLOADER_DATA_";
        public const string FlatFileListingsFeed = "_POST_FLAT_FILE_LISTINGS_DATA_";
        public const string FlatFileBookLoaderFeed = "_POST_FLAT_FILE_BOOKLOADER_DATA_";
        public const string FileMusicLoaderFeed = "_POST_FLAT_FILE_CONVERGENCE_LISTINGS_DATA_";
        public const string FlatFileVideoLoaderFeed = "_POST_FLAT_FILE_LISTINGS_DATA_";
        public const string FlatFilePriceQuantityUpdateFeed = "_POST_FLAT_FILE_PRICEANDQUANTITYONLY_UPDATE_DATA_";
        public const string UIEEInventoryFeed = "_POST_UIEE_BOOKLOADER_DATA_";
        public const string ACES3_0DataFeed = "_POST_STD_ACES_DATA_";

        #endregion

        #region Order feeds

        public const string OrderAcknowledgementFeed = "_POST_ORDER_ACKNOWLEDGEMENT_DATA_";
        public const string OrderAdjustmentsFeed = "_POST_PAYMENT_ADJUSTMENT_DATA_";
        public const string OrderFulfillmentFeed = "_POST_ORDER_FULFILLMENT_DATA_";
        public const string InvoiceConfirmationFeed = "_POST_INVOICE_CONFIRMATION_DATA_";
        public const string FlatFileOrderAcknowledgementFeed = "_POST_FLAT_FILE_ORDER_ACKNOWLEDGEMENT_DATA_";
        public const string FlatFileOrderAdjustmentsFeed = "_POST_FLAT_FILE_PAYMENT_ADJUSTMENT_DATA_";
        public const string FlatFileOrderFulfillmentFeed = "_POST_FLAT_FILE_FULFILLMENT_DATA_";
        public const string FlatFileInvoiceConfirmationFeed = "_POST_FLAT_FILE_INVOICE_CONFIRMATION_DATA_";

        #endregion

        #region Fulfillment by Amazon (FBA) feeds

        public const string FBAFulfillmentOrderFeed = "_POST_FULFILLMENT_ORDER_REQUEST_DATA_";
        public const string FBAFulfillmentOrderCancellationFeed = "_POST_FULFILLMENT_ORDER_CANCELLATION_REQUEST_DATA_";
        public const string FBAInboundShipmentCartonInformationFeed = "_POST_FBA_INBOUND_CARTON_CONTENTS_";
        public const string FlatFileFBAFulfillmentOrderFeed = "_POST_FLAT_FILE_FULFILLMENT_ORDER_REQUEST_DATA_";
        public const string FlatFileFBAFulfillmentOrderCancellationFeed = "_POST_FLAT_FILE_FULFILLMENT_ORDER_CANCELLATION_REQUEST_DATA_";
        public const string FlatFileFBACreateInboundShipmentPlanFeed = "_POST_FLAT_FILE_FBA_CREATE_INBOUND_PLAN_";
        public const string FlatFileFBAUpdateInboundShipmentPlanFeed = "_POST_FLAT_FILE_FBA_UPDATE_INBOUND_PLAN_";
        public const string FlatFileFBACreateRemovalFeed = "_POST_FLAT_FILE_FBA_CREATE_REMOVAL_";

        #endregion
    }
}