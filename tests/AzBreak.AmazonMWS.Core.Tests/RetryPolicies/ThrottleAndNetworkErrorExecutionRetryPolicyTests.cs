using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AzBreak.AmazonMWS.Core.RetryPolicies;
using AzBreak.AmazonMWS.TestSuite;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace AzBreak.AmazonMWS.Core.Tests.RetryPolicies
{
    // need to migrate this...
    //[TestClass]
    //public class ThrottleAndNetworkErrorExecutionRetryPolicyTests
    //{
    //    [TestMethod]
    //    public async Task Execute_ChainedOverMultiple_CallsBoth()
    //    {
    //        var request = new Request();
    //        var cancellationToken = CancellationToken.None;

    //        var subject = new ChainExecutionRetryPolicy(new NoExecutionRetryPolicy(), new NoExecutionRetryPolicy());
    //        var response = await subject.Execute(request, cancellationToken, (_1, _2) =>
    //        {
    //            return Task.FromResult(ResponseStub.CreateSuccess());
    //        });

    //        Assert.IsTrue(response.Success);
    //    }
    //}
}
