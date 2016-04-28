using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory_Animals
{
    public class Bison: Herbivore
    {
        public Bison(int _weight)
        {
            Weight = _weight;
        }
    }
}
