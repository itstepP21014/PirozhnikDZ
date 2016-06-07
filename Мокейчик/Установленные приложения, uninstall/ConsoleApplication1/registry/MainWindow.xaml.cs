using Microsoft.Win32;
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

namespace registry
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public class RegItem
    {
        public string DisplayName { get; set; }
        public string InstallSource { get; set; }

        public string UninstallSource { get; set; }
    }
    public partial class MainWindow : Window
    {
        ObservableCollection<RegItem> lstViews = new ObservableCollection<RegItem>();

        public MainWindow()
        {
            
            InitializeComponent();

            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            RegistryKey hklm = Registry.LocalMachine;
            RegistryKey hkaASoftware = hklm.OpenSubKey("Software");
            RegistryKey hkaAMicrosoft = hkaASoftware.OpenSubKey("Microsoft");
            RegistryKey hkaAWindows = hkaAMicrosoft.OpenSubKey("Windows");
            RegistryKey hkaACurrentVersion = hkaAWindows.OpenSubKey("CurrentVersion");
            RegistryKey hkaAUninstall = hkaACurrentVersion.OpenSubKey("Uninstall");
           // hkaAUninstall.CreateSubKey()
            string[] keys = hkaAUninstall.GetSubKeyNames();

            foreach (var item in keys)
            {
                using (RegistryKey t = hkaAUninstall.OpenSubKey(item))
                {
                    if (t != null)
                    {
                        string dn = (string)t.GetValue("DisplayName");
                        string ins = (string)t.GetValue("InstallSource");
                        string uns = (string)t.GetValue("UninstallString");
                        if (!string.IsNullOrEmpty(dn) && !string.IsNullOrEmpty(ins) && !string.IsNullOrEmpty(uns))
                            lstViews.Add(new RegItem() { DisplayName = dn, InstallSource = ins, UninstallSource = uns, });
                    }

                }
            }

            lstView.ItemsSource = lstViews;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //RegItem t;
            //if (lstView.SelectedItem != null)
            //{
            //    t = lstView.SelectedItem as RegItem;

            //    string[] arr = t.UninstallSource.Split('/');
            //    try
            //    {
            //        Process.Start(arr[0], '/' + arr[1]);

            //    }
            //    catch (Exception ex)
            //    {

            //    }
            //}
            RegistryKey hklm = Registry.ClassesRoot;
            RegistryKey hkaASoftware = hklm.OpenSubKey("ChromeHTML");
            RegistryKey hkaAMicrosoft = hkaASoftware.OpenSubKey("Application", true);
            hkaAMicrosoft.SetValue("ApplicationName","11");
           // RegistryKey hkaAWindows = hkaAMicrosoft.OpenSubKey("ApplicationName");
            RegistryKey asfasdaf = RegFind(hklm, "Application").Key;
          
        }

        RegFindValue RegFind(RegistryKey key, string find)
        {
            if (key == null || string.IsNullOrEmpty(find))
                return null;

            string[] props = key.GetValueNames();
            object value = null;

            if (props.Length != 0)
                foreach (string property in props)
                {
                    if (property.IndexOf(find, StringComparison.OrdinalIgnoreCase) != -1)
                    {
                        return new RegFindValue(key, property, null, RegFindIn.Property);
                    }

                    value = key.GetValue(property, null, RegistryValueOptions.DoNotExpandEnvironmentNames);
                    if (value is string && ((string)value).IndexOf(find, StringComparison.OrdinalIgnoreCase) != -1)
                    {
                        return new RegFindValue(key, property, (string)value, RegFindIn.Value);
                    }
                }

            string[] subkeys = key.GetSubKeyNames();
            RegFindValue retVal = null;

            if (subkeys.Length != 0)
            {
                foreach (string subkey in subkeys)
                {
                    try
                    {
                        retVal = RegFind(key.OpenSubKey(subkey, RegistryKeyPermissionCheck.ReadSubTree), find);
                    }
                    catch (Exception ex)
                    {
                        // err msg, if need
                    }
                    if (retVal != null)
                    {
                        return retVal;
                    }
                }
            }
            key.Close();
            return null;
        }

        class RegFindValue
        {
            RegistryKey regKey;
            string mProps;
            string mVal;
            RegFindIn mWhereFound;

            public RegistryKey Key
            { get { return regKey; } }

            public string Property
            { get { return mProps; } }

            public string Value
            { get { return mVal; } }

            public RegFindIn WhereFound
            { get { return mWhereFound; } }

            public RegFindValue(RegistryKey key, string props, string val, RegFindIn where)
            {
                regKey = key;
                mProps = props;
                mVal = val;
                mWhereFound = where;
            }
        }

        enum RegFindIn
        {
            Property,
            Value
        }
    }
}
