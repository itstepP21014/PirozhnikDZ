using DomainObjects;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataContext
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

        public DbSet<News> News { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}
