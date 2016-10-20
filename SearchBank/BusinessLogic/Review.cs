using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class Review
    {
        public int Id { get; set; }

        public string Commentator { get; set; }

        public string Comment { get; set; }

        public virtual Branch Object { get; set; }

    }
}
