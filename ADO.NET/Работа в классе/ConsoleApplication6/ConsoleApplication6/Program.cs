﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication6
{
    class Program
    {
        static void Main(string[] args)
        {
            string CS = @"Data Source=(localdb)\v11.0;AttachDbFilename=D:\KIN\DB\ConsoleApplication6.Context.mdf;Integrated Security=True";
            //Initial Catalog=Name.mdf вместо AttachDbFilename=D:\KIN\DB\Name.Context.mdf
            Context db = new Context(CS);
            Car car = new Car() { Name = "BMW", Fuel = 50, Speed = 500 };
            db.Cars.Add(car);
            db.SaveChanges();

            foreach (var item in db.Cars)
            {
                Console.WriteLine("{0}-{1}-{2}", item.Name, item.Fuel, item.Speed);
            }



            Console.ReadKey();
        }
    }
}
