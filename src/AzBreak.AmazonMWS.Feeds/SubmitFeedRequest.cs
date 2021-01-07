using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AzBreak.AmazonMWS.Core.Internal;

namespace AzBreak.AmazonMWS.Feeds
{
    public class SubmitFeedRequest
    {
        /// <summary>
        /// A FeedType value indicating how the data should be processed.
        /// </summary>
        public FeedType FeedType { get; set; }

        /// <summary>
        /// A list of one or more marketplace IDs (of marketplaces you are registered to sell in) that you want the feed to be applied to. The feed will be applied to all the marketplaces you specify.
        /// </summary>
        public IEnumerable<string> MarketplaceIds { get; set; }

        /// <summary>
        /// A Boolean value that enables the purge and replace functionality. Set to true to purge and replace the existing data; otherwise false. This value only applies to product-related flat file feed types, which do not have a mechanism for specifying purge and replace in the feed body. Use this parameter only in exceptional cases. Usage is throttled to allow only one purge and replace within a 24-hour period.	
        /// </summary>
        public bool? PurgeAndReplace { get; set; }

        internal IDictionary<string, object> ToParametersDictionary()
            => new ParameterDictionaryBuilder()
                .Add("FeedType", FeedType)
                .Add("MarketplaceIdList.Id", MarketplaceIds)
                .Add("PurgeAndReplace", PurgeAndReplace)
                .Parameters;
    }
}
