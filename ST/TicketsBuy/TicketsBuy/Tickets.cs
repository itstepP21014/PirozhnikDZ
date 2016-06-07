using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketsBuy
{
    public class Tickets
    {
        public int Id { get; set; }
        public string Dispatch_station { get; set; }
        public string Arrival_station { get; set; }
        public string Time { get; set; }
        public int Count { get; set; }
    }
}
