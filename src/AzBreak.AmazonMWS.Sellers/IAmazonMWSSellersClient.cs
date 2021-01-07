using AzBreak.AmazonMWS.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AzBreak.AmazonMWS.Sellers
{
    /// <summary>
    /// The Amazon MWS Sellers API section of the Amazon Marketplace Web Service (Amazon MWS) API lets sellers retrieve information about their seller account, such as the marketplaces they participate in. Along with listing the marketplaces that a seller can sell in, the API also provides additional information about the marketplace such as the default language and the default currency. The API also provides seller-specific information such as whether the seller has suspended listings in that marketplace.
    /// </summary>
    public interface IAmazonMWSSellersClient
    {
        /// <summary>
        /// Returns a list of marketplaces that the seller submitting the request can sell in, and a list of participations that include seller-specific information in that marketplace.	
        /// </summary>
        Task<Response<ListMarketplaceParticipationsResult>> ListMarketplaceParticipations(AmazonMWSClientOptions clientOptions = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Returns the next page of marketplaces and participations using the NextToken.
        /// </summary>
        /// <remarks>
        /// The ListMarketplaceParticipationsByNextToken operation returns the next page of marketplaces and participations using the NextToken value that was returned by your previous request to either ListMarketplaceParticipations or ListMarketplaceParticipationsByNextToken. If NextToken is not returned, there are no more pages to return.</remarks>
        Task<Response<ListMarketplaceParticipationsResult>> ListMarketplaceParticipationsByNextToken(string nextToken, AmazonMWSClientOptions clientOptions = null, CancellationToken cancellationToken = default);
    }
}
