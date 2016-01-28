using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

/*
 * XML Serializable sorted Dictionary
 */

namespace XMLSortedDictionary
{
    class INT :  IScalarValue
    {
        private int value;
        public void FromString(string str)
        {
            value = int.Parse(str);
        }
        public string ToString()
        {
            return String.Format("{0}",value);
        }
        public INT(int x)
        {
            value = x;
        }
        public INT()
        {
            value = 0;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string filename = "C:/users/st/SerializableDictionary.xml";

            SerializableDictionary<INT, string> d = new SerializableDictionary<INT, string>();
            d.Add( new INT( 5), "Here I am");
            d[new INT(2)] = "On the road again";

            //SortedDictionary<string, List<int>> d = new SerializableDictionary<string, List<int>>();
            //d.Add("Here I am", new List<int>() { 1, 2, 3 });
            //d["On the road again"] = new List<int>() {11, 22, 33};

            foreach (var q in d)
            {
                //
            }

            XmlSerializer ser = new XmlSerializer(typeof(SerializableDictionary<INT, string>));
            TextWriter writer = new StreamWriter(filename);
            ser.Serialize(writer, d);
            writer.Close();

            using (XmlReader reader = XmlReader.Create("C:/users/st/SerializableDictionary.xml"))
            {
                d = (SerializableDictionary<INT, string>)ser.Deserialize(reader);
            }
        }
    }
}
