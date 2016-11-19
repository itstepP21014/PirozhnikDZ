using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainObject
{
    public class Candidate
    {
        public int CandidateId { get; set; }
        public string Name { get; set; }
        public int Rate { get; set; }

        public int RaceId { get; set; }
        public virtual Raсe Race { get; set; }
    }
}
