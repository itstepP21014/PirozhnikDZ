using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace traffic
{
    class Passenger
    {
        public Station from, to;
        uint time_arrival_to_station;

        public Passenger(uint time, Station _from)
        {
            from = _from;
            Console.WriteLine("A passenger comes at {0} to station {1}", time, from.name);
        }

        public void onNewPassenger(uint time)
        {
            var p = new Passenger(time, from);
            // ставим его в очередь
            from.passengers_queue.Enqueue(p);

            // решаем куда он поедет
            Station exit_station = Program.stations[Program.r.Next(Program.stations.Length)];
            while (exit_station == from)
            {
                exit_station = Program.stations[Program.r.Next(Program.stations.Length)];
            }
            to = exit_station;

            // пассажир должен запомнить время, когда он пришел на станцию
            time_arrival_to_station = time;

            // планируем приход еще одного пассажира на станцию
            EventQueue.Add(time + (uint)Program.r.Next(7), p.onNewPassenger);
        }

    }
}
