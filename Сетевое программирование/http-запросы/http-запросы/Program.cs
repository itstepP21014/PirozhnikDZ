using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace http_запросы
{
    class Program
    {
        static void Main(string[] args)
        {
            // создаем объект запроса
            HttpWebRequest reqw = (HttpWebRequest)HttpWebRequest.Create("http://itstep.org");
            // создаем объект отклика
            HttpWebResponse resp = (HttpWebResponse)reqw.GetResponse();
            // создаем поток для чтения отклика
            StreamReader sr = new StreamReader(resp.GetResponseStream(), true);
            // вывести на экран все что читается
            Console.WriteLine(sr.ReadToEnd());
            sr.Close();

            // установка русского языка по умолчанию
            //reqw.Headers.Add("Accept-Language: ru-ru");
            
            Console.WriteLine("\n\n");
            foreach(string header in resp.Headers)
            {
                Console.WriteLine("{0}:{1}", header, resp.Headers[header]);
            }

            Console.WriteLine("\n\n");
            HttpWebRequest reqw2 = (HttpWebRequest)HttpWebRequest.Create("http://yandex.ru");
            HttpWebResponse resp2 = (HttpWebResponse)reqw2.GetResponse();
            foreach (string header in resp2.Headers)
            {
                Console.WriteLine("{0}:{1}", header, resp2.Headers[header]);
            }
        }
    }
}
