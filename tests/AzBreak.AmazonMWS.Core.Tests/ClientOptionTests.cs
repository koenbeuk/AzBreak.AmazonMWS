using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzBreak.AmazonMWS.Core.Tests
{
    [TestClass]
    public class ClientOptionTests
    {
        static AmazonMWSClientOptions CreateValidClientOptions()
        {
            return new AmazonMWSClientOptions
            {
                AWSAccessKeyId = "x",
                MWSAuthToken = "x",
                SecretKey = "x",
                SellerId = "x",
                RegionEndpoint = AmazonMWSDefaultEndpoint.Europe
            };
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void EnsureValid_MissingAccessKey_Throws()
        {
            var subject = CreateValidClientOptions();
            subject.AWSAccessKeyId = null;

            subject.EnsureValid();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void EnsureValid_MissingSecretKey_Throws()
        {
            var subject = CreateValidClientOptions();
            subject.SecretKey = null;

            subject.EnsureValid();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void EnsureValid_MissingSellerId_Throws()
        {
            var subject = CreateValidClientOptions();
            subject.SellerId = null;

            subject.EnsureValid();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void EnsureValid_MissingRegion_Throws()
        {
            var subject = CreateValidClientOptions();
            subject.RegionEndpoint = null;

            subject.EnsureValid();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void EnsureValid_MissingUserAgent_Throws()
        {
            var subject = CreateValidClientOptions();
            subject.UserAgent = null;

            subject.EnsureValid();
        }
    }
}
