using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Transport
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

            string CS = @"Data Source=(localdb)\v11.0;AttachDbFilename=D:\KIN\DB\Transport.Context.mdf;Integrated Security=True";
            //Initial Catalog=Name.mdf вместо AttachDbFilename=D:\KIN\DB\Name.Context.mdf
            Context db = new Context(CS);

            

            Bus bus1 = new Bus() { Number = 15, Route = "Начало - Конец" };
            Bus bus2 = new Bus() { Number = 22, Route = "Начало2 - Конец2" };

            MyTime time1 = new MyTime("09:40");
            MyTime time2 = new MyTime("10:45");



            StopInfo si_1 = new StopInfo()
            {
                Buses = new List<Bus>()
                {
                    bus1, bus2

                },
                Time = new List<MyTime>()
                {
                    time1, time2
                }
            };

            db.StopInfo.Add(si_1);

            StopInfo si_2 = new StopInfo()
            {
                Buses = new List<Bus>()
                {
                    bus2

                },
                Time = new List<MyTime>()
                {
                    time1
                }
            };

            db.StopInfo.Add(si_2);

            Stop stop1 = new Stop() { Name = "Громова"};
            Stop stop2 = new Stop() { Name = "Детский сад"};
            Stop stop3 = new Stop() { Name = "Поликоиника"};

            db.SaveChanges();
        }
    }
}
