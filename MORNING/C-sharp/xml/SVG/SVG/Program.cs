using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace SVG
{
    class Program
    {
        static void Main(string[] args)
        {
            Random r = new Random();

            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            FileStream stream = new FileStream("C:/users/st/svg.htm", FileMode.OpenOrCreate);

            using (XmlWriter writer = XmlWriter.Create(stream, settings))
            {
                writer.WriteStartElement("svg");
                writer.WriteAttributeString("width", "100%");
                writer.WriteAttributeString("height", "100%");

                for (int i = 0; i < r.Next(10, 40); i++)
                {
                    House h = new House(50, 100, 5, r.Next(10, 700), r.Next(10, 250), "rgb(31, 61, 92)", 1, "rgb(0, 0, 0)");
                    h.Draw_house(writer);

                    Windows w = new Windows(h, "rgb(255, 255, 102)", 1, "rgb(0, 0, 0)");
                    w.Draw_windows(writer);
                }

                 writer.WriteEndElement();
                 writer.Flush();
            }
            
            return;

        }
    }
}
