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
            // написать регулярку!!!

            Regex CharRegex = new Regex(@"([\t\S.\r\n ]+?[.!?])(\s+|$)(\r\n)*|.?$", RegexOptions.Singleline);
            foreach (Match CurrentMatch in CharRegex.Matches(str))
            {
                Symbol sym = new Symbol();
                this.Components.Add(sym);
                sym.parse(CurrentMatch.Value.ToString());
            }

            // занести стринги в коллекцию!!!
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
