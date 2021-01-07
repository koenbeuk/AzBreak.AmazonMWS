using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace AzBreak.AmazonMWS.Core.RetryPolicies
{
    public class ThrottleAndNetworkErrorExecutionRetryPolicy : IExecutionRetryPolicy
    {
        readonly IExecutionRetryPolicy networkErrorExecutionRetryPolicy;
        readonly IExecutionRetryPolicy throttleExecutionRetryPolicy;

        public ThrottleAndNetworkErrorExecutionRetryPolicy(IOptionsSnapshot<RetryPolicyOptions> options, ILoggerFactory loggerFactory)
        {
            this.networkErrorExecutionRetryPolicy = new NetworkErrorExecutionRetryPolicy(options, loggerFactory);
            this.throttleExecutionRetryPolicy = new ThrottleExecutionRetryPolicy(options, loggerFactory);
        }

        public Task<TResponse> Execute<TResponse>(Request request, CancellationToken cancellationToken, Func<Request, CancellationToken, Task<TResponse>> invoke) where TResponse : Response
        {
            return this.throttleExecutionRetryPolicy.Execute(request, cancellationToken, (innerRequest, innerCancellationToken) =>
            {
                return this.networkErrorExecutionRetryPolicy.Execute(innerRequest, innerCancellationToken, invoke);
            });
        }
    }
}
