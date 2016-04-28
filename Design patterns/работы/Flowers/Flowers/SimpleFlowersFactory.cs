using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flowers
{
    class SimpleFlowersFactory
    {
        public Flower createFlower(int type)
        {
            Flower flower = null;
            if (type == 1)
            {
                flower = new Bougainvillea();
            }
            if (type == 2)
            {
                flower = new Anturium();
            }
            if (type == 3)
            {
                flower = new Heamanthus();
            }
            if (type == 4)
            {
                flower = new Ruheliya();
            }
            return flower;
        }
    }
}
