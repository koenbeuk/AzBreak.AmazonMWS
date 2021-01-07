using System.Collections.Generic;
using System.Xml.Serialization;

namespace AzBreak.AmazonMWS.Reports
{
    public class GetReportRequestListResult
    {
        /// <summary>
        /// A generated string used to pass information to another call. Pass the NextToken value to the GetFeedSubmissionListByNextToken operation if the value of HasNext is true.	
        /// </summary>
        public string NextToken { get; set; }

        /// <summary>
        /// An indication of NextToken is available
        /// </summary>
        public bool HasNext { get; set; }

        /// <summary>
        /// A list of feed submission info's
        /// </summary>
        [XmlElement(nameof(ReportRequestInfo))]
        public List<ReportRequestInfo> ReportRequestInformations { get; set; }
    }
}