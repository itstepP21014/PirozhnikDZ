using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static int x = 10;
        static Object o = (Object)x;
        static void Main(string[] args)
        {
            Thread a = new Thread(A);
            Thread b = new Thread(A);
            a.Start();
            b.Start();
        }

        static void A()
        {
            // lock это monitor + try catch
            System.Threading.Monitor.Enter(o);
            try
            {
                for (int i = 0; i < 10; ++i)
                {
                    Console.WriteLine(i);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("ex");
            }
            finally
            {
                System.Threading.Monitor.Exit(o);
            }
        }

        static void Main11(string[] args)
        {
            bool existed;
            string guid = Marshal.GetTypeLibGuidForAssembly(Assembly.GetExecutingAssembly()).ToString();

            Mutex mutexObj = new Mutex(true, guid, out existed);

            if(existed)
            {
                Console.WriteLine("started first");
            }
            else
            {
                Console.WriteLine("second");
                Thread.Sleep(5000);
                return;
            }
            Console.ReadLine();
        }
    }
}
