using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events
{
    class Contractor 
    {
        Random r = new Random();
        int unFair; // честность играка
        int dealSize; // какого размера сделки он делает

        public Contractor()
        {
            
            unFair = r.Next(3) * r.Next(3) * r.Next(3);
            dealSize = (int)Math.Pow(10, r.Next(8)); // характерный размер сделки
        }
 
        // метод провести сделку
        public Deal MakeDeal()
        {
            // тоже есть вероятность не честной сделки
            return new Deal(this, r.Next(dealSize / 2, dealSize / 2 * 3), r.Next(100) > unFair);
        }

    }
}
