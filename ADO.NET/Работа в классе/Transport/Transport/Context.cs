using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transport
{
    public class Context : DbContext
    {
        static Context()
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<Context>());
        }

        public Context()
        {

        }

        public Context(string ConnecStr)
            : base(ConnecStr)
        {

        }

        public DbSet<Stop> Stops { get; set; }
        public DbSet<Bus> Buses { get; set; }
        public DbSet<BusInfo> BusInfo { get; set; }
        public DbSet<StopInfo> StopInfo { get; set; }
        public DbSet<MyTime> Times { get; set; }

    }
}
