using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary
{
    public class Adress
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int Build { get; set; }
        public int Body { get; set; }
        public int Cabinet { get; set; }
        public ICollection<Branch> Objects { get; set; }
        
    }
}
