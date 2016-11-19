using DomainObject;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoteContext
{
    public class Context : DbContext
    {
        static Context()
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<Context>());
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<Context, Configuration>());
            //Database.SetInitializer(new ContextInitializer());
        }

        public Context()
        {

        }

        public Context(string ConnecStr)
            : base(ConnecStr)
        {

        }

        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<Raсe> Races { get; set; }
    }
}
