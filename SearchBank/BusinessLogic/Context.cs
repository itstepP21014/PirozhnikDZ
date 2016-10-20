using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class Context:DbContext
    {
        static Context()
        {
           Database.SetInitializer( new ContextInitializer());
        }

        public Context()
            : base("name = Connection")
        { }


        public DbSet<Bank> Banks  { get; set; }
        public DbSet<Branch> Branchs { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Service> Services { get; set; }
    }
}
