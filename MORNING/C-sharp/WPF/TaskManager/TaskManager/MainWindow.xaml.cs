using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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
using System.Windows.Threading;

namespace TaskManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MyProcesses process_manager = new MyProcesses();
        public DispatcherTimer timer = new DispatcherTimer();

        public MainWindow()
        {
            InitializeComponent();

            timer.Tick += Update; 
            timer.Interval = new TimeSpan(0, 0, 3); 
            timer.Start(); 

        }

        private void Update(object sender, EventArgs e) 
         { 
             timer.Stop();
             process_manager.UpdateProcesses();
             dgMain.ItemsSource = process_manager.Processes; 
             timer.Start(); 
 
         }  


        private void btnCreateProcess_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.DefaultExt = ".exe";
            dialog.Filter = "Applications (*.exe)|*.exe";
            if (dialog.ShowDialog() == true)
            {
                Process.Start(dialog.FileName);
                process_manager.UpdateProcesses();
                dgMain.ItemsSource = process_manager.Processes;
            }
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
             timer.Stop(); 
             if(tbFind.Text != "")  
             {
                 dgMain.ItemsSource = process_manager.FindProcessesByName(tbFind.Text);
             }

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dgMain.ItemsSource = Process.GetProcesses();
        }

        private void btnRedStyle_Click(object sender, RoutedEventArgs e)
        {
            ResourceDictionary newDictionary = new ResourceDictionary();
            newDictionary.Source = new Uri("RedSkin.xaml", UriKind.Relative);
            this.Resources.MergedDictionaries[0] = newDictionary;
        }

        private void btnGreenStyle_Click(object sender, RoutedEventArgs e)
        {
            ResourceDictionary newDictionary = new ResourceDictionary();
            newDictionary.Source = new Uri("GreenSkin.xaml", UriKind.Relative);
            this.Resources.MergedDictionaries[0] = newDictionary;
        }

        private void btnBlueStyle_Click(object sender, RoutedEventArgs e)
        {
            ResourceDictionary newDictionary = new ResourceDictionary();
            newDictionary.Source = new Uri("BlueSkin.xaml", UriKind.Relative);
            this.Resources.MergedDictionaries[0] = newDictionary;
        }

        private void btnGrayStyle_Click(object sender, RoutedEventArgs e)
        {
            ResourceDictionary newDictionary = new ResourceDictionary();
            newDictionary.Source = new Uri("GraySkin.xaml", UriKind.Relative);
            this.Resources.MergedDictionaries[0] = newDictionary;
        }

        private void btnProcessKiller_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult answer = MessageBox.Show("Вы уверены, что хотите завершить текущий процесс?", "Завершение  процесса", MessageBoxButton.YesNo, 
                 MessageBoxImage.Question); 
            if (answer == MessageBoxResult.Yes)
            {
                try
                {
                    timer.Stop();
                    var selectedProcess = dgMain.SelectedItem as Process;
                    process_manager.Processes.Remove(selectedProcess);
                    selectedProcess.Kill();
                    timer.Start();
                }
                catch
                {
                    MessageBox.Show("В доступе отказано.", "Нет доступа", MessageBoxButton.OK);
                }
            }
        }


        private void tbFind_TextChanged(object sender, TextChangedEventArgs e)
        { 
             if (tbFind.Text == "") 
             {
                 process_manager.UpdateProcesses();
                 dgMain.ItemsSource = process_manager.Processes;
                 timer.Start(); 
             }
         }

        private void tbIdFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tbFind.Text == "")
            {
                process_manager.UpdateProcesses();
                dgMain.ItemsSource = process_manager.Processes;
                timer.Start();
            }
            timer.Stop();
            dgMain.ItemsSource = process_manager.FilterProcessesById(tbIdFilter.Text);
            timer.Start();

        }

        private void tbNameFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tbFind.Text == "")
            {
                process_manager.UpdateProcesses();
                dgMain.ItemsSource = process_manager.Processes;
                timer.Start();
            }
            timer.Stop();
            dgMain.ItemsSource = process_manager.FilterProcessesByName(tbNameFilter.Text);

        }


    }
}
