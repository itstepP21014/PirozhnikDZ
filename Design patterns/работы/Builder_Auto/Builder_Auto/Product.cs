using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder_Auto
{
    public class Product
    {
        private readonly List<string> parts = new List<string>();
        public void Add(string part)
        {
            parts.Add(part);
        }
        public void Show()
        {
            Console.WriteLine("\nProduct Parts ------- ");
            foreach (string part in parts)
                Console.WriteLine(part);
        }
    }
}
