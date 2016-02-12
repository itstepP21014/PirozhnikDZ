using ConsoleApplication6.Migrations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//ConsoleApplication6.Context.mdf

namespace ConsoleApplication6
{
    public class Context: DbContext
    {
        static Context()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<Context, Configuration>());
        }

        public Context()
        {

        }

        public Context(string ConnecStr)
            : base(ConnecStr)
        {

        }

        public DbSet<Car> Cars { get; set; }
    }
}
