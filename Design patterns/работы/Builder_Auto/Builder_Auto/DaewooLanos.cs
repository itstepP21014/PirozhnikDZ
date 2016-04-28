using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder_Auto
{
    public class DaewooLanos: Builder
    {
        private readonly Product product = new Product();
        public override void BuildBody()
        {
            product.Add("Седан");
        }

        public override void BuildEngine()
        {
            product.Add("98");
        }

        public override void BuildWheel()
        {
            product.Add("13");
        }

        public override void BuildCPP()
        {
            product.Add("5 Manual");
        }

        public override Product GetResult()
        {
            return product;
        }
    }
}
