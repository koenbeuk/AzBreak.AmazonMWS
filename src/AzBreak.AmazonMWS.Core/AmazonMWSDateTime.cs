using AzBreak.AmazonMWS.Core.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace AzBreak.AmazonMWS
{
    public class AmazonMWSDateTime
    {
        [XmlText]
        public string StringValue { get; set; }

        [XmlIgnore]
        public DateTimeOffset? Value => DateTimeHelper.ToDateTimeOffset(StringValue);

        [XmlIgnore]
        public bool HasValue => !string.IsNullOrEmpty(StringValue);

        public override string ToString() => StringValue;
    }
}
