using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextParser_CompositePattern
{
    public class Symbol: Leaf
    {
        public string InnerText { get; set; }
        public string Str { get; set; }
        public override void parse(string str)
        {
            Str = str;
        }

        public override void show()
        {
            InnerText = Str;
        }
    }
}
