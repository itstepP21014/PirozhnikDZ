using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP_System
{
    public class Project
    {
        public Project(string _name, string _customer, DateTime _startDate, DateTime _finishDate, int _status)
        {
            name = _name;
            customer = _customer;
            startTime = _startDate;
            finishTime = _finishDate;
            status = _status;
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private string customer;

        public string Customer
        {
            get { return customer; }
            set { customer = value; }
        }
        private DateTime startTime;

        public DateTime StartTime
        {
            get { return startTime; }
            set { startTime = value; }
        }
        private DateTime finishTime;

        public DateTime FinishTime
        {
            get { return finishTime; }
            set { finishTime = value; }
        }
        private int status;

        public int Status
        {
            get { return status; }
            set { status = value; }
        }

        private string logo;

        public string Logo
        {
            get { return logo; }
            set { logo = value; }
        }

    }
}
