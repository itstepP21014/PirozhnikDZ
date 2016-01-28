using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace traffic
{
    delegate void TransportEvent(uint currentTime);

    class EventQueue
    {
        private static SortedDictionary<uint, LinkedList<TransportEvent>> eventQueue;

        static EventQueue()
        {
            eventQueue = new SortedDictionary<uint, LinkedList<TransportEvent>>();
        }
            
        public static void Add(uint time, TransportEvent ev)
        {
            if (!eventQueue.ContainsKey(time))
            {
                eventQueue[time] = new LinkedList<TransportEvent>();
            }

            eventQueue[time].AddLast(ev);
            
        }

        // метод, возвращающий первое событие из очереди
        public static bool getFollowingEvent(out uint time, out TransportEvent ev) 
        {
            if (eventQueue.Values.First().First.Value == null)
            {
                time = 0;
                ev = null;
                return false;
            }

            time = eventQueue.Keys.First();
            ev = eventQueue.Values.First().First.Value;
            return true;
        }

        // метод, удаляющий первое событие
        public static void Remove()
        {
            var time = eventQueue.Keys.First();

            eventQueue[time].RemoveFirst();

            if (eventQueue[time].Count == 0)
            {
                eventQueue.Remove(time);
            }
        }

        public static void Start()
        {
            while (eventQueue.Count != 0)
            {

                uint time;
                TransportEvent ev;
                if (getFollowingEvent(out time, out  ev))
                {
                    ev(time);
                }
                else
                {
                    throw new KeyNotFoundException("Error: In getFollowingEvent\n");
                }

                EventQueue.Remove();

            }
        }

    }
}
