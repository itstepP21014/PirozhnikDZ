using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flowers
{
    class Program
    {
        //static void Main222(string[] args)
        //{
        //    SimpleFlowersFactory factory = new SimpleFlowersFactory();
        //    Console.WriteLine("Введите название цветка, который вы хотите приобрести\n1) Ruheliya\n2) Bougainvillea\n3) Heamanthus\n4) Anturium");
        //    string flower = Console.ReadLine();
        //    Flower f = factory.createFlower(flower);
        //    Console.WriteLine("Вы приобрели цветок " + flower + " и ...\n");
        //    f.transplant();
        //    f.water();
        //    f.spray();

        //    Console.Read();
        //}


        static void Main(string[] args)
        {
            Random r = new Random();
            Console.WriteLine("Перечень цветов, которые могут входить в букет:\n\n1) Ruheliya\n2) Bougainvillea\n3) Heamanthus\n4) Anturium");
            Console.WriteLine("\nДля генерирования случайного букета нажмите любую клавишу\n");
            Console.ReadKey();
            Console.WriteLine("В букет вошли следующие цветы:\n");

            FlowersCreator fc = null;
            for(int i = 0; i < 20; ++i)
            {
                switch(r.Next(1, 4))
                {
                    case 1:
                        fc = new RuheliyaCreator();
                        break;
                    case 2:
                        fc = new HeamanthusCreator();
                        break;
                    case 3:
                        fc = new AnturiumCreator();
                        break;
                    case 4:
                        fc = new BougainvilleaCreator();
                        break;
                }
                Flower f = fc.createFlower();
                Console.WriteLine(f.Name);
            }

            Console.Read();
        }
    }
}


//создать такой класс у которого будет только один экземпляр