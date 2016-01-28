using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileRecords;

namespace FileKeys
{
    class Key
    {
        readonly string sourse;
        public List<int> keys = new List<int>();

        public Key(string filePath)
        {
            sourse = filePath;
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

        public Record this[int index]
        {
            get
            {
                string str;
                using (FileStream fs = new FileStream(sourse, FileMode.Open, FileAccess.Read))
                {
                    
                    int bufferSize = (keys[index + 1] - keys[index]);
                    fs.Seek(keys[index], SeekOrigin.Begin);
                    byte[] readBytes = new byte[bufferSize];
                    fs.Read(readBytes, 0, readBytes.Length);
                    str = Encoding.UTF8.GetString(readBytes);
                }
                Record res = new Record(str);
                return res;
            }
        }


    }
}

