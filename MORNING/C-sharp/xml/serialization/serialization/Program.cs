using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace serialization
{
    class Program
    {
        static void Main(string[] args)
        {
            Schollchild kid = new Schollchild();
            kid.ruckzack = new Backpack("Nike");
            kid.pens = new Pen[]{new Pen("red"), new Pen("blue")};
            kid.notebook = new Notebook[]{new Notebook(12), new Notebook(46)};


            //FileStream file = new FileStream("C:/users/st/binary_serialization.dat", FileMode.Create);
            //BinaryFormatter formatter = new BinaryFormatter();
            //try
            //{
            //    formatter.Serialize(file, kid);
            //}
            //catch (SerializationException e)
            //{
            //    Console.WriteLine("Failed to serialize. Reason: " + e.Message);
            //    throw;
            //}
            //finally
            //{
            //    file.Close();
            //}



            XmlSerializer formatter = new XmlSerializer(typeof(Schollchild));
            // using (FileStream fs = new FileStream("persons.xml", FileMode.OpenOrCreate)){formatter.Serialize(fs, person);}
            StreamWriter file = new StreamWriter("C:/users/st/xml_serialization.xml");
            formatter.Serialize(file, kid);
            file.Close();


        }
    }
}
