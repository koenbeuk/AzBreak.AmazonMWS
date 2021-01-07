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
    public class ThrottleExecutionRetryPolicy : IExecutionRetryPolicy
    {
        private readonly IOptionsSnapshot<RetryPolicyOptions> options;
        private readonly ILogger<ThrottleExecutionRetryPolicy> logger;

        public ThrottleExecutionRetryPolicy(IOptionsSnapshot<RetryPolicyOptions> options, ILoggerFactory loggerFactory)
        {
            this.options = options ?? throw new ArgumentNullException(nameof(options));
            this.logger = loggerFactory.CreateLogger<ThrottleExecutionRetryPolicy>();
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
            var response = await invoke(request, cancellationToken);
            logger.LogTrace("Executed attempt: {attempt}/{attempts}", attempt, attempts);

            if (response.Success == false && response.Error.Code == ErrorCode.RequestThrottled)
            {
                if (attempt <= this.options.Value.RetryAttempts)
                {
                    logger.LogWarning("Execution attempt: {attempt}/{attempts} failed; request was throttled, retrying in: {retryDelay}", attempt, attempts, retryDelay);

                    await Task.Delay(retryDelay);

                    return await ExecuteInternal(request,
                        cancellationToken,
                        invoke,
                        attempt + 1,
                        this.options.Value.ExponentialBackoff ? retryDelay.Add(retryDelay) : retryDelay);
                }
                else
                {
                    logger.LogWarning("Execution attempt: {attempt}/{attempts} failed; request was throttled", attempt, attempts, retryDelay);
                }
            }

            return response;
        }
    }
}
