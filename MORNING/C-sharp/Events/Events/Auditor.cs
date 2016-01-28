using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events
{
    class Auditor
    {
        static Random r = new Random();
        private int pError = 10; // конкретно взятый аудитор имеет вероятность ошибиться в 10% случаев( как в одну, так и в другую сторону)

        //public Auditor()
        //{
        //    pError = r.Next(3) * r.Next(3) * r.Next(3);
        //}


        // метод провести аудит
        public bool Check(Deal d)
        {
            //Console.WriteLine("Проводим аудит");

            bool res = d.isFair;

            if (r.Next(100) < pError)
            {
                res = !res;
            }

            return res;
        }

        
    }
}
