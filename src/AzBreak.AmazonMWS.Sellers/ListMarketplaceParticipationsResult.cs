using System.Collections.Generic;
using System.Xml.Serialization;

namespace AzBreak.AmazonMWS.Sellers
{
    public class ListMarketplaceParticipationsResult
    {
        /// <summary>
        /// A generated string used to pass information to your next request. If NextToken is returned, pass the value of NextToken to ListMarketplaceParticipationsByNextToken. If NextToken is not returned, there are no more marketplaces and participations to return.
        /// </summary>
        public string NextToken { get; set; }

        /// <summary>
        /// Detailed information that is specific to a seller in a Marketplace.
        /// </summary>
        public List<Participation> ListParticipations { get; set; }

        /// <summary>
        /// Detailed information about an Amazon market where a seller can list items for sale and customers can view and purchase items.
        /// </summary>
        public List<Marketplace> ListMarketplaces { get; set; }
    }
}