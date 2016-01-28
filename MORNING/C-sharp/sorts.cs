using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{


    public static class Sort<T> where T : IComparable
    {

        public static void Bublesort(T[] array, int from, int to)
        {
            T helper;
            int i, j;
            for (i = from; i < to; i++)
            {
                for (j = from; j < to - 1 - i; j++)
                {
                    if ((array[j].CompareTo(array[j + 1])) < 0)
                    {
                        helper = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = helper;
                    }
                }
            }
        }

        static int Partition(T[] array, int from, int to)
        {
            int i = from;
            while (array[i].CompareTo(array[to]) < 0)
            {
                i++;
            }
            T temp;
            int j;
            for (j = i; j < to; j++)
            {
                if (array[j].CompareTo(array[to]) < 0)
                {
                    temp = array[j];
                    array[j] = array[i];
                    array[i] = temp;
                    i++;
                }
            }
            temp = array[i];
            array[i] = array[to];
            array[to] = temp;
            return i;
        }

        public static void Quicksort(T[] array, int from, int to)
        {
            if (from < to)
            {
                int index = Partition(array, from, to);
                Quicksort(array, from, index - 1);
                Quicksort(array, index + 1, to);
            }
        }



    }



    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int arr_size = 10;
            int[] arr = new int[arr_size];

            for (int i = 0; i < arr_size; i++)
            {
                arr[i] = random.Next(0, 20);
            }

            foreach (var i in arr)
                Console.Write("{0} ", i);

            Console.Write("\n");

            //Sort.Bublesort(arr, 0, arr_size);
            Sort<int>.Quicksort(arr, 0, arr_size - 1);

            foreach (var i in arr)
                Console.Write("{0} ", i);




            Console.ReadLine();

        }
    }
}
