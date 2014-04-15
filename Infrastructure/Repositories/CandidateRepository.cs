namespace DreamJob.Infrastructure.Repositories
{
    using System.Linq;

    using DreamJob.Domain.Models;
    using DreamJob.Infrastructure.Interfaces;
    using System.Collections.Generic;

    public class CandidateRepository : BaseRepository<Candidate>, ICandidateRepository
    {
        public CandidateRepository(IDreamJobContext context)
            : base(context)
        {
        }

        public IList<Candidate> GetAllCandidates()
        {
            var result = this.context.Candidates.ToList();
            return result;
        }

        public void GetCandidateFullDetails(object isAny)
        {
            throw new System.NotImplementedException();
        }
    }
}
