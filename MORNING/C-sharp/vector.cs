using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Vector {

        int x, y, z;

        public Vector(int a, int b, int c) {
            x = a;
            y = b;
            z = c;
        }

        public void output()
        {
            Console.Write(""+x+ " "+ y+ " "+ z+ "\n");
        }

        public Vector add(Vector v) {
            x += v.x;
            y += v.y;
            z += v.z;
            return this;
        }

        public static  Vector vctr_mult(Vector a, Vector b) {
            Vector current = new Vector(a.y * b.z - a.z * b.y, a.x * b.z - a.z * b.x, a.x * b.y - a.y * b.x);
            return current;
        }

        public static int sclr_mult(Vector a, Vector b)
        {
            int res = a.x * b.x + a.y * b.y + a.z * b.z;
            return res;
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Vector v1 = new Vector(1, 2, 3);
            Vector v2 = new Vector(0, 1, 2);

            v1.output();
            v2.output();

            v1.add(v2);
            v1.output();

            Vector v3 = Vector.vctr_mult(v1, v2);
            v3.output();

            int sclr = Vector.sclr_mult(v1, v2);
            Console.WriteLine(sclr);

            Console.ReadLine();

        }
    }
}
