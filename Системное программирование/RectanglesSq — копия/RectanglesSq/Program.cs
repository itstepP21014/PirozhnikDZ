using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RectanglesSq
{
    class Program
    {
        public static int count;
        static void Main(string[] args)
        {
            const int RectangleCalculations = 100;
            count = RectangleCalculations;

            // One event is used for each Fibonacci object
            ManualResetEvent signal = new ManualResetEvent(false);
            Rectangle[] recArray = new Rectangle[RectangleCalculations];
            Random r = new Random();
            ThreadPool.SetMaxThreads(2, 2);

            // Configure and launch threads using ThreadPool:
            Console.WriteLine("launching {0} tasks...", RectangleCalculations);
            for (int i = 0; i < RectangleCalculations; i++)
            {
                Rectangle rec = new Rectangle(r.Next(20, 40), r.Next(20, 40), signal);
                recArray[i] = rec;
                ThreadPool.QueueUserWorkItem(rec.ThreadPoolCallback, i);
            }

            // Wait for all threads in pool to calculation...
            signal.WaitOne();
            Console.WriteLine("All calculations are complete.");

            // Display the results...
            for (int i = 0; i < RectangleCalculations; i++)
            {
                Rectangle rec = recArray[i];
                Console.WriteLine("Sq. rectangle({0} x {1}) = {2}", rec.H, rec.W, rec.S);
            }
        }
    }
}
