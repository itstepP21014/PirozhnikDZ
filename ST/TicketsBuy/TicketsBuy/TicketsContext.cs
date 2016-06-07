using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketsBuy
{
    public class TicketsContext: DbContext
    {
        public TicketsContext()
            : base("DefaultConnection")
        {
 
        }
        public DbSet<Tickets> Tickets { get; set; }
    }
}
