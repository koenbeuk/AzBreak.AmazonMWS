using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace AzBreak.AmazonMWS.Reports.Models
{
    public partial class BrowseTree
    {
        [DebuggerDisplay("{BrowsePathByName}")]
        public class BrowseTreeNode
        {
            [XmlElement("browseNodeId")]
            public long Id { get; set; }

            [XmlElement("browseNodeAttributes")]
            public BrowseTreeNodeAttributes Attributes { get; set; }

            [XmlElement("childNodes")]
            public BrowseTreeChildNodes ChildNodes { get; set; }

            [XmlElement("browseNodeName")]
            public string Name { get; set; }

            [XmlElement("browseNodeStoreContextName")]
            public string StoreContextName { get; set; }

            [XmlElement("browsePathById")]
            public string BrowsePathById { get; set; }

            [XmlElement("browsePathByName")]
            public string BrowsePathByName { get; set; }

            [XmlElement("hasChildren")]
            public bool HasChildren { get; set; }

            [XmlElement("productTypeDefinitions")]
            public string ProductTypeDefinitions { get; set; }

            [XmlElement("refinementsInformation")]
            public BrowseTreeNodeRefinementsInformation RefinementsInformation { get; set; }


            #region Helpers

            public IEnumerable<long> BrowsePath => BrowsePathById?.Split(',').Select(x => long.Parse(x));

            #endregion
        }
    }
}
