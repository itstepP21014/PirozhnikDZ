using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flowers
{
    public class BougainvilleaCreator : FlowersCreator
    {
        public override Flower createFlower()
        {
            Flower result = new Bougainvillea();
            result.Name = "Bougainvillea";
            return result;
        }
    }
}
