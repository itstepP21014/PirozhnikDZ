using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory_Animals
{
    public abstract class Herbivore
    {
        public int Weight { get; set; }
        public bool Life { get; set; }
        public void eatGrass()
        {
            Weight += 10;
        }
    }
}
