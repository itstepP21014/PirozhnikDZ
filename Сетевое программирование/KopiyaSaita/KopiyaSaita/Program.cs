using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
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
            string site = "http://www.it-academy.by";
            string page = Encoding.ASCII.GetString(client.DownloadData(site));
            //Console.WriteLine(page);
            //Console.WriteLine("\n\n");

            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(page);
            HtmlNodeCollection nodesCollection = doc.DocumentNode.SelectNodes("//a");

            foreach(var a in nodesCollection)
            {
                if (a.Attributes["href"].Value.Contains("it-academy") && !(a.Attributes["href"].Value.Contains("mailto")))
                {
                    urlCollection.Add(a.Attributes["href"].Value);
                }
            }

            foreach (var a in urlCollection)
            {
                Console.WriteLine("{0}", a);
            }

            int hrefnum = 1;
            foreach (var a in urlCollection)
            {
                page = page.Replace(a, @"/Site/href" + hrefnum + ".html");
                client.DownloadFile(a, @"D:\Site\href" + hrefnum + ".html");
                hrefnum++;
            }

            //CSS
            int cssnum = 1;

            string patterncssd = "@import url.[\"'](.+?)[\"']";
            Regex regexcssd = new Regex(patterncssd);
            foreach (Match match in regexcssd.Matches(page))
            {
                string cssd = match.Groups[1].Value;
                page = page.Replace(cssd, @"/Site/css/style" + cssnum + ".css");
                client.DownloadFile(cssd, @"D:\Site\css\style" + cssnum + ".css");
                cssnum++;
            }


            //Images
            string patternimg = "<img.+?src=[\"'](.+?)[\"'].+?>";
            Regex regeximg = new Regex(patternimg);
            int imgnum = 1;
            foreach (Match match in regeximg.Matches(page))
            {
                string findimghref = Regex.Match(match.Value, @"(?:http|\/\/)").Value;
                if (findimghref == "http")
                {
                    string img = match.Groups[1].Value;
                    string imgtype = Regex.Match(img, @"\/.+?(\.\w{3})").Groups[1].Value;
                    page = page.Replace(img, @"/Site/img/image" + imgnum + imgtype);
                    client.DownloadFile(img, @"D:\Site\img\image" + imgnum + imgtype);
                    imgnum++;
                }
                else if (findimghref == "//")
                {
                    //MessageBox.Show("Найден косяк");
                }
                else
                {
                    string img = match.Groups[1].Value;
                    string imgtype = Regex.Match(img, @"\/.+?(\.\w{3})").Groups[1].Value;
                    page = page.Replace(img, @"/Site/img/image" + imgnum + imgtype);
                    client.DownloadFile(site + img, @"D:\Site\img\image" + imgnum + imgtype);
                    imgnum++;
                }
            }


            string patch = @"D:\Site\";
            File.WriteAllText(patch + "index2.html", page, Encoding.UTF8);
            Console.WriteLine(page);
            // найти в тексте ссылки и заменить их на D:\Site\href1 и так далее
           
        }
    }
}
