using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AzBreak.AmazonMWS.Core
{
    public abstract class AmazonMWSEnumeration : IEquatable<AmazonMWSEnumeration>
    {
        [XmlText]
        public string Value { get; set; }

        public override string ToString() => Value;

        public static implicit operator string(AmazonMWSEnumeration enumeration) => enumeration.Value;

        public bool Equals(AmazonMWSEnumeration other) => EqualityComparer<string>.Default.Equals(this.Value, other?.Value);

        public override bool Equals(object obj) => Equals(obj as AmazonMWSEnumeration);

        public override int GetHashCode() => EqualityComparer<string>.Default.GetHashCode(this.Value);
    }
}
