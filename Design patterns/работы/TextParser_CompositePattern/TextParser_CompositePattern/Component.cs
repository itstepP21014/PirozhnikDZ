using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextParser_CompositePattern
{
    public abstract class Component
    {
        public void parse(string str);
        public void show();
    }
}
