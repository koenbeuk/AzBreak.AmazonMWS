using AzBreak.AmazonMWS.Core;
using AzBreak.AmazonMWS.Reports.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Threading.Tasks;
using static AzBreak.AmazonMWS.Reports.Models.BrowseTree;

namespace AzBreak.AmazonMWS.Reports.Samples
{
    class Program
    {
        static readonly bool? RootNodesOnly = true;
        static readonly string browseNodeId = null;
        static readonly AmazonMWSClientOptions ClientOptions = new AmazonMWSClientOptions
        {
            RegionEndpoint = "",
            SellerId = "",
            SecretKey = "",
            AWSAccessKeyId = "",
            MWSAuthToken = "" // optional
        };

        static async Task Main()
        {
            var configuration = new ConfigurationBuilder().AddUserSecrets<Program>()
                                                          .Build();

            ClientOptions.RegionEndpoint = configuration.GetSection("RegionEndpoint").Value ?? ClientOptions.RegionEndpoint;
            ClientOptions.SellerId = configuration.GetSection("SellerId").Value ?? ClientOptions.SellerId;
            ClientOptions.SecretKey = configuration.GetSection("SecretKey").Value ?? ClientOptions.SecretKey;
            ClientOptions.AWSAccessKeyId = configuration.GetSection("AWSAccessKeyId").Value ?? ClientOptions.AWSAccessKeyId;
            ClientOptions.MWSAuthToken = configuration.GetSection("MWSAuthToken").Value ?? ClientOptions.MWSAuthToken;

            try
            {
                //await GetBrowseTreeReport();
                await ListMarketplaceParticipations();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();
        }

        static async Task GetBrowseTreeReport()
        {
            void PrintTreeRecursively(BrowseTree tree, BrowseTreeNode node, int currentDepth)
            {
                var prefix = new string(Enumerable.Repeat('\t', currentDepth).ToArray());
                Console.WriteLine($"{prefix}{node.Name}");

                if (node.HasChildren)
                {
                    var childNodes = tree.Nodes.Where(x => node.ChildNodes.Ids.Contains(x.Id));
                    foreach (var childNode in childNodes)
                    {
                        PrintTreeRecursively(tree, childNode, currentDepth + 1);
                    }
                }
            }

            var channel = AmazonMWSChannelFactory.Create(ClientOptions);
            var subject = channel.CreateReportsClient();

            Console.WriteLine("Requesting report");
            var reportRequestResponse = await subject.RequestReport(RequestReportRequest.BrowseTree(rootNodesOnly: RootNodesOnly, browseNodeId: browseNodeId));
            reportRequestResponse.EnsureSuccess();
            Console.WriteLine("Requested report");

            var reportRequestInfo = reportRequestResponse.Result.ReportRequestInfo;

            while (!reportRequestInfo.IsComplete)
            {
             //   await Task.Delay(1000);
                Console.WriteLine("Checking if the report is available...");
                var reportRequestListResponse = await subject.GetReportRequestList(new GetReportRequestListRequest { ReportRequestIds = new[] { reportRequestInfo.ReportRequestId } });
                if (reportRequestListResponse.Error?.Code == ErrorCode.RequestThrottled)
                {
                    Console.WriteLine("Request throttled received, taking a break for 45 secs...");
                    await Task.Delay(TimeSpan.FromSeconds(45));
                }
                else
                {
                    reportRequestListResponse.EnsureSuccess();
                    reportRequestInfo = reportRequestListResponse.Result.ReportRequestInformations.Single();
                }
            }

            Console.WriteLine($"Report available with id {reportRequestInfo.GeneratedReportId}, fetching content (this may take a few minutes)...");
            var reportResponse = await subject.GetReport(reportRequestInfo.GeneratedReportId);
            reportResponse.EnsureSuccess();
            var browseTree = await reportResponse.ReadXmlAsAsync<BrowseTree>();
            Console.WriteLine("Report fetched");
            Console.WriteLine();
            Console.WriteLine();


            foreach (var rootNode in browseTree.Nodes.Where(x => string.IsNullOrEmpty(x.BrowsePathById)))
            {
                PrintTreeRecursively(browseTree, rootNode, 0);
            }
        }
        static async Task ListMarketplaceParticipations()
        {
            var channel = AmazonMWSChannelFactory.Create(ClientOptions);
            var subject = channel.CreateSellersClient();

            var result = await subject.ListMarketplaceParticipations();
        }
    }
}
