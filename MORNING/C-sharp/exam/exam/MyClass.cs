using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace exam
{
    public class MyClass <TKey, TValue> : Dictionary<TKey, TValue>, IXmlSerializable
    {
        public void WriteXml(XmlWriter writer)
        {
            XmlSerializer keySerializer = new XmlSerializer(typeof(TKey));
            XmlSerializer valueSerializer = new XmlSerializer(typeof(TValue));

            foreach (TKey key in this.Keys)
            {
                writer.WriteStartElement("node");
                writer.WriteStartElement("key");
                keySerializer.Serialize(writer, key);
                writer.WriteEndElement();
                writer.WriteStartElement("value");
                TValue value = this[key];
                valueSerializer.Serialize(writer, value);
                writer.WriteEndElement();
                writer.WriteEndElement();
            }
        }

        public void ReadXml(XmlReader reader)
        {
            if (reader.IsEmptyElement)
            {
                return;
            }

            reader.Read();

            XmlSerializer keySerializer = new XmlSerializer(typeof(TKey));
            XmlSerializer valueSerializer = new XmlSerializer(typeof(TValue));
            TKey keyBuffer;
            TValue valueBuffer;

            while (reader.NodeType != XmlNodeType.EndElement)
            {
                reader.ReadStartElement("node");
                reader.ReadStartElement("key");
                keyBuffer = (TKey)keySerializer.Deserialize(reader);
                reader.ReadEndElement();
                reader.ReadStartElement("value");
                valueBuffer = (TValue)valueSerializer.Deserialize(reader);
                reader.ReadEndElement();
                reader.ReadEndElement();
                this.Add(keyBuffer, valueBuffer);
                reader.MoveToContent();
            }
        }


        public XmlSchema GetSchema()
        {
            return (null);
        }

   
    }
}


