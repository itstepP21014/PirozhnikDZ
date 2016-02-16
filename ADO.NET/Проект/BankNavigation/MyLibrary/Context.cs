using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary
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

        public DbSet<Branch> Objects { get; set; }
        public DbSet<Bank> Banks { get; set; }
        public DbSet<Adress> Adresses { get; set; }
        public DbSet<Cashier> Casheirs { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Service> Servives { get; set; }
    

    }
}
