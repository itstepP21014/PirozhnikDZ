using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args == null || args.Length < 1)
                throw new ArgumentNullException();
            int number = 0;
            if (!Int32.TryParse(args[0], out number))
                throw new ArgumentNullException("not a number");
            if (number < 1)
                throw new ArgumentException("<1");

            int result = 1;
            for (int i = 1; i <= number; ++i)
                result *= i;

            Console.WriteLine("{0}!={1}", number, result);
                //Console.ReadKey();
        }

        static void Main66(string[] args)
        {
            AppDomain secondaryDomain = AppDomain.CreateDomain("Secondary domain");
            secondaryDomain.AssemblyLoad += DomainAsseblyLoad;
            secondaryDomain.DomainUnload += DomainAssemblyUnload;
            Console.WriteLine("domen: {0}", secondaryDomain.FriendlyName);
            secondaryDomain.Load(new AssemblyName("System.Data"));
            Assembly[] assemblies = secondaryDomain.GetAssemblies();
            foreach (Assembly ass in assemblies)
            {
                Console.WriteLine(ass.GetName().Name);
            }
            AppDomain.Unload(secondaryDomain);

            Console.ReadKey();
        }

        private static void DomainAsseblyLoad(object sender, AssemblyLoadEventArgs args)
        {
            Console.WriteLine("Load");
        }

        private static void DomainAssemblyUnload(object sender, EventArgs args)
        {
            Console.WriteLine("Unload");
        }


        static void Main55(string[] args)
        {
            AppDomain domain = AppDomain.CurrentDomain;
            Console.WriteLine("Name: {0}", domain.FriendlyName);
            Console.WriteLine("Base directory: {0}", domain.BaseDirectory);

            Assembly[] ass = domain.GetAssemblies();
            foreach(Assembly assembly in ass)
            {
                Console.WriteLine(assembly.GetName().Name);
            }

            Console.ReadKey();
        }
        static void Main44(string[] args)
        {
            Process.Start("calc");

            Process.Start("http://yandex.ru");
            Process.Start("chrome", "yandex.ru");

            Process.Start("D;/1.txt");
            Process.Start("notepad", "D:/1.txt");

            ProcessStartInfo procInfo = new ProcessStartInfo();
            procInfo.FileName = "Chrome";
            procInfo.Arguments = "http://ya.ru";

            Console.ReadKey();
        }

        static void Main33(string[] args)
        {
            Process proc = Process.GetProcessesByName("devenv")[0];
            ProcessModuleCollection mc = proc.Modules;
            foreach(ProcessModule pm in mc)
            {
                Console.WriteLine("name: {0}, mamory: {1}, file: {2} \n\n", pm.ModuleName, pm.ModuleMemorySize, pm.FileName);
            }
            Console.ReadKey();
        }

        static void Main22(string[] args)
        {
            Process proc = Process.GetProcessesByName("calc")[0];
                Console.WriteLine("VS id: {0}", proc.Id);
                proc.Kill();
            Console.ReadKey();
        }

        static void Main11(string[] args)
        {
            foreach(Process proc in Process.GetProcesses())
            {
                Console.WriteLine("Id: {0}, Name: {1}", proc.Id, proc.ProcessName);
            }
            Console.ReadKey();
        }
    }
}
