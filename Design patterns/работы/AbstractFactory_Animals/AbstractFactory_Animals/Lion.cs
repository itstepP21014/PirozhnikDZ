using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory_Animals
{
    public class Lion: Carnivore
    {
        public Lion(int _power)
        {
            Power = _power;
        }
    }
}
