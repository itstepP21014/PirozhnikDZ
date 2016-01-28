using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Заправка
{
    public class Goods
    {
        public string name;
        public int cost;

        public Goods(string _name, int _cost)
        {
            name = _name;
            cost = _cost;
        }

        public Goods()
        {

        }
    }
}
