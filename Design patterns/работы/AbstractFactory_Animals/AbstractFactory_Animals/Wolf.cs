using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory_Animals
{
    public class Wolf: Carnivore
    {
        public Wolf(int _power)
        {
            Power = _power;
        }
    }
}
