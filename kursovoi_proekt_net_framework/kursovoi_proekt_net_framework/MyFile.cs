using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kursovoi_proekt_net_framework
{
    public class MyFile
    {
        public string Path { get; set; }

        public string MD5sum { get; set; }

        public MyFile()
        {
            Path = "";
            MD5sum = "";
        }
    }
}
