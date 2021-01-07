using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AzBreak.AmazonMWS.Core.RetryPolicies;
using AzBreak.AmazonMWS.TestSuite;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace AzBreak.AmazonMWS.Core.Tests.RetryPolicies
{
    [TestClass]
    public class NetworkErrorExecutionRetryPolicyTests
    {
        NetworkErrorExecutionRetryPolicy CreateSubject(RetryPolicyOptions options)
        {
            var optionsSnapshot = Mock.Of<IOptionsSnapshot<RetryPolicyOptions>>(x => x.Value == options);
            var loggerFactory = Mock.Of<ILoggerFactory>(x => x.CreateLogger(It.IsAny<string>()) == Mock.Of<ILogger>());
            return new NetworkErrorExecutionRetryPolicy(optionsSnapshot, loggerFactory);
        }

        async Task<int> RunTest(NetworkErrorExecutionRetryPolicy subject, Func<int, bool> evaluator)
        {
            var attempts = 0;
            await subject.Execute(new Request(), CancellationToken.None, (_1, _2) =>
            {
                attempts += 1;

                var result = evaluator(attempts);
                if (result)
                {
                    return Task.FromResult(ResponseStub.CreateSuccess());
                }
                else
                {
                    throw new SocketException();
                }
            });

            return attempts;
        }

        async Task RunBackoffTest(bool exponential)
        {
            const double delayInSeconds = .01; // large enough to become measurable
            const double delta = .001;
            const int expectedAttempts = 3;

            var delay = TimeSpan.FromSeconds(delayInSeconds);
            var subject = CreateSubject(new RetryPolicyOptions { InitialRetryDelay = delay, RetryAttempts = expectedAttempts - 1, ExponentialBackoff = exponential });

            var initialCaptureAttempt = DateTime.UtcNow;
            var actualAttempts = await this.RunTest(subject, attempt =>
            {
                var currentDatetime = DateTime.UtcNow;
                var difference = currentDatetime - initialCaptureAttempt;

                var expectedDelay = exponential ? Math.Pow(delayInSeconds, attempt) : delayInSeconds * attempt;
                var actualDelay = difference.TotalSeconds;

                Assert.AreEqual(expectedDelay, expectedDelay, delta, $"Expected {expectedDelay}, got {actualDelay} after {attempt} retries");

                return attempt == expectedAttempts;
            });

            Assert.AreEqual(expectedAttempts, actualAttempts);
        }


        [TestMethod]
        public async Task Execute_WithExponentialBackoff_WaitsExponentially() => await RunBackoffTest(true);

        [TestMethod]
        public async Task Execute_WithLinearBackoff_WaitsLinearly() => await RunBackoffTest(false);


        [TestMethod]
        public async Task Execute_RetriesTillSuccess()
        {
            const int maxAttempts = 3;
            const int expectedAttempts = 2;

            var subject = CreateSubject(new RetryPolicyOptions { InitialRetryDelay = TimeSpan.FromSeconds(0), RetryAttempts = maxAttempts - 1, ExponentialBackoff = true });

            var actualAttempts = await RunTest(subject, attempts => attempts == 2); // resolve during second attempt

            Assert.AreEqual(expectedAttempts, actualAttempts);
        }

        [TestMethod]
        [ExpectedException(typeof(SocketException))]
        public async Task Execute_RetriesTillMaxAttempts()
        {
            const int maxAttempts = 2;

            var subject = CreateSubject(new RetryPolicyOptions { InitialRetryDelay = TimeSpan.FromSeconds(0), RetryAttempts = maxAttempts - 1, ExponentialBackoff = true });

            await RunTest(subject, _ => false); // never resolve
        }
    }
}
