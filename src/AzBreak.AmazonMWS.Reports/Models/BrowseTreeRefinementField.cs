using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AzBreak.AmazonMWS.Reports.Models
{
    public partial class BrowseTree
    {
        public struct BrowseTreeRefinementField
        {
            [XmlElement("acceptedValues")]
            public string AcceptedValues { get; set; }
            [XmlElement("hasModifier")]
            public string HasModifier { get; set; }
            [XmlElement("modifierrs")]
            public string Modifiers { get; set; }
            [XmlElement("refinementAttribute")]
            public string RefinementAttribute { get; set; }

            #region Helpers

            public IEnumerable<string> AcceptedValueList => AcceptedValues.Split(',');

            #endregion
        }
    }
}
