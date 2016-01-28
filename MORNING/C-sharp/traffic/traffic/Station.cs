using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace traffic
{
    class Station
    {
        public string name;
        public readonly uint average_period;
        public Queue<Passenger> passengers_queue;

        public Station(string _name)
        {
            name = _name;
            passengers_queue = new Queue<Passenger>();
            
        }
    }
}
