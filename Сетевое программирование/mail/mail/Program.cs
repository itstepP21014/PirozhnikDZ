using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace mail // ПРИМЕР ОТПРАВКИ ПОЧТЫ
{
    class Program
    {
        string prompt(string query)
        {
            Console.WriteLine(query);
            return Console.ReadLine();
        }
        static void Main(string[] args)
        {
            //MailMessage post = new MailMessage();
            //post.From = "vasily@pupkin.com";
            //post.To = "Lusi@pupkin.com";
            //post.Subject = "Test message";
            //post.BodyFormat = MailFormat.Text;
            //post.Body = "post message";
            //MailAttachment at = new MailAttachment();
            //at.Filename = "C:\MyHohma.Jpg";
            //post.Attachments.Add(at);

            Program app = new Program();
            // заполняем поля почтового сообщения
            app.Dialog();
            // пытаемся отправитьл сообщение
            app.SendMail();

        }
        string to, from, subject, body, server;
        void Dialog()
        {
            to = prompt("Введите адрес получателя:");
            from = prompt("Введите адрес отправителя:");
            subject = prompt("Введите ему:");
            body = prompt("Введите текст сообщения:");
            server = prompt("Введите адрес сервера:");
        }
        public void SendMail()
        {
            MailMessage message = new MailMessage(from, to, subject, body);
            SmtpClient client = new SmtpClient(server);
            Console.WriteLine("Сосчитайте до 100");
            client.Timeout = 10000;

            client.UseDefaultCredentials = true;
            try
            {
                client.Send(message);
                Console.WriteLine("Сообщение отправлено");
            }
            catch(SmtpException se)
            {
                Console.WriteLine("Сщщбщение не отправлено по причине " + se.Message);
            }
        }
    }
}
