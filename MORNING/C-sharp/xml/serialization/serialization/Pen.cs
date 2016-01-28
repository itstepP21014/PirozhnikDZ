using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace serialization
{
    [Serializable]
    public class Pen
    {
        public string colour;

        public Pen() { }

        public Pen(string _colour)
        {
            colour = _colour;
        }
    }
}
