using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory_Animals
{
    public class AnimalWorld
    {
        Random r = new Random();
        public AnimalWorld(string _continent)
        {
            if(_continent == "America")
            {
                continent = America.getInstatnce();
                
            }
            if(_continent == "Africa")
            {
                continent = Africa.getInstatnce();
            }

            int count = r.Next(5, 10);
            for (int i = 0; i < count; ++i)
            {
                herbivoreCollection.Add(continent.createHerbivore());
                carnivoreCollection.Add(continent.createCarnivore());
            }

        }

        public Continent continent;
        public List<Herbivore> herbivoreCollection = new List<Herbivore>();
        public List<Carnivore> carnivoreCollection = new List<Carnivore>();

        public void mealsHerbivores()
        {
            foreach(var h in herbivoreCollection)
            {
                h.eatGrass();
            }
        }
        public void nutritionCarnivores()
        {
            int index = 0;
            for (int i = 0; i < carnivoreCollection.Count; ++i)
            {
                if (herbivoreCollection.Count != 0)
                {
                    index = r.Next(0, (herbivoreCollection.Count - 1));
                    if (carnivoreCollection[i].eat(herbivoreCollection[index]))
                    {
                        herbivoreCollection.Remove(herbivoreCollection[index]);
                    }
                    else
                    {
                        if (carnivoreCollection[i].Power <= 0)
                        {
                            carnivoreCollection.Remove(carnivoreCollection[i]);
                        }
                    }
                }
            }
        }

    }
}
