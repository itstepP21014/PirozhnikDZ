using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SemaphoreExample
{
    class Program
    {
        private static Semaphore pool;
        static void Main(string[] args)
        {
            pool = new Semaphore(0, 3); // 0 - сколько сейчас свободно, 3 - максимальное значение

            for (int i = 0; i < 10; ++i)
            {
                Thread t = new Thread(new ParameterizedThreadStart(Worker));
                t.Start(i);
            }
            //Thread.Sleep(1000);

            pool.Release(3); // освобождаем два места
        }

        static void Worker(object obj)
        {
            int number = (int)obj;
            Console.WriteLine("Поток {0} ждет", number);
            pool.WaitOne(); // нужно подождать свободное место
            Console.WriteLine("Вода! {0}", number);
            Thread.Sleep(1000);
            Console.WriteLine("Поток {0} выходит. Свободных мест было {1}", number, pool.Release());
            //pool.Release(); // освобождаю одно место

        }
    }
}
