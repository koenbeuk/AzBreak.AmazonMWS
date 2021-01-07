An alternative (modernized) Amazon MWS client targeting .NET standard. This library was used in a new discontinued project. It may need some work and is currently looking for maintainers.

# Getting started
```csharp
var channel = AmazonMWSChannelFactory.Create(new AmazonMWSClientOptions {
    RegionEndpoint = AmazonMWSDefaultEndpoint.NorthAmerica,
    SellerId = "AIXXXXXXXXX",
    SecretKey = "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX",
    AWSAccessKeyId = "XXXXXXXXXXXXXXXXXXXX"
});
var client = channel.CreateSellersClient();

var result = await client.ListMarketplaceParticipations();
```

Or if you prefer to integrate with Dependency injeciton
```csharp
// In Startup.cs...
public void ConfigureServices(IServiceCollection services)
{
    services.AddMvc();
    services.AddAmazonMWSClients();
    services.Configure<AmazonMWSClientOptions>(Configuration); // default client credentials
}

// In MyController.cs
public class MyController { 

    private readonly IAmazonMWSOrdersClient ordersClient;
    
    public MyController(IAmazonMWSOrdersClient ordersClient) {
        this.ordersClient = ordersClient;
    }

    [HttpGet]
    public async Task<IActionResult> Get(CancellationToken cancellationToken)    {
        var ordersResponse = await ordersClient.ListOrders(new ListOrdersRequest {
            MarketplaceIds = new[] { AmazonMWSDefaultMarketplace.UK },
            CreatedAfter = DateTime.UtcNow.AddMonths(-3)
        }, cancellationToken: cancellationToken);
        ordersResponse.EnsureSuccess();

        return Ok(ordersResponse.Result);
    }
}
```

# Running Samples
All samples require credentials to authenticate against Amazon MWS. 
The easiest way to get started is by editing the `ClientOptions` instance found in the top of the sample. 
Alternatively you can use configure all projects with user secrets:

```
dotnet user-secrets set RegionEndpoint https://mws-eu.amazonservices.com
dotnet user-secrets set SellerId <your seller id>
dotnet user-secrets set SecretKey <your secret key>
dotnet user-secrets set AWSAccessKeyId <your AWS access key>
``` 

User secrets are shared amongst all sample projects
