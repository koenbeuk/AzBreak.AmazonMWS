using AzBreak.AmazonMWS.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AzBreak.AmazonMWS.Feeds
{
    public class GetFeedSubmissionListResult
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
        /// The earliest submission date that you are looking for
        /// </summary>
        public AmazonMWSDateTime SubmittedFromDate { get; set; }

        /// <summary>
        /// The latest submission date that you are looking for
        /// </summary>
        public AmazonMWSDateTime SubmittedToDate { get; set; }

        /// <summary>
        /// A list of feed submission info's
        /// </summary>
        [XmlElement(nameof(FeedSubmissionInfo))]
        public List<FeedSubmissionInfo> Feeds { get; set; } 
    }
}
