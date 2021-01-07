using AzBreak.AmazonMWS.Core.Internal;
using System;
using System.Collections.Generic;

namespace AzBreak.AmazonMWS.Reports
{
    public class RequestReportRequest
    {
        /// <summary>
        /// A value of the ReportType that indicates the type of report to request.	
        /// </summary>
        public ReportType ReportType { get; set; }

        /// <summary>
        /// The start of a date range used for selecting the data to report.	
        /// </summary>
        /// <remarks>
        /// Must be prior to or equal to the current time.
        /// </remarks>
        public DateTimeOffset? StartDate { get; set; }

        /// <summary>
        /// The end of a date range used for selecting the data to report.	
        /// </summary>
        /// <remarks>
        /// Must be prior to or equal to the current time.
        /// </remarks>
        public DateTimeOffset? EndDate { get; set; }

        /// <summary>
        /// Additional information to pass to the report.
        /// </summary>
        /// <remarks>
        /// If a report accepts ReportOptions, they will be described in the description of the report in the ReportType enumeration section.
        /// </remarks>
        public IDictionary<string, object> ReportOptions { get; set; }

        /// <summary>
        /// A list of one or more marketplace IDs for the marketplaces you are registered to sell in. The resulting report will include information for all marketplaces you specify. For more information about the behavior of reports when submitting multiple MarketplaceId values, see Using multiple marketplaces.
        /// </summary>
        public IEnumerable<string> MarketplaceIds { get; set; }

        internal IDictionary<string, object> ToParametersDictionary()
            => new ParameterDictionaryBuilder()
                .Add("ReportType", ReportType)    
                .Add("StartDate", StartDate)
                .Add("EndDate", EndDate)
                .Add("MarketplaceIdList.Id", MarketplaceIds)
                .Add("ReportOptions", ReportOptions)
                .Parameters;


        #region Common constructs

        /// <summary>
        /// XML report that provides browse tree hierarchy information and node refinement information for the Amazon retail website in any marketplace.
        /// </summary>
        public static RequestReportRequest BrowseTree(
            string marketplaceId = null,
            bool? rootNodesOnly = null,
            string browseNodeId = null)
            => new RequestReportRequest
            {
                ReportType = ReportType.BrowseTreeReport,
                ReportOptions = new Dictionary<string, object> {
                    { "MarketplaceId", marketplaceId },
                    { "RootNodesOnly", rootNodesOnly },
                    { "BrowseNodeId", browseNodeId }
                }
            };

        #endregion
    }
}