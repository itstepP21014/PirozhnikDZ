using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    public class PRODUCER
    {
        public PRODUCER()
        {

        }

        private int id;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        private string name;

        public string NAME
        {
            get { return name; }
            set { name = value; }
        }

        private DateTime date;

        public DateTime DATE
        {
            get { return date; }
            set { date = value; }
        }

        private int fee;

        public int FEE
        {
            get { return fee; }
            set { fee = value; }
        }
    }
}
