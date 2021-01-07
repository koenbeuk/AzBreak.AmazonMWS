using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace AzBreak.AmazonMWS.Core.RetryPolicies
{
    public class NetworkErrorExecutionRetryPolicy : IExecutionRetryPolicy
    {
        private readonly IOptionsSnapshot<RetryPolicyOptions> options;
        private readonly ILogger<NetworkErrorExecutionRetryPolicy> logger;

        public NetworkErrorExecutionRetryPolicy(IOptionsSnapshot<RetryPolicyOptions> options, ILoggerFactory loggerFactory)
        {
            this.options = options ?? throw new ArgumentNullException(nameof(options));
            this.logger = loggerFactory.CreateLogger<NetworkErrorExecutionRetryPolicy>();
        }

        public Task<TResponse> Execute<TResponse>(Request request, CancellationToken cancellationToken, Func<Request, CancellationToken, Task<TResponse>> invoke)
            where TResponse : Response 
            => this.ExecuteInternal(request, cancellationToken, invoke, 1, this.options.Value.InitialRetryDelay);

        async Task<TResponse> ExecuteInternal<TResponse>(Request request, CancellationToken cancellationToken, Func<Request, CancellationToken, Task<TResponse>> invoke, int attempt, TimeSpan retryDelay)
            where TResponse : Response
        {
            cancellationToken.ThrowIfCancellationRequested();

            var attempts = options.Value.RetryAttempts;
            logger.LogTrace("Executing attempt: {attempt}/{attempts}", attempt, attempts);

            try
            {
                var response = await invoke(request, cancellationToken);
                logger.LogTrace("Executed attempt: {attempt}/{attempts}", attempt, attempts);

                return response;
            }
            catch (SocketException ex) when (attempt <= this.options.Value.RetryAttempts)
            {
                logger.LogWarning("Execution attempt: {attempt}/{attempts} failed with error: {error}, retrying in: {retryDelay}", attempt, attempts, ex.Message, retryDelay);

                await Task.Delay(retryDelay);

                return await ExecuteInternal(request,
                    cancellationToken,
                    invoke,
                    attempt + 1,
                    this.options.Value.ExponentialBackoff ? retryDelay.Add(retryDelay) : retryDelay);
            }
        }
    }
}
