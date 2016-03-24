using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace KopiyaSaita
{

    //htmlAgilityPack

    class Program
    {
        static void Main(string[] args)
        {
            List<string> urlCollection = new List<string>();
            WebClient client = new WebClient();
            string page = Encoding.ASCII.GetString(client.DownloadData("http://www.yandex.ru"));
            //Console.WriteLine(page);
            //Console.WriteLine("\n\n");

            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(page);
            HtmlNodeCollection nodesCollection = doc.DocumentNode.SelectNodes("//a");

            foreach(var a in nodesCollection)
            {
                if (a.Attributes["href"].Value.Contains("yandex"))
                {
                    urlCollection.Add(a.Attributes["href"].Value);
                }
            }

            foreach (var a in urlCollection)
            {
                Console.WriteLine("{0}", a);
            }


        }
    }
}
