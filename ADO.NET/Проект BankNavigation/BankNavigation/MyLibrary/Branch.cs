using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary
{
    public class Branch
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Bank Bank { get; set; }
        public string Phone { get; set; }
        public Adress Adress { get; set; }
        public double XPosition { get; set; }
        public double YPositon { get; set; }
        public DateTime CreationDate { get; set; }
        public string Time { get; set; }
        public Cashier Cashier { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Service> Services { get; set; }
    }
}
