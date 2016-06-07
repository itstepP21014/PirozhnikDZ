using System;
using System.Collections.Generic;
using System.Linq;
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
using System.Threading;
using Microsoft.Win32;
using System.IO;

namespace WpfApplication3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string from;
        string to;
        Thread copyThread;
        delegate void setProgress(double i);
        bool isContinue = true;
     
        public MainWindow()
        {
            InitializeComponent();
            progressBar.Maximum = 100;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
             OpenFileDialog openFileDialog = new OpenFileDialog();
             if (openFileDialog.ShowDialog() == true)
                 from = openFileDialog.FileName;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
                to = openFileDialog.FileName;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            copyThread = new Thread(Go);
            copyThread.IsBackground = true;
            copyThread.Start();
        }




        private void Go() {

            int CopyBufferSize = 1024*10;
 

            int numReads = 0;
            using (var outputFile = File.Create(to))
            {
                using (var inputFile = File.OpenRead(from))
                {
                    var buffer = new byte[CopyBufferSize];
                    int bytesRead;
                    double shagi = (double) 100 / ( inputFile.Length / CopyBufferSize ) ;

                    do
                    {
                        bytesRead = inputFile.Read(buffer, 0, CopyBufferSize);

                        ++numReads;
                        if (bytesRead != 0)
                        {
                            outputFile.Write(buffer, 0, bytesRead);
                        }

                        Dispatcher.Invoke(new setProgress(UpdateProgress), new object[]{shagi});
                    } while (bytesRead != 0 && isContinue);
                }
            }
            MessageBox.Show("ok!");
        }

        void UpdateProgress(double i)
        {
            progressBar.Value += i;
        }
        private void ProgressBar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

            isContinue = false;// ставлю флаг что надо бы остановиться
            //copyThread.Abort();
        }

    }
}
