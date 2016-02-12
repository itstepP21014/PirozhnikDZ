using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transport
{
    public class Bus
    {
        public int Id { get; set; }
        public int Number { get; set;}
        public string Route { get; set; }
        public BusInfo BusInfo { get; set; }
    }
}
