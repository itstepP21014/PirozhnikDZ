using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transport
{
    public class BusInfo
    {
        [ForeignKey("Bus")]
        public int Id { get; set; }
        public ICollection<Stop> Stops { get; set; }
        public ICollection<MyTime> Time { get; set; }
        public Bus Bus { get; set; }
    }
}
