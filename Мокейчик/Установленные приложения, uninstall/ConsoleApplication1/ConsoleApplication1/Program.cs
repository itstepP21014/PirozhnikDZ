using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {

            //HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Run <- автозагрузка

            RegistryKey hklm = Registry.LocalMachine;
            RegistryKey hkaASoftware = hklm.OpenSubKey("Software");
            RegistryKey hkaAMicrosoft = hkaASoftware.OpenSubKey("Microsoft");
            RegistryKey hkaAWindows = hkaAMicrosoft.OpenSubKey("Windows");
            RegistryKey hkaACurrentVersion = hkaAWindows.OpenSubKey("CurrentVersion");
            //RegistryKey hkaARun = hkaACurrentVersion.OpenSubKey("Run", true);

            //hkaARun.DeleteValue("calc");
            //Console.WriteLine("-");
            //Console.ReadLine();

            //hkaARun.SetValue("calc", "calc.exe");

            RegistryKey hkaAUninstall = hkaACurrentVersion.OpenSubKey("Uninstall");

            string[] keys = hkaAUninstall.GetSubKeyNames();

            foreach (var item in keys)
            {
                //Console.WriteLine(item);
                using(RegistryKey t = hkaAUninstall.OpenSubKey(item))
                {


                    Console.WriteLine("DisplayName: {0}\nInstallSource: {1}\n\n", t.GetValue("DisplayName"), t.GetValue("InstallSource"));
                    
                }
            }


            Console.ReadLine();
        }
    }
}
