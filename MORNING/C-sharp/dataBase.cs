using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Record
    {
        string firstName;
        string lastName;
        string pasport;

        public Record(string fn, string ln, string p)
        {
            firstName = fn;
            lastName = ln;
            pasport = p;
        }

        public void add(Record newItem)
        {

        }
    }


    class Key
    {
        public List<int> keys = new List<int>();

        public Key(string filePath)
        {

            keys.Add(0);

            try
            {

                using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    int bufferSize = 1024;
                    byte[] readBytes = new byte[bufferSize];
                    int xxx = 0;
                    int r;

                    do
                    {
                        fs.Seek(xxx, SeekOrigin.Begin);
                        r = fs.Read(readBytes, 0, readBytes.Length);
                        for (int i = xxx; i < r; ++i)
                        {
                            if (readBytes[i] == 10)
                            {
                                xxx = i + 1;
                                keys.Add(xxx);
                            }
                        }
                    } while (r > bufferSize);
                }
            }
            catch (FileNotFoundException ioEx)
            {
                Console.WriteLine(ioEx.Message);
            }
        }
    }







    class Program
    {
        static void Main(string[] args)
        {
            string pathSource = @"c:\users\st\basa.csv";
            Key keys = new Key(pathSource);

            foreach(var k in keys.keys) {
                Console.WriteLine(k);
            }

            Console.Read();

        }
    }
}



//@"c:\users\st\1.txt"
