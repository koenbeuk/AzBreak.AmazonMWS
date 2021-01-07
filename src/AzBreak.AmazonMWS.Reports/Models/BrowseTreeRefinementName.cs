using System.Collections.Generic;
using System.Xml.Serialization;

namespace AzBreak.AmazonMWS.Reports.Models
{
    public partial class BrowseTree
    {
        public struct BrowseTreeRefinementName
        {
            [XmlAttribute("name")]
            public string Name { get; set; }

            [XmlElement("refinementField")]
            public List<BrowseTreeRefinementField> RefinementFields { get; set; }
        }
    }
}