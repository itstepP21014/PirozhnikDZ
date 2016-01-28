using System;
using System.Xml;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xml;

class MyApp
{
    static void displayNode(XmlNode node, int level = 0)
    {

        if (node.NodeType == XmlNodeType.Element)
        {
            Console.Write(new String(' ', level) + node.Name);
            foreach (XmlAttribute a in node.Attributes)
            {
                Console.Write(" {0}='{1}'", a.Name, a.Value);
            }
            Console.WriteLine();
        }
        if (node.NodeType == XmlNodeType.Text)
        {
            Console.WriteLine(new String(' ', level) + '*' + node.Value + '*');
        }


        foreach (XmlNode child in node.ChildNodes)
        {
            displayNode(child, level + 1);
        }
    }


    static void Main()
    {
        XmlDocument doc = new XmlDocument();
        doc.Load(@"C:\Users\st\Cars.xml");
        XmlNode root = doc.ChildNodes[1];
        displayNode(root);


        List<Automobile> auto = new List<Automobile>();
        
        foreach (XmlElement node in root.ChildNodes)
        {
            if (node.Name.ToLower() == "car")
            {
                auto.Add(new Automobile(node));
            }
        }

       
        
        Console.Read();
    }
}

//XmlNodeList nodes = doc.GetElementsByTagName("Car");
//if (node["Year"] != null)
//            {
//                Console.WriteLine("{0}", node["Year"].InnerText);
//            }