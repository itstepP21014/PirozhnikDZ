using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory_Animals
{
    public abstract class Carnivore
    {
        public int Power { get; set; }
        public bool eat(Herbivore h)
        {
            if(Power > h.Weight)
            {
                Power += 10;
                h.Life = false;
                return true;
            }
            else
            {
                Power -= 10;
                return false;
            }
        }
    }
}
