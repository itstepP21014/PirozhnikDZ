using DomainObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyService
{
    public interface IService
    {
        IEnumerable<Candidate> GetAllCandidates();
        Candidate GetCandidateById(int id);
    }
}
