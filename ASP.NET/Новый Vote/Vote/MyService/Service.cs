using DomainObject;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyService
{
    public class Service : IService
    {
        private IRepository _repository = null;
        public Service(IRepository repo)
        {
            _repository = repo;
        }

        public IEnumerable<Candidate> GetAllCandidates()
        {
            return _repository.GetAllCandidates();
        }

        public Candidate GetCandidateById(int id)
        {
            return _repository.GetCandidateById(id);
        }
    }
}
