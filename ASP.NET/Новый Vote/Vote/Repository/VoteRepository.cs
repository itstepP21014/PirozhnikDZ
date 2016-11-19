using DomainObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoteContext;

namespace Repository
{
    public class VoteRepository : IRepository
    {
        Context db = new Context();

        public IEnumerable<Candidate> GetAllCandidates()
        {
            return db.Candidates.Select(c => c).ToList();
        }

        public Candidate GetCandidateById(int id)
        {
            return db.Candidates.Where(c => c.CandidateId == id).FirstOrDefault();
        }
    }
}
