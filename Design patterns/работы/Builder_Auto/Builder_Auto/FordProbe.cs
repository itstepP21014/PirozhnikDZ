using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder_Auto
{
    public class FordProbe: Builder
    {
        private readonly Product product = new Product();
        public override void BuildBody()
        {
            product.Add("Купе");
        }

        public override void BuildEngine()
        {
            product.Add("160");
        }

        public override void BuildWheel()
        {
            product.Add("14");
        }

        public override void BuildCPP()
        {
            product.Add("4 Auto");
        }

        public override Product GetResult()
        {
            return product;
        }
    }
}
