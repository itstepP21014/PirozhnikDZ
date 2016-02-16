using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary
{
    public class Bank
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Dollar { get; set; }
        public decimal Euro { get; set; }
        public decimal Russ { get; set; }
        public ICollection<Branch> Objects { get; set; }
    }
}
