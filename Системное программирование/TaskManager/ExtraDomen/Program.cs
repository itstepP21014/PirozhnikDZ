using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtraDomen
{
    class Program
    {
        static void Main(string[] args)
        {
            AppDomain factorialDomain = AppDomain.CreateDomain("Factorial Domain");
            factorialDomain.DomainUnload += FactorialDomainUnload;
            int number = 6;
            string[] arguments = new string[] {number.ToString()};

            string assemblyPath = @"C:\Users\admin\Desktop\TaskManager\TaskManager\bin\Debug\TaskManager.exe";
            factorialDomain.ExecuteAssembly(assemblyPath, arguments);

            AppDomain.Unload(factorialDomain);

            //Console.ReadKey();
        }

        private static void FactorialDomainUnload(Object sender, EventArgs e)
        {
            Console.WriteLine("Factorial Domain unloaded");
        }
    }
}
