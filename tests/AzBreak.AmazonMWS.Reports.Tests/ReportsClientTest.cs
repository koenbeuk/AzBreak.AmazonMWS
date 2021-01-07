using AzBreak.AmazonMWS.Core;
using AzBreak.AmazonMWS.Reports.Models;
using AzBreak.AmazonMWS.TestSuite;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AzBreak.AmazonMWS.Reports.Tests
{
    [TestClass]
    public class ReportsClientTest
    {
        [TestMethod]
        public async Task GetBrowseTreeReport()
        {
            var channel = new AmazonMWSChannelStub().RespondWith(File.OpenRead("Captures/BrowseTree_RootNodes.xml"));
            IAmazonMWSReportsClient client = new AmazonMWSReportsClient(channel);

            var report = await client.GetReport("x");
            report.EnsureSuccess();

            var browseTree = await report.ReadXmlAsAsync<BrowseTree>();

            // assume that we were able to deserialize the entire tree
        }
    }
}
