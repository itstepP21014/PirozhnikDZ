using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transport
{
    public class Stop
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public StopInfo StopInfo { get; set; }
    }
}
