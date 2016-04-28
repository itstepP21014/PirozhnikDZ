using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory_Animals
{
    class Program
    {
        static void Main(string[] args)
        {
            AnimalWorld world = new AnimalWorld("America");
            Console.WriteLine("Перед кормешкой Травоядных: " + world.herbivoreCollection.Count + " Хищников: " + world.carnivoreCollection.Count);
            world.mealsHerbivores();
            world.nutritionCarnivores();
            Console.WriteLine("После кормешки осталось Травоядных: " + world.herbivoreCollection.Count + " Хищников: " + world.carnivoreCollection.Count);

            

            

            //if(c.eat(h))
            //{
            //    world.herbivoreCollection.Remove(h);
            //}
            

        }
    }
}
