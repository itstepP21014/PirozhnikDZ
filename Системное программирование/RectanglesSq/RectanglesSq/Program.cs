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
        static void Main(string[] args)
        {
            //зависнет, если будет больше 64 заданий
            const int RectangleCalculations = 64;

            // One event is used for each Fibonacci object
            ManualResetEvent[] doneEvents = new ManualResetEvent[RectangleCalculations];
            Rectangle[] recArray = new Rectangle[RectangleCalculations];
            Random r = new Random();

            // Configure and launch threads using ThreadPool:
            Console.WriteLine("launching {0} tasks...", RectangleCalculations);
            for (int i = 0; i < RectangleCalculations; i++)
            {
                doneEvents[i] = new ManualResetEvent(false);
                Rectangle rec = new Rectangle(r.Next(20, 40), r.Next(20, 40), doneEvents[i]);
                recArray[i] = rec;
                ThreadPool.QueueUserWorkItem(rec.ThreadPoolCallback, i);
            }

            // Wait for all threads in pool to calculation...
            WaitHandle.WaitAll(doneEvents);
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
