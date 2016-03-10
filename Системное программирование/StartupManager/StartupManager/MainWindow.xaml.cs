using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace StartupManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public class Regitem
        {
            public string DisplayName { get; set; }
            public string InstallSource { get; set; }
            public string UnInstallString { get; set; }
        }

        ObservableCollection<Regitem> listView = new ObservableCollection<Regitem>();
        

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnInstal_Click(object sender, RoutedEventArgs e)
        {
            RegistryKey hklm = Registry.CurrentUser;
            RegistryKey hkSoftware = hklm.OpenSubKey("SOFTWARE");
            RegistryKey hkMicrosoft = hkSoftware.OpenSubKey("Microsoft");
            RegistryKey hkWindows = hkMicrosoft.OpenSubKey("Windows");
            RegistryKey hkCurrentVersion = hkWindows.OpenSubKey("CurrentVersion");
            RegistryKey hkRun = hkCurrentVersion.OpenSubKey("Run", true);
            hkRun.SetValue("calc", "calc.exe");
            MessageBox.Show("Типа установился");
        }

        private void btnUnInstal_Click(object sender, RoutedEventArgs e)
        {
            RegistryKey hklm = Registry.CurrentUser;
            RegistryKey hkSoftware = hklm.OpenSubKey("SOFTWARE");
            RegistryKey hkMicrosoft = hkSoftware.OpenSubKey("Microsoft");
            RegistryKey hkWindows = hkMicrosoft.OpenSubKey("Windows");
            RegistryKey hkCurrentVersion = hkWindows.OpenSubKey("CurrentVersion");
            RegistryKey hkRun = hkCurrentVersion.OpenSubKey("Run", true);
            hkRun.DeleteValue("calc");
            MessageBox.Show("Типа удалился");
        }

        private void btnShowProgramm_Click(object sender, RoutedEventArgs e)
        {
            RegistryKey hklm = Registry.LocalMachine;
            RegistryKey hkSoftware = hklm.OpenSubKey("SOFTWARE");
            RegistryKey hkMicrosoft = hkSoftware.OpenSubKey("Microsoft");
            RegistryKey hkWindows = hkMicrosoft.OpenSubKey("Windows");
            RegistryKey hkCurrentVersion = hkWindows.OpenSubKey("CurrentVersion");
            RegistryKey hkUninstall = hkCurrentVersion.OpenSubKey("Uninstall");

            
            string[] programmsNames = hkUninstall.GetSubKeyNames();

            foreach(string item in programmsNames)
            {
                using (RegistryKey t = hkUninstall.OpenSubKey(item))
                {
                    if(t != null)
                    {
                        string dn = (string)t.GetValue("DisplayName");
                        string ins = (string)t.GetValue("InstallSource");
                        string uins = (string)t.GetValue("UninstallString");
                        if (!string.IsNullOrEmpty(dn) && !string.IsNullOrEmpty(ins) && !string.IsNullOrEmpty(uins))
                        {
                            listView.Add(new Regitem() {DisplayName = dn, InstallSource = ins, UnInstallString = uins});
                        }
                    }
                }

                lvProgramm.ItemsSource = listView;
            }
        }
    }
}
