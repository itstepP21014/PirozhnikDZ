using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainObject
{
    public class Raсe
    {
        public int RaсeId { get; set; }

        public virtual IEnumerable<Candidate> Candidates { get; set; }
    }
}
