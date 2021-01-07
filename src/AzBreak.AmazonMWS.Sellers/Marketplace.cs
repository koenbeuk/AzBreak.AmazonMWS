namespace AzBreak.AmazonMWS.Sellers
{
    public class Marketplace
    {
        /// <summary>
        /// The encrypted marketplace value. Example: ATVPDKIKX0DER
        /// </summary>
        public string MarketplaceId { get; set; }
        /// <summary>
        /// Marketplace name. Example: Amazon.com
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// The ISO 3166-1 alpha-2 format country code of the marketplace. Example: US
        /// </summary>
        public string DefaultCountryCode { get; set; }
        /// <summary>
        /// The ISO 4217 format currency code of the marketplace. Example: USD
        /// </summary>
        public string DefaultCurrencyCode { get; set; }
        /// <summary>
        /// The ISO 639-1 format language code of the marketplace. Example: en_US
        /// </summary>
        public string DefaultLanguageCode { get; set; }
        /// <summary>
        /// The domain name associated with the marketplace. Example: www.amazon.com
        /// </summary>
        public string DomainName { get; set; }
    }
}