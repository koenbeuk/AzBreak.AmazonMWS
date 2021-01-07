using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AzBreak.AmazonMWS.Feeds
{
    public class CancelFeedSubmissionsResult
    {
        /// <summary>
        /// The total number of feed submissions that match the request parameters.	
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// A list of feed submission info's
        /// </summary>
        [XmlElement(nameof(FeedSubmissionInfo))]
        public List<FeedSubmissionInfo> Feeds { get; set; }
    }
}
