using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AzBreak.AmazonMWS.Reports.Models
{
    public partial class BrowseTree
    {
        public struct BrowseTreeChildNodes
        {
            [XmlElement("id")]
            public List<long> Ids { get; set; }
        }
    }
}
