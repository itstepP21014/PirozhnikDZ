using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Example9
{
    class Program
    {
        static void Main(string[] args)
        {
            //ExampleAsync obj = new ExampleAsync();
            ExampleNoAsync obj = new ExampleNoAsync();
            obj.MyMethodAsync();
            for (int i = 0; i < 1000; i++)
            {
                Console.Write("*");
            }
            Console.ReadKey();
        }
    }
    // 
    class ExampleAsync
    {
        public async void MyMethodAsync()
        {
            int result = await LongRunningOperationAsync();
            Console.Write(result);
        }


        public async Task<int> LongRunningOperationAsync() 
        {
            await Task.Delay(10);
            return 1;
        }
    }

    class ExampleNoAsync
    {
        public void MyMethodAsync()
        {
            int result = LongRunningOperationAsync();
            Console.Write(result);
        }

        public int LongRunningOperationAsync()
        {
            Task.Delay(10);
            return 1;
        }
    }

}
