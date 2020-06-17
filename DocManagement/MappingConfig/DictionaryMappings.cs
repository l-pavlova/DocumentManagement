using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace DocManagement.MappingConfig
{
    public class DictionaryMappings<TKey, TValue> : Dictionary<TKey, TValue>,
                                              IXmlSerializable
    {
        public XmlSchema GetSchema() { return null; }
        public void ReadXml(XmlReader reader)
        {
            if (reader.IsEmptyElement) { return; }
            reader.Read();
            while (reader.NodeType != XmlNodeType.EndElement)
            {
                object key = reader.GetAttribute("Name");
                object value = reader.GetAttribute("Value");
                this.Add((TKey)key, (TValue)value);
                reader.Read();
            }
        }
        public void WriteXml(XmlWriter writer)
        {
            foreach (var key in this.Keys)
            {
                writer.WriteStartElement("Pair");
                writer.WriteAttributeString("Name", key.ToString());
                writer.WriteAttributeString("Value", this[key].ToString());
                writer.WriteEndElement();
            }
        }
    }
    
}
