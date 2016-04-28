using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory_Animals
{
    public class America: Continent
    {
        private America() { }

        private static America instance;

        public static America getInstatnce()
	    {
		    if(instance == null)
		    {
                instance = new America();
		    }
		    return instance;
	    }

        public override Herbivore createHerbivore()
        {
            return new Bison(r.Next(5, 20));
        }
        public override Carnivore createCarnivore()
        {
            return new Wolf(r.Next(10, 30));
        }
    }
}
