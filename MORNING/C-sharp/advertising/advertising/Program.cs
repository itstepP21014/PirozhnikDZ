using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace advertising
{
    class Order
    {
        public string clip;
        public uint duration;
        public uint times; // сколько раз должно быть в эфире

        public Order(string clp, uint dur, uint buy_t)
        {
            this.clip = clp;
            this.duration = dur;
            this.times = buy_t;
        }
    }

    class Report
    {
        public string clip;
        public uint time;
        public uint tv;

        public Report(string clp, uint t, uint tv)
        {
            this.clip = clp;
            this.time = t;
            this.tv = tv;
        }

    }


    class Program
    {
        public List<int> xxx(List<Order> list)
        {
            List<int> res = new List<int>();
            for (int i = 0; i < list.Count; i++)
            {
                res.Add((int)list[i].times); // подправить
            }
            return res;
        }

        static void Main(string[] args)
        {
            List<Order> order_list = new List<Order>();
            order_list.Add(new Order("1.mp4", 50, 144));  //  144
            order_list.Add(new Order("2.mp4", 45, 133));  // 277
            order_list.Add(new Order("3.mp4", 40, 270));  // 547
            order_list.Add(new Order("4.mp4", 15, 320)); // 867

            int nTV = 3;




            Dictionary<string, int> report_list = new Dictionary<string, int>();
            report_list.Add("1.mp4", 144);
            report_list.Add("2.mp4", 133);
            report_list.Add("3.mp4", 270);
            report_list.Add("4.mp4", 320);
        }


    }
}

// 144
// 133
// 270
// 320