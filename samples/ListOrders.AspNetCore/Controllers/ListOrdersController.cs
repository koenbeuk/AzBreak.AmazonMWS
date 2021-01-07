using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AzBreak.AmazonMWS.Orders;
using System.Threading;
using AzBreak.AmazonMWS;

namespace ListOrders.AspNetCore.Controllers
{
    [Route("api/[controller]")]
    public class ListOrdersController : Controller
    {
        private readonly IAmazonMWSOrdersClient ordersClient;

        public ListOrdersController(IAmazonMWSOrdersClient ordersClient)
        {
            this.ordersClient = ordersClient;
        }

        // GET api/values
        [HttpGet]
        public async Task<IActionResult> Get(CancellationToken cancellationToken)
        {
            var ordersResponse = await ordersClient.ListOrders(new ListOrdersRequest {
                MarketplaceIds = new[] { AmazonMWSDefaultMarketplace.UK },
                CreatedAfter = DateTime.UtcNow.AddMonths(-3)
            }, cancellationToken: cancellationToken);
            ordersResponse.EnsureSuccess();

            return Ok(ordersResponse.Result);
        }

    }
}
