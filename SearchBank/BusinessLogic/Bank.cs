using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class Bank
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int BankIdXML { get; set; }

        public DateTime TimeUpdateCourses { get; set; }

        public decimal SellDollar { get; set; }

        public decimal SellEuro { get; set; }

        public decimal SellRussianRub { get; set; }

        public decimal BuyDollar { get; set; }

        public decimal BuyEuro { get; set; }

        public decimal BuyRussianRub { get; set; }

        public virtual ICollection<Branch> Branchs { get; set; }

        public override string ToString()
        {
            return Name;
        }

    }
}
