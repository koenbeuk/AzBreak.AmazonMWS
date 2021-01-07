using AzBreak.AmazonMWS.Core;
using AzBreak.AmazonMWS.Core.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AzBreak.AmazonMWS.Orders
{
    public sealed class AmazonMWSOrdersClient : IAmazonMWSOrdersClient
    {
        const string resourceName = "Orders";
        const string version = "2013-09-01";

        readonly IAmazonMWSChannel channel;

        public AmazonMWSOrdersClient(IAmazonMWSChannel channel)
        {
            this.channel = channel ?? throw new ArgumentNullException(nameof(channel));
        }

        public Task<Response<ServiceStatusResult>> GetServiceStatus(AmazonMWSClientOptions clientOptions, CancellationToken cancellationToken)
            => channel.Execute<ServiceStatusResult>(new Request { Resource = resourceName, Version = version, Action = "GetServiceStatus", ClientOptions = clientOptions }, cancellationToken);

        public Task<Response<ListOrdersResult>> ListOrders(ListOrdersRequest request, AmazonMWSClientOptions clientOptions, CancellationToken cancellationToken)
            => channel.Execute<ListOrdersResult>(new Request { Resource = resourceName, Version = version, Action = "ListOrders", Parameters = request.ToParametersDictionary(), ClientOptions = clientOptions }, cancellationToken);

        public Task<Response<ListOrdersResult>> ListOrdersByNextToken(string nextToken, AmazonMWSClientOptions clientOptions, CancellationToken cancellationToken)
            => channel.Execute<ListOrdersResult>(new Request { Resource = resourceName, Version = version, Action = "ListOrdersByNextToken", Parameters = new ParameterDictionaryBuilder().Add("NextToken", nextToken).Parameters, ClientOptions = clientOptions }, cancellationToken);

        public Task<Response<GetOrderResult>> GetOrders(GetOrderRequest request, AmazonMWSClientOptions clientOptions, CancellationToken cancellationToken)
            => channel.Execute<GetOrderResult>(new Request { Resource = resourceName, Version = version, Action = "GetOrder", Parameters = request.ToParametersDictionary(), ClientOptions = clientOptions }, cancellationToken);

        public Task<Response<ListOrderItemsResult>> ListOrderItems(string amazonOrderId, AmazonMWSClientOptions clientOptions, CancellationToken cancellationToken)
            => channel.Execute<ListOrderItemsResult>(new Request { Resource = resourceName, Version = version, Action = "ListOrderItems", Parameters = new ParameterDictionaryBuilder().Add("AmazonOrderId", amazonOrderId).Parameters, ClientOptions = clientOptions }, cancellationToken);

        public Task<Response<ListOrderItemsResult>> ListOrderItemsByNextToken(string nextToken, AmazonMWSClientOptions clientOptions, CancellationToken cancellationToken)
            => channel.Execute<ListOrderItemsResult>(new Request { Resource = resourceName, Version = version, Action = "ListOrderItemsByNextToken", Parameters = new ParameterDictionaryBuilder().Add("NextToken", nextToken).Parameters, ClientOptions = clientOptions }, cancellationToken);
    }
}
