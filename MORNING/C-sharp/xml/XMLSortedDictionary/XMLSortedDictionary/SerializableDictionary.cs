using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace XMLSortedDictionary
{
    //[XmlRoot("dictionary")]
    public interface IScalarValue
    {
        void FromString(string str);
        string ToString();
    }

    public class SerializableDictionary<TKey, TValue>
        : Dictionary<TKey, TValue>, IXmlSerializable where TKey : IScalarValue, new()
    {
        #region IXmlSerializable Members
        public System.Xml.Schema.XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(System.Xml.XmlReader reader)
        {
            XmlSerializer keySerializer = new XmlSerializer(typeof(TKey));
            XmlSerializer valueSerializer = new XmlSerializer(typeof(TValue));

            bool wasEmpty = reader.IsEmptyElement;
            reader.Read();

            if (wasEmpty)
                return;

            while (reader.NodeType != System.Xml.XmlNodeType.EndElement)
            {
                //reader.ReadStartElement("item");

                //reader.ReadStartElement("key");
                //TKey key = (TKey)keySerializer.Deserialize(reader);
                //reader.ReadEndElement();

                //reader.ReadStartElement("value");
                //TValue value = (TValue)valueSerializer.Deserialize(reader);
                //reader.ReadEndElement();

                //this.Add(key, value);

                //reader.ReadEndElement();
                //reader.MoveToContent();

                reader.ReadStartElement("item");

                reader.MoveToAttribute("key");
                TKey key= new TKey();
                key.FromString(reader.Value);

                TValue value = (TValue)valueSerializer.Deserialize(reader);

                this.Add(key, value);

                reader.ReadEndElement();
                reader.MoveToContent();


            }
            reader.ReadEndElement();
        }

        public void WriteXml(System.Xml.XmlWriter writer)
        {
            XmlSerializer keySerializer = new XmlSerializer(typeof(TKey));
            XmlSerializer valueSerializer = new XmlSerializer(typeof(TValue));

            foreach (TKey key in this.Keys)
            {
                //writer.WriteStartElement("item");

                //writer.WriteStartElement("key");
                //keySerializer.Serialize(writer, key);
                //writer.WriteEndElement();

                //writer.WriteStartElement("value");
                //TValue value = this[key];
                //valueSerializer.Serialize(writer, value);
                //writer.WriteEndElement();

                //writer.WriteEndElement();


                writer.WriteStartElement("item");
                string keystr;
                if(key.GetType() == typeof(int))
                {
                    keystr = key.ToString();
                }
                else
                {
                    throw new ArgumentException("Type of argument");
                }
                writer.WriteAttributeString("key", keystr);

                TValue value = this[key];
                valueSerializer.Serialize(writer, value);

                writer.WriteEndElement();



            }
        }
        #endregion
    }
}
