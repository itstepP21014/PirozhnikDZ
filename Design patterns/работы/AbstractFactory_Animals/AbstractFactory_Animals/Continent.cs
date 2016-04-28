using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory_Animals
{
    public abstract class Continent
    {
        public Random r = new Random();
        public abstract Herbivore createHerbivore();
        public abstract Carnivore createCarnivore();
    }
}
