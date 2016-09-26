using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kursovoi_proekt_net_framework
{
    public class MyFile
    {
        public string FilePath { get; set; }

        public string Name { get; set; }

        public string MD5sum { get; set; }

        public bool Clone { get; set; }

        public MyFile()
        {
            FilePath = null;
            Name = null;
            MD5sum = null;
            Clone = false;
        }

    }

    
}
