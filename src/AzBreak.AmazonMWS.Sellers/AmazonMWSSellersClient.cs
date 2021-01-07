using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AzBreak.AmazonMWS.Core;
using AzBreak.AmazonMWS.Core.Internal;

namespace AzBreak.AmazonMWS.Sellers
{
    public class AmazonMWSSellersClient : IAmazonMWSSellersClient
    {
        const string resourceName = "Sellers";
        const string version = "2011-07-01";

        readonly IAmazonMWSChannel channel;

        public AmazonMWSSellersClient(IAmazonMWSChannel channel)
        {
            this.channel = channel ?? throw new ArgumentNullException(nameof(channel));
        }

        public Task<Response<ListMarketplaceParticipationsResult>> ListMarketplaceParticipations(AmazonMWSClientOptions clientOptions = null, CancellationToken cancellationToken = default)
            => channel.Execute<ListMarketplaceParticipationsResult>(new Request { Resource = resourceName, Version = version, Action = nameof(ListMarketplaceParticipations), ClientOptions = clientOptions }, cancellationToken);

        public Task<Response<ListMarketplaceParticipationsResult>> ListMarketplaceParticipationsByNextToken(string nextToken, AmazonMWSClientOptions clientOptions = null, CancellationToken cancellationToken = default)
            => channel.Execute<ListMarketplaceParticipationsResult>(new Request { Resource = resourceName, Version = version, Action = nameof(ListMarketplaceParticipationsByNextToken), Parameters = new ParameterDictionaryBuilder().Add("NextToken", nextToken).Parameters, ClientOptions = clientOptions }, cancellationToken);
    }
}
