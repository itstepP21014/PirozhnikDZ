using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace exam
{
    class Program
    {
        static void Main(string[] args)
        {

            MyClass<Point, string> d = new MyClass<Point, string>();
            d.Add(new Point(034.70, 135.50), "Osaka");
            d.Add(new Point(042.35, -071.05), "Boston");
            d.Add(new Point(045.45, 009.20), "Milan");


            XmlSerializer ser = new XmlSerializer(typeof(MyClass<Point, string>));
            TextWriter writer = new StreamWriter("C:/users/st/exam.xml");
            ser.Serialize(writer, d);
            writer.Close();

            foreach (var node in d)
            {
                Console.WriteLine("Город: " + node.Value);
                Console.WriteLine("Широта: " + node.Key.x + " Долгота: " + node.Key.y + "\n");

            }

            double x = 1E-16;
            if (x + 1.0 == 1.0)
            {
                Console.WriteLine("=");
            }

            Console.ReadLine();


        }
    }
}
