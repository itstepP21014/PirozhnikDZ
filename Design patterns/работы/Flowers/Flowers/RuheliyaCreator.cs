using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flowers
{
    public class RuheliyaCreator : FlowersCreator
    {
        public override Flower createFlower()
        {
            Flower result = new Ruheliya();
            result.Name = "Ruheliya";
            return result;
        }
    }
}
