using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace AzBreak.AmazonMWS.Reports.Models
{
    [XmlRoot("Result")]
    public partial class BrowseTree
    {
        [XmlElement("query")]
        public string Query { get; set; }

        [XmlElement("Node")]
        public List<BrowseTreeNode> Nodes{ get; set; }
    }
}
