using System;
using System.Collections;
using System.Collections.Generic;
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
        public struct BrowseTreeNodeAttributes : IReadOnlyDictionary<string, string>, IXmlSerializable
        {
            Dictionary<string, string> attributes;

            public IEnumerable<string> Keys => attributes.Keys;

            public IEnumerable<string> Values => attributes.Values;

            public int Count => attributes.Count;

            public string this[string key] => attributes[key];

            XmlSchema IXmlSerializable.GetSchema() => null;

            void IXmlSerializable.WriteXml(XmlWriter writer) => throw new NotSupportedException();

            void IXmlSerializable.ReadXml(XmlReader reader)
            {
                var countString = reader.GetAttribute("count");
                attributes = new Dictionary<string, string>(int.Parse(countString));

                reader.Read(); // read first attribute element

                while (reader.Name == "attribute")
                {
                    var name = reader.GetAttribute("name");
                    var value = reader.ReadElementContentAsString();

                    attributes.Add(name, value);
                }

                reader.Read(); // read past end node
            }

            public bool ContainsKey(string key)
                => attributes.ContainsKey(key);

            public bool TryGetValue(string key, out string value)
                => attributes.TryGetValue(key, out value);

            public IEnumerator<KeyValuePair<string, string>> GetEnumerator()
                => attributes.GetEnumerator();

            IEnumerator IEnumerable.GetEnumerator()
                => attributes.GetEnumerator();
        }
    }
}
