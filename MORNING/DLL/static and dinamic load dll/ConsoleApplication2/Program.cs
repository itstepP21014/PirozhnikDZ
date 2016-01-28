using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Program
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int MultiplyByTen(int numberToMultiply);

        static void Main(string[] args)
        {
            //// статическая загрузка
            //Console.Write(NativeMethods.MultiplyByTen(17));
            //Console.ReadLine();




            IntPtr pDll = NativeMethods.LoadLibrary(@"C:/users/st/Documents/Visual Studio 2013/Projects/ConsoleApplication1/Debug/ConsoleApplication1.dll");
            //oh dear, error handling here
            //if (pDll == IntPtr.Zero)

            IntPtr pAddressOfFunctionToCall = NativeMethods.GetProcAddress(pDll, "MultiplyByTen");
            //oh dear, error handling here
            //if(pAddressOfFunctionToCall == IntPtr.Zero)

            MultiplyByTen multiplyByTen = (MultiplyByTen)Marshal.GetDelegateForFunctionPointer(
                                                                                    pAddressOfFunctionToCall,
                                                                                    typeof(MultiplyByTen));

            int theResult = multiplyByTen(14);

            bool result = NativeMethods.FreeLibrary(pDll);
            //remaining code here

            Console.WriteLine(theResult);
            Console.ReadLine();


        }
    }
}
