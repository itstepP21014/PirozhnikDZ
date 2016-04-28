using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder_Auto
{
    public abstract class Builder
    {
        public abstract void BuildBody();
        public abstract void BuildEngine();
        public abstract void BuildWheel();
        public abstract void BuildCPP();
        public abstract Product GetResult();
    }
}
