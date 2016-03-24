using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            IPAddress adr = IPAddress.Parse("127.0.0.1");
            IPEndPoint endp = new IPEndPoint(adr, 11000); // 11000 - номер протокола
            TcpListener tcpListener = new TcpListener(endp);
            // прослушивание клиентов
            tcpListener.Start();
            // приступив к прослушке можно проверить
            //нет ли ожидающих запросов на установку соединения в очереди приложения
            if(tcpListener.Pending())
            {
                this.Title = "в очереди программы есть запросы на соединение";
            }
            
            // даем согласие на ожидающий запрос
            Socket socket = tcpListener.AcceptSocket();
            // или Socket socket = tcpListener.AcceptTcpClient();

            // теперь можно осуществлять обмен данными между клиентами и сокетом сервера:
            // socket.Receive() и socket.Send()

            // остановка прослушивания:
            // tcpListener.Stop();


            // т.к. установка соединения зависит от множества факторов
            // рекомендуется вызывать этот метод в блоке try/catch
            try
            {
                // параметр в TcpClient - ЛОКАЛЬНАЯ конечная точка,
                // в то время как Connect устанавливает соединение между клиентом и сорвером
                // поэтому принимает в качестве аргумента УДАЛЕННУЮ конечную точку
                TcpClient client = new TcpClient(endp);
                client.Connect("192.168.1.52", 11000);
                // для взаиимодействия между двумя соединенными приложениями
                // как канал используем NetworkStream
                NetworkStream nwStream = client.GetStream();
                // получив поток, можем записать данные
                byte[] bt = Encoding.ASCII.GetBytes("test of connection!");
                nwStream.Write(bt, 0, bt.Length);
                // или прочитать
                client.ReceiveBufferSize = 1000;
                byte[] btRead = new byte[client.ReceiveBufferSize];
                nwStream.Read(btRead, 0, client.ReceiveBufferSize);
                // после окончания взаимодействия с клиентом
                // закрываемся для освобождения ресурсов, связанных с сокетом Close()

            }
            catch(SocketException sockEx)
            {
                MessageBox.Show("Ошибка сокета:" + sockEx.Message);
            }
            catch (ArgumentNullException nullEx)
            {
                MessageBox.Show("Объект не создан");
            }
            catch (IOException ioEx)
            {
                MessageBox.Show("Ошибка чтения\записи:" + ioEx.Message);
            }


        }
    }
}
