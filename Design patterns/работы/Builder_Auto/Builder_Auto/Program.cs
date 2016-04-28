using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder_Auto
{
    class Program
    {

        public static void Main()
        {
            // Create director and builders
            Shop director = new Shop();
            Builder b1 = new DaewooLanos();
            Builder b2 = new FordProbe();
            Builder b3 = new UAZPatriot();
            Builder b4 = new HyundaiGetz();
            // Construct two products
            director.Construct(b1);
            Product p1 = b1.GetResult();
            p1.Show();
            director.Construct(b2);
            Product p2 = b2.GetResult();
            p2.Show();
            director.Construct(b3);
            Product p3 = b3.GetResult();
            p3.Show();
            director.Construct(b4);
            Product p4 = b4.GetResult();
            p4.Show();
            // Wait for user
            Console.Read();
        }


       
    }
}
