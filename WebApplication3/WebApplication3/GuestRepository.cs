using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication3
{
    // класс-сингелтон для хранения юзеров
    public class GuestRepository
    {
        private GuestRepository() { }
        private static object lck = new Object();
        public static GuestRepository instance = null;

        private List<Guest> guests = new List<Guest>();

        public static GuestRepository getInstance()
        {
            if (instance == null)
            {
                lock (lck)
                {
                    if (instance == null)
                        instance = new GuestRepository();
                }
            }   
            return instance;
        }

        public IEnumerable<Guest> GetAllGuest()
        {
            return guests;
        }

        public void AddResponse(Guest response)
        {
            guests.Add(response);
        }

    }
}