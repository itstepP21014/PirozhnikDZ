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

        public static List<Service> getServices()
        {
            return db.Servives.ToList();
        }

        public static void add(Branch obj)
        {
            db.Adresses.Add(obj.Adress);
            db.Casheirs.Add(obj.Cashier);
            db.Objects.Add(obj);
            db.SaveChanges();
        }

        public static List<Branch> getObjects()
        {
            return db.Objects.ToList();
        }
        public static void deleteObject(Branch obj)
        {
            if (obj != null)
            {
                db.Objects.Remove(obj);
                db.SaveChanges();
            }
        }

    }
}
