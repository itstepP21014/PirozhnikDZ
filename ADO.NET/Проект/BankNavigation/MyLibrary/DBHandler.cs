using MyLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary
{
    static public class DBHandler
    {
        static BankNavigationContext db;
        static DBHandler()
        {
            db = new BankNavigationContext();
        }

        public static List<Bank> getBanks()
        {
            return db.Banks.ToList();
        }
        public static List<Cashier> getCashiers()
        {
            return db.Casheirs.ToList();
        }
        public static List<Service> getServices()
        {
            return db.Servives.ToList();
        }


    }
}
