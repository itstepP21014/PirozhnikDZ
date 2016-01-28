using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace traffic
{

    class Program
    {

       public static Random r = new Random();

       public static Station[] stations = new Station[] { new Station("Малиновка"), new Station("Петровщина"),
            new Station("Михалово"), new Station("Грушевка"), new Station("Институт Культуры"),
            new Station("Площадь Ленина"), new Station("Октябрьская")};


        static void Main(string[] args)
        {

            for (int i = 0; i < stations.Length; ++i )
            {
                Passenger p = new Passenger(0, stations[i]);
                EventQueue.Add(0, p.onNewPassenger);
                Train t = new Train(5, stations[i]);
                EventQueue.Add(0, t.onNewTrain);
            }

            EventQueue.Start();

            Console.ReadKey();

        }
    }
}
