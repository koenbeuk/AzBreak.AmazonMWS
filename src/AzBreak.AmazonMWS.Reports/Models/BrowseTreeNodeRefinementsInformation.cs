using System.Collections.Generic;
using System.Xml.Serialization;

namespace AzBreak.AmazonMWS.Reports.Models
{
    public partial class BrowseTree
    {
        public struct BrowseTreeNodeRefinementsInformation
        {
            [XmlElement("refinementName")]
            public List<BrowseTreeRefinementName> RefinementNames { get; set; }
        }
    }
}