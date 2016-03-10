using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CalcInReestr
{
    class Program
    {
        static void Main(string[] args)
        {
            RegistryKey hklm = Registry.LocalMachine;
            RegistryKey hkSoftware = hklm.OpenSubKey("Software");
            RegistryKey hkWOW6432 = hkSoftware.OpenSubKey("WOW6432Node");
            RegistryKey hkMicrosoft = hkWOW6432.OpenSubKey("Microsoft");
            RegistryKey hkWindows = hkMicrosoft.OpenSubKey("Windows");
            RegistryKey hkCurrentVersion = hkWindows.OpenSubKey("CurrentVersion");
            RegistryKey hkPolicies = hkCurrentVersion.OpenSubKey("Policies");
            RegistryKey hkExplorer = hkPolicies.OpenSubKey("Explorer");
            hkExplorer.CreateSubKey("calc");
        }
    }
}
