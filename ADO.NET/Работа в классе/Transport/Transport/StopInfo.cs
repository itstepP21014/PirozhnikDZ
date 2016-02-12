using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transport
{
    public class StopInfo
    {
        [ForeignKey("Stop")]
        public int Id { get; set; }
        public ICollection<Bus> Buses { get; set; }
        public ICollection<MyTime> Time { get; set; }
        public Stop Stop { get; set; }
    }
}
