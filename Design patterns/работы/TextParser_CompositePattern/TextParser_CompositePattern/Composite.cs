using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextParser_CompositePattern
{
    public abstract class Composite : Component
    {
        public List<Component> Components { get; set; }


        public Composite()
        {
            Components = new List<Component>();
        }
    }
}
