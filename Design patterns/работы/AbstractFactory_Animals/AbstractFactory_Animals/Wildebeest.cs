using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory_Animals
{
    public class Wildebeest: Herbivore
    {
        public Wildebeest(int _weight)
        {
            Weight = _weight;
        }
    }
}
