using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace traffic
{
    class Train
    {
        public int available_seats;
        public uint period;
        public List<Passenger> passengers;
        static int max_count_of_seats = 250;
        public Station arrival_station;


        public Train(uint time, Station _station)
        {
            arrival_station = _station;
            available_seats = max_count_of_seats;
            Console.WriteLine("A train comes at {0} to station {1}", time, arrival_station.name);
        }

        public void onNewTrain(uint time)
        {
            // пассажиры выходят из поезда

            // пассажиры заходят со станции, либо пока поезд не заполнится, либо пока не закончатся пассажиры
            // планируем приход поезда на следующую станцию
            EventQueue.Add(time + (uint)Program.r.Next(3, 8), this.onNewTrain);
            // перейти на следующую станцию
            
        }

        public int SetSeats(int count_of_entering_people)
        {
            if (available_seats > count_of_entering_people)
            {
                available_seats -= count_of_entering_people;
                return 0;
            }
            else
            {
                int res = count_of_entering_people - available_seats;
                available_seats = 0;
                return res;
            }
        }
    }
}
