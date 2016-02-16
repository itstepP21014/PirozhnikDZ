using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary
{
    public class Service
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Branch> Objects { get; set; }
    }
}
