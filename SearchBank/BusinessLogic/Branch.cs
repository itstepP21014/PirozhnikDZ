using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class Branch
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual Bank Bank { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        public DateTime DateOpenObject { get; set; }

        public DateTime TimeJobOpen { get; set; }

        public DateTime TimeJobClose { get; set; }

        public DateTime BreakTimeFrom { get; set; }

        public DateTime BreakTimeTo { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }

        public virtual ICollection<Service> Services { get; set; }

        public double CoordX { get; set; }
        public double CoordY { get; set; }

        public override string ToString()
        {
            return Name;
        }


    }
}
