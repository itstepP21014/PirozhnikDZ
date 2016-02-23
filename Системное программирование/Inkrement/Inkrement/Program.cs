using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Inkrement
{
    class Program
    {
        class Worker
        {
            public static int N {get; set;}
            public static int M { get; set; }
            static Object Monitor = new Object(); // говорит занята ли критическая секция или нет
            static void func()
            {
                Random r = new Random();
                for (int i = 10; i < 20; ++i)
                {
                    // критическая секция, в нее моет зайти только один поток
                    lock (Monitor)
                    {
                        ++N;
                        ++M;
                    }
                }
            }

            public static void start()
            {
                Thread thread = new Thread(func);
                thread.Start();

            }

            //public Worker()
            //{
            //    Thread thread = new Thread(func);
            //    thread.Start();
            //}
        }

        static void Main(string[] args)
        {
            Worker.start();
            Worker.start();
            Thread.Sleep(1000);
            Console.WriteLine("Main {0}", Worker.N);
        }

        static void Main22(string[] args)
        {
            Worker a = new Worker();
            Worker b = new Worker();
            Console.WriteLine(Worker.N);
        }

        static void Main11(string[] args)
        {
            Thread myThread1 = new Thread(myFunction);
            Thread myThread2 = new Thread(myFunction);
            myThread1.IsBackground = true; // делаем один поток фотовым, даже если он не закончится, приложение сможет закрыться
            Console.WriteLine(myThread1.IsBackground);
            myThread1.Start(1);
            myThread2.Start(2);

            for (int i = 10; i <= 20; ++i)
            {
                Console.WriteLine(myThread1.IsAlive);
            }
        }

        static void myFunction(Object obj) // функции, передающиеся потоку, должны принимать только object
        {
            int n = (int)obj; // преобразуем входное значение уже только внутри функции
            for(int i = 0; i <= 20; ++i)
            {
                Console.WriteLine("{0}: {1}", n, i);
                Thread.Sleep(100); // операционна система не дает потоку управление на 100 милисекунд
            }
        }
    }
}
