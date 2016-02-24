using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;

namespace WpfApplication1
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
        static Thread threadCopy, threadProgressBar;
        static string start, destination;
        static object monitor = new object();
        static double value;

        private string GetFilePath()
        {
            OpenFileDialog file = new OpenFileDialog();
            file.InitialDirectory = @"C:\Users\admin\Desktop";
            if (file.ShowDialog() == null)
                return "";

            return file.FileName;
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            start = this.GetFilePath();
            btnStart.Content = start;
        }

        private void btnDestination_Click(object sender, RoutedEventArgs e)
        {
            destination = this.GetFilePath();
            btnDestination.Content = destination;         
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            threadCopy = new Thread(CopyFile);
            threadProgressBar = new Thread(RanProgressBar);
            threadCopy.Start();
            threadProgressBar.Start();
        }

        void RanProgressBar()
        {
            while(threadCopy.IsAlive)
            {
                Dispatcher.Invoke(new Action(() => pb.Value = value));
            }
            Dispatcher.Invoke(new Action(() => pb.Value = 0));
        }

        static void CopyFile()
        {
            lock (monitor)
            {
                using (var outputFile = File.OpenRead(start))
                {
                    using (var inputFile = File.OpenWrite(destination))
                    {
                        int CopyBufferSize = (int)outputFile.Length / 100;
                        var buffer = new byte[CopyBufferSize];
                        int bytesRead;
                        do
                        {
                            bytesRead = outputFile.Read(buffer, 0, CopyBufferSize);
                            if (bytesRead != 0)
                            {
                                inputFile.Write(buffer, 0, bytesRead);
                            }
                            Thread.Sleep(10);
                            value = (inputFile.Length * 1.0) * 100 / (outputFile.Length * 1.0);
                           
                        } while (bytesRead != 0);
                    }
                }
                MessageBox.Show("Copying has completed!");
            }
        }






    }
}
