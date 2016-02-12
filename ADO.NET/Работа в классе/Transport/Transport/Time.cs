using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transport
{
    public class MyTime
    {
        public MyTime(string t)
        {
            Time = t;
        }
        public int Id { get; set; }
        public string Time { get; set; }
    }
}
