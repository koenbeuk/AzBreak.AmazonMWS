using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AzBreak.AmazonMWS.Core.RetryPolicies
{
    public interface IExecutionRetryPolicy
    {
        Task<TResponse> Execute<TResponse>(Request request, CancellationToken cancellationToken, Func<Request, CancellationToken, Task<TResponse>> invoke) where TResponse : Response;
    }
}
