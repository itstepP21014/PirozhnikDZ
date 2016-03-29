using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Client2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_Orders_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                // Соединяемся с удаленным устройством

                // Устанавливаем удаленную точку для сокета
                IPHostEntry ipHost = Dns.GetHostEntry("localhost");
                IPAddress ipAddr = ipHost.AddressList[0];
                IPEndPoint ipEndPoint = new IPEndPoint(ipAddr, 11000);

                Socket senders = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

                // Соединяем сокет с удаленной точкой
                senders.Connect(ipEndPoint);

                string message = btn_Orders.Content.ToString();

                byte[] msg = Encoding.UTF8.GetBytes(message);

                // Отправляем данные через сокет
                int bytesSent = senders.Send(msg);

                // Буфер для входящих данных
                byte[] bytes = new byte[1024];
                // Получаем ответ от сервера
                int bytesRec = senders.Receive(bytes);
                string data = null;
                data += Encoding.UTF8.GetString(bytes, 0, bytesRec);
                tb_Orders.Text += data;

                //// Используем рекурсию для неоднократного вызова SendMessageFromSocket()
                //if (message.IndexOf("<TheEnd>") == -1)
                //    SendMessageFromSocket(port);

                // Освобождаем сокет
                senders.Shutdown(SocketShutdown.Both);
                senders.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


    }
}
