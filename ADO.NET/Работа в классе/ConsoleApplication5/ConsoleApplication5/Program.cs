using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication5
{
    class Program
    {
        static void Main(string[] args)
        {
            Model1Container db = new Model1Container();
            Car car = new Car();
            car.Name = "BMW";
            car.Fuel = 50;

            car.ComplexProperty1 = new ComplexType1() {  id=1, name="qwerty"};
           

            Table2 dr = new Table2();
            dr.Name = "Ivanov";
            dr.Adress = "Minsk";



            car.Table2.Add(dr);

            db.CarSet.Add(car);

            db.SaveChanges();

            


        }
    }
}
