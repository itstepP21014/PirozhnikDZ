using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MatrixProject
{
    class Matrix
    {
        public int n, m;
        public Random r = new Random();
        public int[,] arr;

        public Matrix(int _n, int _m)
        {
            n = _n;
            m = _m;
            arr = new int[n, m];

            for(int i = 0; i < n; ++i)
            {
                for(int j = 0; j < m; ++j)
                {
                    arr[i, j] = r.Next(1, 10);
                }
            }
        }

        public void ShowMatrix()
        {
            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < m; ++j)
                {
                    Console.Write("{0}\t", arr[i, j]);
                }
                Console.Write("\n");
            }
        }

        static public Matrix operator *(Matrix a, Matrix b)
        {
            Matrix m = new Matrix(a.n, b.m);
            m.arr = new int[a.n, b.m];
            
            for (int I = 0; I < a.n; I++)
            {
                for (int J = 0; J < b.m; J++)
                {
                    m.arr[I, J] = 0;
                }
            }

            List<Ele> ele = new List<Ele>();

            for (int i = 0; i < a.n; ++i)
            {
                for (int j = 0; j < b.m; ++j)
                {
                    //добавляем в очередь
                    ele.Add(new Ele(i, j));

                    //Thread t = new Thread(new ParameterizedThreadStart(mult));
                    //t.Start(new Element(a.arr, b.arr, m.arr, i, j, a.m));
                }
                
            }

            //мы запускаем 20 потоков
            List<Thread> threadList = new List<Thread>();
            for (int i = 0; i < 20; ++i)
            {
                threadList.Add(new Thread(new ParameterizedThreadStart(mult)));
            }
            

            return m;
        }

        static public void mult(object obj)
        {
            Element e = (Element)obj;
            for (int i = 0; i < e.k; ++i)
            {
                e.c[e.n, e.m] += e.a[e.n, i] * e.b[i, e.m];
            }
            while (true) { 
            //ттаааккк, где поле класса которое хранит коллееукцию с задачами?
            //если оно не пусто - берем и делаем
            //ищем снова
               
            //если задач нет - тогда выйти из цикла
            }
        }
    }
}
