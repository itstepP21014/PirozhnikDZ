using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;

namespace WebClient_3Lessons
{
    class Program
    {
        static void Main(string[] args)
        {
            // создание объекта web-клиент
            WebClient client = new WebClient();
            // получение содержимого странички
            byte[] urlData = client.DownloadData("http://www.yandex.ru");
            // преобразование полученного содержимого в строку для отображения в консоли
            string page = Encoding.ASCII.GetString(urlData);
            Console.WriteLine(page);

            // закачка Web-ресурса в файл с именем fileCopy
            string fileCopy = @"C:\Users\admin\Desktop\ttt.png";
            string urlString = "http://www.yastatic.net/morda-logo/i/apple-touch-icon/ru-120x120.png";
            client.DownloadFile(urlString, fileCopy);

            //для считывания данных частями используется метод OpenRead(), получающий поток доступный для чтения
            // Связываем URL c потоком чтения
            Stream copy = client.OpenRead(urlString);
            // создаем поток для чтения закачанных данных
            FileInfo fi = new FileInfo(fileCopy);
            StreamWriter sw = fi.CreateText();
            // закачка web-ресурса в файл с именем fileCopy
            sw.WriteLine(copy.ReadToEnd()); //...................................................
            sw.Close();
            copy.Close();

            // для передачи данных серверу используется метод OpenWrite(), возвращающий поток доступный для записи
            string TextToUpload = "User=Vasia&passwd=okna";
            string urlString_2 = "http://"; //.....................................................
            // преобразуем текст в массив байтов
            byte[] uploadData = Encoding.ASCII.GetBytes(TextToUpload);
            // связываем URL с потоком записи
            Stream upload = client.OpenWrite(urlString_2, "POST");
            // загружаем данные на сервер
            upload.Write(uploadData, 0, uploadData.Length);
            upload.Close();

            //для передачи данных серверу другими HTTP-методами используется метод UploadDate()
            client.Credentials = System.Net.CredentialCache.DefaultCredentials;
            // добавляем HTTP-заголовок
            client.Headers.Add("Content-Type", "application/x-wwww-from-urlencoded");
            // копируем данные методом GET
            byte[] respText = client.UploadData(urlString_2, "GET", uploadData);
            // загружаем данные на сервер (см. выше)
            
        }
    }
}
