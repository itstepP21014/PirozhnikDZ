using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TextParser_CompositePattern
{
    public class Sentance: Composite
    {
        public override void parse(string str)
        {
            // написать регулярку!!!

            Regex WordsRegex = new Regex(@"([\t\S.\r\n ]+?[.!?])(\s+|$)(\r\n)*|.?$", RegexOptions.Singleline);
            foreach (Match CurrentMatch in WordsRegex.Matches(str))
            {
                Word w = new Word();
                this.Components.Add(w);
                w.parse(CurrentMatch.Value.ToString());
            }

            // занести стринги в коллекцию!!!
        }

        public override void show()
        {
            foreach (var w in this.Components)
            {
                w.show();
            }

        }
    }
}
