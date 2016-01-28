using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
   static class NativeMethods
    {
       //// статическая загрузка
       // [DllImport("C:/users/st/Documents/Visual Studio 2013/Projects/ConsoleApplication1/Debug/ConsoleApplication1.dll", CallingConvention = CallingConvention.Cdecl)]
       // public static extern int MultiplyByTen(int n);

        [DllImport("kernel32.dll")]
        public static extern IntPtr LoadLibrary(string dllToLoad);

        [DllImport("kernel32.dll")]
        public static extern IntPtr GetProcAddress(IntPtr hModule, string procedureName);

        [DllImport("kernel32.dll")]
        public static extern bool FreeLibrary(IntPtr hModule);


    }
}
