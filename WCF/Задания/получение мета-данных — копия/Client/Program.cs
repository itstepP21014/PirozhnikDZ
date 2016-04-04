using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Client.ServiceReference1;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            MyDiskInfoClient proxy = new MyDiskInfoClient();

            while (true)
            {
                Console.WriteLine("Введите букву диска");
                var dr = Console.ReadLine();

                if (dr == "Exit")
                    break;

                try
                {
                    Console.WriteLine("Free space: {0}\nTotal Size: {1}", proxy.FreeSpace(dr), proxy.TotalSpace(dr));
                }
                catch(System.ServiceModel.FaultException)
                {
                    Console.WriteLine("Неправильная буква диска");
                }

                Console.ReadLine();
            }
        }
    }
}
