using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TextParser
{
    public class Word : Composite
    {
        public override void parse(string str)
        {
            foreach (var symbol in str.ToCharArray())
            {
                Symbol s = new Symbol();
                Components.Add(s);
                s.parse(symbol.ToString());
            }
        }

        public override void show()
        {
            foreach (var c in this.Components)
            {
                c.show();
            }
        }
    }
}
