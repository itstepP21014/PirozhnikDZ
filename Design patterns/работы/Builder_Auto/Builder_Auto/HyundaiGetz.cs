using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder_Auto
{
    public class HyundaiGetz: Builder
    {
        private Product product = new Product();
        public override void BuildBody()
        {
            product.Add("Хэтчбэк");
        }

        public override void BuildEngine()
        {
            product.Add("66");
        }

        public override void BuildWheel()
        {
            product.Add("13");
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
