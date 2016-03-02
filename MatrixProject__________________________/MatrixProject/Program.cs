using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Matrix m1 = new Matrix(200,4);
            m1.ShowMatrix();
            Console.Write("\n");
            Matrix m2 = new Matrix(4,300);
            m2.ShowMatrix();
            Console.Write("\n");
            Matrix m3 = new Matrix(200,300);
            m3 = m1 * m2;
            m3.ShowMatrix();
            Console.Write("\n");

        }
    }
}
