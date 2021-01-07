using AzBreak.AmazonMWS.Core.Internal;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AzBreak.AmazonMWS.Core.Tests.Internal
{
    [TestClass]
    public class AmazonMWSV2RequestUrlBuilderTests
    {
        [TestMethod]
        public void StandardInput_ReturnsSignature()
        {
            var subject = new AmazonMWSV2RequestUrlBuilder();
            var requestOptions = new AmazonMWSClientOptions
            {
                RegionEndpoint = AmazonMWSDefaultEndpoint.NorthAmerica,
                AWSAccessKeyId = "foo",
                SecretKey = "bar",
            };

            var requestUrl = subject.CreateRequestUri(new Request { Resource = "Orders", Version = "2013-09-01", Action = "ListOrders" }, requestOptions);

            // Not sure what to test, at least no exception
        }
    }
}
