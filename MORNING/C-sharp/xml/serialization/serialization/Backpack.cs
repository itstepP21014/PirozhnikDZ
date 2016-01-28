using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace serialization
{
    [Serializable]
    public class Backpack
    {
        public string brand;

        public Backpack()  {     }

        public Backpack(string _brand)
        {
            brand = _brand;
        }
    }
}
