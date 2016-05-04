using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TextParser_CompositePattern
{
    public class Word: Composite
    {
        public override void parse(string str)
        {
            var symbols = Regex.Matches(str, @"");

            foreach (var symbol in symbols)
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
