using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory_Animals
{
    public class Africa: Continent
    {
        private Africa() { }

        private static Africa instance;

        public static Africa getInstatnce()
	    {
		    if(instance == null)
		    {
                instance = new Africa();
		    }
		    return instance;
	    }

        public override Herbivore createHerbivore()
        {
            return new Wildebeest(r.Next(5, 20));
        }
        public override Carnivore createCarnivore()
        {
            return new Lion(r.Next(10, 30));
        }
    }
}
