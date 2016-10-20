using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class Service
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Branch> Branchs { get; set; }

        public override string ToString()
        {
            return Name;
        }

    }
}
