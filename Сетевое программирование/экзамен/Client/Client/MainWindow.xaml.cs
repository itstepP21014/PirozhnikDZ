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

namespace Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int otvet = 0;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_1_Click(object sender, RoutedEventArgs e)
        {
            this.IsEnabled = false;
             try
            {
                // Устанавливаем удаленную точку для сокета
                IPHostEntry ipHost = Dns.GetHostEntry("localhost");
                IPAddress ipAddr = ipHost.AddressList[0];
                IPEndPoint ipEndPoint = new IPEndPoint(ipAddr, 11000);

                Socket senders = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

                // Соединяем сокет с удаленной точкой
                senders.Connect(ipEndPoint);

                string message = btn_1.Tag.ToString();
                btn_1.Content = "X";

                byte[] msg = Encoding.UTF8.GetBytes(message);

                // Отправляем данные через сокет
                int bytesSent = senders.Send(msg);

                // Буфер для входящих данных
                byte[] bytes = new byte[1024];

                // Получаем ответ от сервера
                int bytesRec = senders.Receive(bytes);
                string data = null;
                data += Encoding.UTF8.GetString(bytes, 0, bytesRec);
                Int32.TryParse(data, out otvet);

                 //DependencyObject
                 //    visualthrehelper
                 //    getchild
                 //        getchildrencount

               foreach(Button it in Maingrid)
               {
                   if(it.Tag == otvet)
                   {
                        it.Content = "O";
                        it.IsEnabled = false;
                   }
               }
                // Освобождаем сокет
                senders.Shutdown(SocketShutdown.Both);
                senders.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btn_2_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_3_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_4_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_5_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_6_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_7_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_8_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_9_Click(object sender, RoutedEventArgs e)
        {

        }


        }
    }
