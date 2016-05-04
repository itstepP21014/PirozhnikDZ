using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace TextParser_CompositePattern
{
    public class Text: Composite
    {
        public override void parse(string str)
        {
            string[] paragraph_collection = str.Split('\n');

            foreach(var coll_el in paragraph_collection)
            {
                Paragraph par = new Paragraph();
                Components.Add(par);
                par.parse(coll_el);
            }
      
            // занести стринги в коллекцию!!!
        }

        public override void show()
        {
            foreach(var p in Components)
            {
                p.show();
            }
        }

    }
}
