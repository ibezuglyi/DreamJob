namespace DreamJob.Infrastructure.Repositories
{
    using DreamJob.Domain.Models;
    using DreamJob.Infrastructure.Interfaces;
    using System.Collections.Generic;

    public class CandidateRepository : BaseRepository<Candidate>, ICandidateRepository
    {
        public CandidateRepository(object persistenceContext)
            : base(persistenceContext)
        {

        }

        public IList<Candidate> GetAllCandidates()
        {
            return new List<Candidate>() { (Candidate)persistenceContext };
        }

        public void GetCandidateFullDetails(object isAny)
        {
            throw new System.NotImplementedException();
        }
    }
}
