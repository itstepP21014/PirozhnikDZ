using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flowers
{
    public class HeamanthusCreator : FlowersCreator
    {
        public override Flower createFlower()
        {
            Flower result = new Heamanthus();
            result.Name = "Heamanthus";
            return result;
        }
    }
}
