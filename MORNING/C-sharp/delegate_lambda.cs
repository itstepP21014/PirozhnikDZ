using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    // объявление делегата
    delegate int MyDelegat(int n);
    delegate int SumDelegate(int acc, int x);

    class Program
    {
        // делегат обязательно должен иметь возвращаемое значение
        static public int Write(int x)
        {
            Console.Write("{0} ", x);
            return x;
        }

        static Random random = new Random();
        static public int Random(int x)
        {
            x = random.Next(0, 20);
            return x;
        }

        static public int PrimeToZero(int x)
        {
            if (x == 2)
                return 0;
            if(x%2 == 0)
                return x;

            for (int i = 3; i*i <= x; i+=2)
            {
                if (x % i == 0)
                     return x;
            }
            return 0;
        }

       static public int[] Map(int[] ar, MyDelegat del)
        {
            for (int i = 0; i < ar.Length; ++i)
                ar[i] = del(ar[i]);

            return ar;
        }

        static public int Reduce(int[] arr, int _acc, SumDelegate del) {
            var acc = _acc;
            foreach(var x in arr)
                acc = del(acc, x);
            return acc;
        }

        static void Main(string[] args)
        {
            int N = 10;
            int[] arr = new int[N];

            arr = Map(arr, Random);
            arr = Map(arr, Write);
            Console.WriteLine("\n");

            arr = Map(arr, PrimeToZero);
            arr = Map(arr, Write);
            Console.WriteLine("\n");

         
            //arr = Map(arr, x => x * x); // лямбда функция
            arr = Map(arr, delegate(int x) { // анонимная функция
                x = x * x;
                return x;
            } );

            //arr = Map(arr, Write); // делегат
            arr = Map(arr, delegate(int x) { // анонимная 
                Console.Write("{0} ", x);
                return x;
            });
            Console.WriteLine("\n");


            arr = Map(arr, x => { return x / 2; } ); // что-то средненькое между лямбдой и анонимной
            arr = Map(arr, Write); // делегат

            // int n = Reduce(arr, 0, (acc, x) => acc + x); // лямбда
            int n = Reduce(arr, 0, delegate(int acc, int x) { // анонимная
                acc += x;
                return acc;
            });

            Console.WriteLine("\n{0}", n);
           
            Console.Read();
        }

    }
}
