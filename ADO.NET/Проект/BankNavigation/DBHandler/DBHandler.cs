using MyLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace DBHandler
{
    static public class DBHandler
    {
        static BankNavigationContext db;
        static DBHandler()
        {

        }

        public static void Initialize(string connectionString)
        {
              db = new BankNavigationContext(connectionString);
        }
    }
}
