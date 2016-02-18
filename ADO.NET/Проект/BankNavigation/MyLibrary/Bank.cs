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
        public decimal DollarSell { get; set; }
        public decimal DollarBuy { get; set; }
        public decimal EuroSell { get; set; }
        public decimal EuroBuy { get; set; }
        public decimal RussSell { get; set; }
        public decimal RussBuy { get; set; }
        public ICollection<Branch> Objects { get; set; }
    }
}
