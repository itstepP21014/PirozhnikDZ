using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixProject
{
    class Element
    {
        public int[,] a{get; set;}
        public int[,] b{get; set;}
        public int[,] c{get; set;}

        public int n{get; set;}
        public int m{get; set;}
        public int k{get; set;}
        public Element(int[,] _a, int[,] _b, int[,] _c, int _n, int _m, int _k)
        {
            a = _a;
            b = _b;
            c = _c;
            n = _n;
            m = _m;
            k = _k;
        }
    }
}
