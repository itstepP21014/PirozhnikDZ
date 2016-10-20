using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TextParser
{
    public class Paragraph : Composite
    {
        public override void parse(string str)
        {
            var sentences = Regex.Matches(str, @"[\w].{15,}?(\.|\!|\?)(?=\ |\r|\n|$)");

            foreach (var sentence in sentences)
            {
                Sentance sen = new Sentance();
                this.Components.Add(sen);
                sen.parse(sentence.ToString());
            }
        }

        public override void show()
        {
            foreach (var s in this.Components)
            {
                s.show();
                Console.Write(" ");
            }
        }
    }
}
