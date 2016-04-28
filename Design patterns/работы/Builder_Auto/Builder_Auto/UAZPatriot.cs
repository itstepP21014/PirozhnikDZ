using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder_Auto
{
    public class UAZPatriot: Builder
    {
        private Product product = new Product();
        public override void BuildBody()
        {
            product.Add("Универсал");
        }

        public override void BuildEngine()
        {
            product.Add("120");
        }

        public override void BuildWheel()
        {
            product.Add("16");
        }

        public override void BuildCPP()
        {
            product.Add("4 Manual");
        }

        public override Product GetResult()
        {
            return product;
        }
    }
}
