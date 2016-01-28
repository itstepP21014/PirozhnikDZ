using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FileKeys;
using FileRecords;
using FileDataBase;

namespace Base
{
    

    class Program
    {
        static void Main(string[] args)
        {
            DataBase ourBase = new DataBase(@"c:\users\st\basa.csv");

           for(int i = 0; i < ourBase.RecordCount - 1; ++i )
              Console.WriteLine(ourBase.key[i]);



            Console.Read();

        }
    }
}



//@"c:\users\st\1.txt"