using AzBreak.AmazonMWS.Core;

namespace AzBreak.AmazonMWS.Reports
{
    public sealed class ReportType : AmazonMWSEnumeration
    {
        public static implicit operator ReportType(string value) => new ReportType { Value = value };

        #region Inventory Reports

        /// <summary>
        /// Tab-delimited flat file open listings report that contains a summary of the seller's product listings with the price and quantity for each SKU. For Marketplace and Seller Central sellers.
        /// This report accepts the following ReportOptions values:
        ///     Custom - A Boolean value that indicates whether a custom report is returned.For more information, see Custom Inventory Reports.Default: false. URL-encoded example: ReportOptions= custom % 3Dtrue. This functionality is only available in the Canada, US, UK, and India marketplaces.
        /// </summary>
        public const string InventoryReport = "_GET_FLAT_FILE_OPEN_LISTINGS_DATA_";

        /// <summary>
        /// Tab-delimited flat file detailed all listings report. For Marketplace and Seller Central sellers.
        /// This report accepts the following ReportOptions values:
        ///     Custom - A Boolean value that indicates whether a custom report is returned.For more information, see Custom Inventory Reports.Default: false. URL-encoded example: ReportOptions= custom % 3Dtrue. This functionality is only available in the Canada, US, UK, and India marketplaces
        /// </summary>
        public const string AllListingsReport = "_GET_MERCHANT_LISTINGS_ALL_DATA_";

        /// <summary>
        /// Tab-delimited flat file detailed active listings report. For Marketplace and Seller Central sellers.
        /// </summary>
        public const string ActiveListingsReport = "_GET_MERCHANT_LISTINGS_DATA_";

        /// <summary>
        /// Tab-delimited flat file detailed inactive listings report. For Marketplace and Seller Central sellers.
        /// </summary>
        public const string InactiveListingsReport = "_GET_MERCHANT_LISTINGS_INACTIVE_DATA_";

        /// <summary>
        /// Tab-delimited flat file open listings report.
        /// This report accepts the following ReportOptions values:
        ///     Custom - A Boolean value that indicates whether a custom report is returned.For more information, see Custom Inventory Reports.Default: false. URL-encoded example: ReportOptions= custom % 3Dtrue. This functionality is only available in the Canada, US, UK, and India marketplaces.
        /// </summary>
        public const string OpenListingsReport = "_GET_MERCHANT_LISTINGS_DATA_BACK_COMPAT_";

        /// <summary>
        /// Tab-delimited flat file active listings report that contains only the SKU, ASIN, Price, and Quantity fields for items that have a quantity greater than zero. For Marketplace and Seller Central sellers.
        /// </summary>
        public const string OpenListingsReportLite = "_GET_MERCHANT_LISTINGS_DATA_LITE_";

        /// <summary>
        /// Tab-delimited flat file active listings report that contains only the SKU and Quantity fields for items that have a quantity greater than zero. For Marketplace and Seller Central sellers.
        /// </summary>
        public const string OpenListingsReportLiter = "_GET_MERCHANT_LISTINGS_DATA_LITER_";

        /// <summary>
        /// Tab-delimited flat file canceled listings report. For Marketplace and Seller Central sellers.
        /// This report accepts the following ReportOptions values:
        ///     Custom - A Boolean value that indicates whether a custom report is returned.For more information, see Custom Inventory Reports.Default: false. URL-encoded example: ReportOptions= custom % 3Dtrue. This functionality is only available in the Canada, US, UK, and India marketplaces.
        /// </summary>
        public const string CanceledListingsReport = "_GET_MERCHANT_CANCELLED_LISTINGS_DATA_";

        /// <summary>
        /// Tab-delimited flat file sold listings report that contains items sold on Amazon's retail website. For Marketplace and Seller Central sellers.
        /// </summary>
        public const string SoldListingsReport = "_GET_CONVERGED_FLAT_FILE_SOLD_LISTINGS_DATA_";

        /// <summary>
        /// Tab-delimited flat file listing quality and suppressed listing report that contains your listing information that is incomplete or incorrect. For Marketplace and Seller Central sellers.
        /// </summary>
        public const string ListingQualityAndSuppressedListingReport = "_GET_MERCHANT_LISTINGS_DEFECT_DATA_";

        /// <summary>
        /// Tab-delimited flat file report that contains enrollment status and eligibility information for the Pan-European FBA program for each of the seller's Amazon-fulfilled listings. This report is only available to FBA sellers in the Spain, UK, France, Germany, and Italy marketplaces. For more information, see Pan-European Eligibility in the Seller Central Help.
        /// </summary>
        public const string PanEuropeanEligibilityFBAASINs = "_GET_PAN_EU_OFFER_STATUS_";

        /// <summary>
        /// Tab-delimited flat file report that contains eligibility information for the Pan-European FBA Program for each of the seller's self-fulfilled listings. Self-fulfilled listings are not allowed in the Pan-European FBA program, and this report can help sellers determine whether to convert any of their self-fulfilled listings to Amazon-fulfilled listings in order to enroll them in the program. This report is only available in the Spain, UK, France, Germany, and Italy marketplaces. For more information, see Pan-European Eligibility in the Seller Central Help.
        /// </summary>
        public const string PanEuropeanEligibilitySelffulfilledASINs = "_GET_MFN_PAN_EU_OFFER_STATUS_";

        #endregion

        #region Order Reports

        /// <summary>
        /// Tab-delimited flat file report that contains only orders that are not confirmed as shipped. Can be requested or scheduled. For Marketplace and Seller Central sellers.
        /// This report accepts the following ReportOptions values:
        ///     ShowSalesChannel - A Boolean value that indicates whether an additional column is added to the report that shows the sales channel.Default: false. URL-encoded example: ReportOptions=ShowSalesChannel%3Dtrue
        /// </summary>
        public const string UnshippedOrdersReport = "_GET_FLAT_FILE_ACTIONABLE_ORDER_DATA_";

        /// <summary>
        /// Scheduled XML order report. For Seller Central sellers only.
        /// You can only schedule one _GET_ORDERS_DATA_ or _GET_FLAT_FILE_ORDERS_DATA_ report at a time.If you have one of these reports scheduled and you schedule a new report, the existing report will be canceled.
        /// </summary>
        public const string ScheduledXMLOrderReport = "_GET_ORDERS_DATA_";

        /// <summary>
        /// Tab-delimited flat file order report that can be requested or scheduled. The report shows orders from the previous 60 days. For Marketplace and Seller Central sellers.
        /// Seller Central sellers can only schedule one _GET_ORDERS_DATA_ or _GET_FLAT_FILE_ORDERS_DATA_ report at a time.If you have one of these reports scheduled and you schedule a new report, the existing report will be canceled.
        /// Marketplace sellers can only schedule one _GET_FLAT_FILE_ORDERS_DATA_ or _GET_CONVERGED_FLAT_FILE_ORDER_REPORT_DATA_ report at a time. If you have one of these reports scheduled and you schedule a new report, the existing report will be canceled.
        /// Note: The format of this report will differ slightly depending on whether it is scheduled or requested.
        /// This report accepts the following ReportOptions values:
        ///     ShowSalesChannel - A Boolean value that indicates whether an additional column is added to the report that shows the sales channel.Default: false. URL-encoded example: ReportOptions= ShowSalesChannel % 3Dtrue
        /// </summary>
        public const string RequestedOrScheduledFlatFileOrderReport = "_GET_FLAT_FILE_ORDERS_DATA_";

        /// <summary>
        /// Tab-delimited flat file order report that can be requested or scheduled. For Marketplace sellers only.
        /// You can only schedule one _GET_FLAT_FILE_ORDERS_DATA_ or _GET_CONVERGED_FLAT_FILE_ORDER_REPORT_DATA_ report at a time.If you have one of these reports scheduled and you schedule a new report, the existing report will be canceled.
        /// Note: The format of this report will differ slightly depending on whether it is scheduled or requested.For example, the format for the dates will differ, and the ship-method column is only returned when the report is requested.
        /// This report accepts the following ReportOptions values:
        ///     ShowSalesChannel - A Boolean value that indicates whether an additional column is added to the report that shows the sales channel.Default: false. URL-encoded example: ReportOptions= ShowSalesChannel % 3Dtrue
        /// </summary>
        public const string FlatFileOrderReport = "_GET_CONVERGED_FLAT_FILE_ORDER_REPORT_DATA_";

        #endregion

        #region Order Tracking Reports

        /// <summary>
        /// Tab-delimited flat file report that shows all orders updated in the specified period. Cannot be scheduled. For all sellers.
        /// </summary>
        public const string FlatFileOrdersByLastUpdateReport = "_GET_FLAT_FILE_ALL_ORDERS_DATA_BY_LAST_UPDATE_";

        /// <summary>
        /// Tab-delimited flat file report that shows all orders that were placed in the specified period. Cannot be scheduled. For all sellers.
        /// </summary>
        public const string FlatFileOrdersByOrderDateReport = "_GET_FLAT_FILE_ALL_ORDERS_DATA_BY_ORDER_DATE_";

        /// <summary>
        /// XML report that shows all orders updated in the specified period. Cannot be scheduled. For all sellers.
        /// </summary>
        public const string XMLOrdersByLastUpdateReport = "_GET_XML_ALL_ORDERS_DATA_BY_LAST_UPDATE_";

        /// <summary>
        /// XML report that shows all orders that were placed in the specified period. Cannot be scheduled. For all sellers.
        /// </summary>
        public const string XMLOrdersByOrderDateReport = "_GET_XML_ALL_ORDERS_DATA_BY_ORDER_DATE_";

        #endregion

        #region Pending Order Reports

        /// <summary>
        /// Tab-delimited flat file report that can be requested or scheduled that shows all pending orders. For all sellers.
        /// </summary>
        public const string FlatFilePendingOrdersReport = "_GET_FLAT_FILE_PENDING_ORDERS_DATA_";

        /// <summary>
        /// XML report that can be requested or scheduled that shows all pending orders. Can only be scheduled using Amazon MWS.
        /// </summary>
        public const string XMLPendingOrdersReport = "_GET_PENDING_ORDERS_DATA_";

        /// <summary>
        /// Flat file report that can be requested or scheduled that shows all pending orders. For Marketplace sellers.
        /// </summary>
        public const string ConvergedFlatFilePendingOrdersReport = "_GET_CONVERGED_FLAT_FILE_PENDING_ORDERS_DATA_";

        #endregion

        #region Performance Reports

        /// <summary>
        /// Tab-delimited flat file that returns negative and neutral feedback (one to three stars) from buyers who rated your seller performance. For all sellers.
        /// </summary>
        public const string FlatFileFeedbackReport = "_GET_SELLER_FEEDBACK_DATA_";

        /// <summary>
        /// XML file that contains the individual performance metrics data from the Seller Central dashboard. For all sellers.
        /// </summary>
        public const string XMLCustomerMetricsReport = "_GET_V1_SELLER_PERFORMANCE_REPORT_";

        #endregion

        #region Settlement Reports

        /// <summary>
        /// Tab-delimited flat file settlement report that is automatically scheduled by Amazon; it cannot be requested through RequestReport. For all sellers.
        /// </summary>
        public const string FlatFileSettlementReport = "_GET_V2_SETTLEMENT_REPORT_DATA_FLAT_FILE_";

        /// <summary>
        /// XML file settlement report that is automatically scheduled by Amazon; it cannot be requested through RequestReport. For Seller Central sellers only.
        /// </summary>
        public const string XMLSettlementReport = "_GET_V2_SETTLEMENT_REPORT_DATA_XML_";

        /// <summary>
        /// Tab-delimited flat file alternate version of the Flat File Settlement Report that is automatically scheduled by Amazon; it cannot be requested through RequestReport. Price columns are condensed into three general purpose columns: amounttype, amountdescription, and amount. For Seller Central sellers only.
        /// </summary>
        public const string FlatFileV2SettlementReport = "_GET_V2_SETTLEMENT_REPORT_DATA_FLAT_FILE_V2_";

        #endregion

        #region Fulfillment By Amazon (FBA) Reports

        /// <summary>
        /// Tab-delimited flat file. Contains detailed order/shipment/item information including price, address, and tracking data. You can request up to one month of data in a single report. Content updated near real-time in Europe (EU), Japan, and North America (NA). In China, content updated daily. For FBA sellers only. For Marketplace and Seller Central sellers.
        /// Note: In Japan, EU, and NA, in most cases, there will be a delay of approximately one to three hours from the time a fulfillment order ships and the time the items in the fulfillment order appear in the report.In some rare cases there could be a delay of up to 24 hours.
        /// </summary>
        public const string FBAAmazonFulfilledShipmentsReport = "_GET_AMAZON_FULFILLED_SHIPMENTS_DATA_";

        /// <summary>
        /// Tab-delimited flat file. Returns all orders updated in the specified date range regardless of fulfillment channel or shipment status. This report is intended for order tracking, not to drive your fulfillment process; it does not include customer identifying information and scheduling is not supported. For all sellers.
        /// </summary>
        public const string FlatFileAllOrdersReportByLastUpdate = "_GET_FLAT_FILE_ALL_ORDERS_DATA_BY_LAST_UPDATE_";

        /// <summary>
        /// Tab-delimited flat file. Returns all orders placed in the specified date range regardless of fulfillment channel or shipment status. This report is intended for order tracking, not to drive your fulfillment process; it does not include customer identifying information and scheduling is not supported. For all sellers.
        /// </summary>
        public const string FlatFileAllOrdersReportByOrderDate = "_GET_FLAT_FILE_ALL_ORDERS_DATA_BY_ORDER_DATE_";

        /// <summary>
        /// XML file order report that returns all orders updated in the specified date range regardless of fulfillment channel or shipment status. This report is intended for order tracking, not to drive your fulfillment process; it does not include customer identifying information and scheduling is not supported. For all sellers.
        /// </summary>
        public const string XMLAllOrdersReportByLastUpdate = "_GET_XML_ALL_ORDERS_DATA_BY_LAST_UPDATE_";

        /// <summary>
        /// XML file order report that returns all orders placed in the specified date range regardless of fulfillment channel or shipment status. This report is intended for order tracking, not to drive your fulfillment process; it does not include customer identifying information and scheduling is not supported. For all sellers.
        /// </summary>
        public const string XMLAllOrdersReportByOrderDate = "_GET_XML_ALL_ORDERS_DATA_BY_ORDER_DATE_";

        /// <summary>
        /// Tab-delimited flat file. Contains condensed item level data on shipped FBA customer orders including price, quantity, and ship to location. Content updated near real-time in Europe (EU), Japan, and North America (NA). In China, content updated daily. For FBA sellers only. For Marketplace and Seller Central sellers.
        /// Note: In Japan, EU, and NA, in most cases, there will be a delay of approximately one to three hours from the time a fulfillment order ships and the time the items in the fulfillment order appear in the report.In some rare cases there could be a delay of up to 24 hours.
        /// </summary>
        public const string FBACustomerShipmentSalesReport = "_GET_FBA_FULFILLMENT_CUSTOMER_SHIPMENT_SALES_DATA_";

        /// <summary>
        /// Tab-delimited flat file. Contains promotions applied to FBA customer orders sold through Amazon; e.g. Super Saver Shipping. Content updated daily. This report is only available to FBA sellers in the North America (NA) region. For Marketplace and Seller Central sellers.
        /// </summary>
        public const string FBAPromotionsReport = "_GET_FBA_FULFILLMENT_CUSTOMER_SHIPMENT_SALES_DATA_";

        /// <summary>
        /// Tab-delimited flat file for tax-enabled US sellers. This report contains data through February 28, 2013. All new transaction data can be found in the Sales Tax Report. For FBA sellers only. For Marketplace and Seller Central sellers.
        /// </summary>
        public const string FBACustomerTaxes = "_GET_FBA_FULFILLMENT_CUSTOMER_TAXES_DATA_";

        #endregion

        #region FBA Inventory Reports

        /// <summary>
        /// Tab-delimited flat file. Content updated in near real-time. For FBA sellers only. For Marketplace and Seller Central sellers.
        /// </summary>
        public const string FBAAmazonFulfilledInventoryReport = "_GET_AFN_INVENTORY_DATA_";

        /// <summary>
        /// Tab-delimited flat file. Contains quantity available for local fulfillment by country, helping Multi-Country Inventory sellers in Europe track their FBA inventory. Content updated in near-real time. This report is only available to FBA sellers in European (EU) marketplaces. For Seller Central sellers.
        /// </summary>
        public const string FBAMultiCountryInventoryReport = "_GET_AFN_INVENTORY_DATA_BY_COUNTRY_";

        /// <summary>
        /// Tab-delimited flat file. Contains historical daily snapshots of your available inventory in Amazon’s fulfillment centers including quantity, location and disposition. Content updated daily. For FBA sellers only. For Marketplace and Seller Central sellers.
        /// </summary>
        public const string FBADailyInventoryHistoryReport = "_GET_FBA_FULFILLMENT_CURRENT_INVENTORY_DATA_";

        /// <summary>
        /// Tab-delimited flat file. Contains historical monthly snapshots of your available inventory in Amazon’s fulfillment centers including average and end-of-month quantity, location and disposition. Content updated daily. For FBA sellers only. For Marketplace and Seller Central sellers.
        /// </summary>
        public const string FBAMonthlyInventoryHistoryReport = "_GET_FBA_FULFILLMENT_MONTHLY_INVENTORY_DATA_";

        /// <summary>
        /// Tab-delimited flat file. Contains inventory that has completed the receive process at Amazon’s fulfillment centers. Content updated daily. For FBA sellers only. For Marketplace and Seller Central sellers.
        /// </summary>
        public const string FBAReceivedInventoryReport = "_GET_FBA_FULFILLMENT_INVENTORY_RECEIPTS_DATA_";

        /// <summary>
        /// Tab-delimited flat file. Provides data about the number of reserved units in your inventory. Content updated in near real-time. For FBA sellers only. For Marketplace and Seller Central sellers.
        /// </summary>
        public const string FBAReservedInventoryReport = "_GET_RESERVED_INVENTORY_DATA_";

        /// <summary>
        /// Tab-delimited flat file. Contains history of inventory events (e.g. receipts, shipments, adjustments etc.) by SKU and Fulfillment Center. Content updated daily. For FBA sellers only. For Marketplace and Seller Central sellers.
        /// </summary>
        public const string FBAInventoryEventDetailReport = "_GET_FBA_FULFILLMENT_INVENTORY_SUMMARY_DATA_";

        /// <summary>
        /// Tab-delimited flat file. Contains corrections and updates to your inventory in response to issues such as damage, loss, receiving discrepancies, etc. Content updated daily. For FBA sellers only. For Marketplace and Seller Central sellers.
        /// </summary>
        public const string FBAInventoryAdjustmentsReport = "_GET_FBA_FULFILLMENT_INVENTORY_ADJUSTMENTS_DATA_";

        /// <summary>
        /// Tab-delimited flat file. Contains information about inventory age, condition, sales volume, weeks of cover, and price. Content updated daily. For FBA Sellers only. For Marketplace and Seller Central sellers.
        /// </summary>
        public const string FBAInventoryHealthReport = "_GET_FBA_FULFILLMENT_INVENTORY_HEALTH_DATA_";

        /// <summary>
        /// Tab-delimited flat file. Contains current details of active (not archived) inventory including condition, quantity and volume. Content updated in near real-time. For FBA sellers only. For Marketplace and Seller Central sellers.
        /// </summary>
        public const string FBAManageInventory = "_GET_FBA_MYI_UNSUPPRESSED_INVENTORY_DATA_";

        /// <summary>
        /// Tab-delimited flat file. Contains current details of all (including archived) inventory including condition, quantity and volume. Content updated in near real-time. For FBA sellers only. For Marketplace and Seller Central sellers.
        /// </summary>
        public const string FBAManageInventoryArchived = "_GET_FBA_MYI_ALL_INVENTORY_DATA_";

        /// <summary>
        /// Tab delimited flat file. Contains historical data of shipments that crossed country borders. These could be export shipments or shipments using Amazon's European Fulfillment Network (note that Amazon's European Fulfillment Network is for Seller Central sellers only). Content updated daily. For Marketplace and Seller Central sellers.
        /// </summary>
        public const string FBACrossBorderInventoryMovementReport = "_GET_FBA_FULFILLMENT_CROSS_BORDER_INVENTORY_MOVEMENT_DATA_";

        /// <summary>
        /// Tab delimited flat file. Provides recommendations on products to restock, suggested order quantities, and reorder dates. For more information, see Restock Inventory Report. Content updated in near real-time. This report is only available to FBA sellers in the US marketplace.
        /// </summary>
        public const string RestockInventoryReport = "_GET_RESTOCK_INVENTORY_RECOMMENDATIONS_REPORT_";

        /// <summary>
        /// Tab-delimited flat file. Contains inbound shipment problems by product and shipment. Content updated daily. For Marketplace and Seller Central sellers. This report is only available to FBA sellers.
        /// </summary>
        public const string FBAInboundPerformanceReport = "_GET_FBA_FULFILLMENT_INBOUND_NONCOMPLIANCE_DATA_";

        /// <summary>
        /// Tab-delimited flat file. Contains a breakdown of inventory in stranded status, including recommended actions. Content updated in near real-time. This report is only available to FBA sellers in the US, India, and Japan marketplaces. For more information, see Stranded Inventory Report.
        /// </summary>
        public const string FBAStrandedInventoryReport = "_GET_STRANDED_INVENTORY_UI_DATA_";

        /// <summary>
        /// Tab-delimited flat file. Contains a list of stranded inventory. Update the listing information in this report file and then submit the file using the Flat File Inventory Loader Feed (_POST_FLAT_FILE_INVLOADER_DATA_) of the Feeds API section. Content updated in near real-time. This report is only available to FBA sellers in the US, India, and Japan marketplaces. For more information, see Bulk Fix Stranded Inventory Report.
        /// </summary>
        public const string FBABulkFixStrandedInventoryReport = "_GET_STRANDED_INVENTORY_LOADER_DATA_";

        /// <summary>
        /// Tab-delimited flat file. Indicates the age of inventory, which helps sellers take action to avoid paying the Long Term Storage Fee. Content updated daily. This report is only available to FBA sellers in the US, India, and Japan marketplaces. For more information, see Inventory Age Report.
        /// </summary>
        public const string FBAInventoryAgeReport = "_GET_FBA_INVENTORY_AGED_DATA_";

        /// <summary>
        /// Tab-delimited flat file. Contains listings with excess inventory, which helps sellers take action to sell through faster. Content updated in near real-time. This report is only available to FBA sellers in the US, India, and Japan marketplaces. For more information, see Excess Inventory Report.
        /// </summary>
        public const string FBAManageExcessInventoryReport = "_GET_EXCESS_INVENTORY_DATA_";

        #endregion

        #region FBA Payments Reports

        /// <summary>
        /// Tab-delimited flat file. Contains the estimated Amazon Selling and Fulfillment Fees for your FBA inventory with active offers. The content is updated at least once every 72 hours. To successfully generate a report, specify the StartDate parameter of a minimum 72 hours prior to NOW and EndDate to NOW. For FBA sellers in the NA and EU only. For Marketplace and Seller Central sellers.
        /// </summary>
        public const string FBAFeePreviewReport = "_GET_FBA_ESTIMATED_FBA_FEES_TXT_DATA_";

        /// <summary>
        /// Tab-delimited flat file. Contains itemized details of your inventory reimbursements including the reason for the reimbursement. Content updated daily. For FBA sellers only. For Marketplace and Seller Central sellers.
        /// </summary>
        public const string FBAReimbursementsReport = "_GET_FBA_REIMBURSEMENTS_DATA_";

        #endregion

        #region FBA Customer Concessions Reports

        /// <summary>
        /// Tab-delimited flat file. Contains customer returned items received at an Amazon fulfillment center, including Return Reason and Disposition. Content updated daily. For FBA sellers only. For Marketplace and Seller Central sellers.
        /// </summary>
        public const string FBAReturnsReport = "_GET_FBA_FULFILLMENT_CUSTOMER_RETURNS_DATA_";

        /// <summary>
        /// Tab-delimited flat file. Contains replacements that have been issued to customers for completed orders. Content updated daily. For FBA sellers only. For Marketplace and Seller Central sellers. Available in the US and China (CN) only.
        /// </summary>
        public const string FBAReplacementsReport = "_GET_FBA_FULFILLMENT_CUSTOMER_SHIPMENT_REPLACEMENT_DATA_";

        #endregion

        #region FBA Removals Reports

        /// <summary>
        /// Tab-delimited flat file. The report identifies sellable items that will be 365 days or older during the next Long-Term Storage cleanup event, if the report is generated within six weeks of the cleanup event date. The report includes both sellable and unsellable items. Content updated daily. For FBA sellers. For Marketplace and Seller Central sellers.
        /// </summary>
        public const string FBARecommendedRemovalReport = "_GET_FBA_RECOMMENDED_REMOVAL_DATA_";

        /// <summary>
        /// Tab-delimited flat file. This report contains all the removal orders, including the items in each removal order, placed during any given time period. This can be used to help reconcile the total number of items requested to be removed from an Amazon fulfillment center with the actual number of items removed along with the status of each item in the removal order. Content updated in near real-time. For FBA sellers. For Marketplace and Seller Central sellers.
        /// </summary>
        public const string FBARemovalOrderDetailReport = "_GET_FBA_FULFILLMENT_REMOVAL_ORDER_DETAIL_DATA_";

        /// <summary>
        /// Tab-delimited flat file. This report provides shipment tracking information for all removal orders and includes the items that have been removed from an Amazon fulfillment center for either a single removal order or for a date range. This report will not include canceled returns or disposed items; it is only for shipment information. Content updated in near real-time. For FBA sellers. For Marketplace and Seller Central sellers.
        /// </summary>
        public const string FBARemovalShipmentDetailReport = "_GET_FBA_FULFILLMENT_REMOVAL_SHIPMENT_DETAIL_DATA_";

        #endregion

        #region Tax Reports

        /// <summary>
        /// Tab-delimited flat file for tax-enabled US sellers. Content updated daily. This report cannot be requested or scheduled. You must generate the report from the Tax Document Library in Seller Central. After the report has been generated, you can download the report using the GetReportList and GetReport operations. For Marketplace and Seller Central sellers.
        /// </summary>
        public const string SalesTaxReport = "_GET_FLAT_FILE_SALES_TAX_DATA_";

        /// <summary>
        /// Comma-separated flat file report that provides detailed value-added tax (VAT) calculation information for buyer shipments, returns, and refunds. This report is only available in the Germany, Spain, Italy, France, and UK marketplaces.
        /// </summary>
        public const string AmazonVATCalculationReport = "_SC_VAT_TAX_REPORT_";

        /// <summary>
        /// Tab-delimited flat file report that provides detailed information for sales, returns, refunds, cross border inbound and cross border fulfillment center transfers. This report is only available in the Germany, Spain, Italy, France, and UK marketplaces.
        /// </summary>
        public const string AmazonVATTransactionsReport = "_GET_VAT_TRANSACTION_DATA_";

        #endregion

        #region Browse Tree Reports

        /// <summary>
        /// XML report that provides browse tree hierarchy information and node refinement information for the Amazon retail website in any marketplace.
        /// Can be requested or scheduled.For Marketplace and Seller Central sellers.
        /// This report accepts the following ReportOptions values:
        /// MarketplaceId – Specifies the marketplace from which you want browse tree information. Optional.If MarketplaceId is not included in the ReportOptions parameter, the report contains browse tree information from your default marketplace.
        /// Note: You must be registered as a seller in any marketplace that you specify using the MarketplaceId value.Also, your request must be sent to an endpoint that corresponds to the MarketplaceId that you specify. Otherwise the service returns an error. You can find a list of MarketplaceId values and endpoints in the "Amazon MWS endpoints and MarketplaceId values" section of the Amazon MWS Developer Guide.
        ///     RootNodesOnly - Type: xs:boolean.Optional.If true, then the report contains only the root nodes from the marketplace specified using MarketplaceId (or from your default marketplace, if MarketplaceId is not specified). If false, or if RootNodesOnly is not included in the ReportOptions parameter, then the content of the report depends on the value of BrowseNodeId.
        ///     BrowseNodeId – Specifies the top node of the browse tree hierarchy in the report. Optional.If BrowseNodeId is not included in the ReportOptions parameter, and if RootNodesOnly is false or is not included in the ReportOptions parameter, then the report contains the entire browse node hierarchy from the marketplace specified using MarketplaceId (or from your default marketplace, if MarketplaceId is not specified). Note that if you include an invalid BrowseNodeId in your request, the service returns a report that contains no data.
        /// Note: If RootNodesOnly and BrowseNodeId are both included in the ReportOptions parameter, RootNodesOnly takes precedence.
        /// Note: Amazon recommends that you do not include the MarketplaceIdList parameter with calls to the RequestReport operation that request the Browse Tree Report.If there is ever a conflict between a MarketplaceIdList parameter value and the MarketplaceId value of the ReportOptions parameter, the MarketplaceId value takes precedence.
        /// To keep track of which browse nodes change over time, Amazon recommends that each time you request this report you compare it to the last report you requested using the same ReportOptions values.
        /// URL-encoded example: ReportOptions=MarketplaceId%3DATVPDKIKX0DER;BrowseNodeId%3D15706661
        /// The Browse Tree Report is described by the following XSD: https://images-na.ssl-images-amazon.com/images/G/01/mwsportal/doc/en_US/Reports/XSDs/BrowseTreeReport.xsd.
        /// Note: As Amazon updates the Amazon MWS Reports API section, we may update the BrowseTreeReport.xsd schema.Keep this in mind if you choose to use this schema for validation.Monitor an Amazon MWS discussion forum for announcements of updates to the BrowseTreeReport.xsd schema. You can find the Amazon MWS discussion forums here:
        /// Chinese: https://mai.amazon.cn/forums/forum.jspa?forumID=15
        /// English: https://sellercentral.amazon.com/forums/forum.jspa?forumID=35
        /// Japanese: https://sellercentral.amazon.co.jp/forums/forum.jspa?forumID=14
        /// </summary>
        public const string BrowseTreeReport = "_GET_XML_BROWSE_TREE_DATA_";

        #endregion 
    }
}