using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flowers
{
    public class AnturiumCreator: FlowersCreator
    {
        public override Flower createFlower()
        {
            Flower result = new Anturium();
            result.Name = "Anturium";
            return result;
        }
    }
}
