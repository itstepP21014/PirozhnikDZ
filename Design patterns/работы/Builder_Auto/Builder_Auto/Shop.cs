using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder_Auto
{
    public class Shop
    {
        public void Construct(Builder builder)
        {
            builder.BuildBody();
            builder.BuildEngine();
            builder.BuildWheel();
            builder.BuildCPP();
        }
    }
}
