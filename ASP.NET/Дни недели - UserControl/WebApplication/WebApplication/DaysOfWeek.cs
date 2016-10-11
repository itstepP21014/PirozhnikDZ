using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication
{
    public class DaysOfWeek
    {
        public string Name { get; set; }

        public List<DaysOfWeek> GetWeeksDaysNames()
        {
            return new List<DaysOfWeek> { 
                new DaysOfWeek {Name  = "Monday"},
                new DaysOfWeek {Name  = "Tuesday"},
                new DaysOfWeek {Name  = "Wednesday"},
                new DaysOfWeek {Name  = "Thursday"},
                new DaysOfWeek {Name  = "Friday"},
                new DaysOfWeek {Name  = "Saturday"},
                new DaysOfWeek {Name  = "Sunday"}
            };
        }
    }
}