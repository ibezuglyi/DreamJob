namespace DreamJob.Infrastructure.Repositories
{
    using DreamJob.Domain.Models;
    using DreamJob.Infrastructure.Interfaces;
    using System.Collections.Generic;
    using System.Linq;
    using System.Data.Entity;

    using DreamJob.Infrastructure.Repositories.Base;
    using DreamJob.Repositories;

    public class CandidateRepository : BaseRepository<Candidate>, ICandidateRepository
    {
        public CandidateRepository(JobContext context)
            : base(context)
        {

        }

        public IList<Candidate> GetAllCandidates()
        {
            return Context.Set<Candidate>().ToList();
        }

        public void GetCandidateFullDetails(object isAny)
        {
            throw new System.NotImplementedException();
        }
    }
}
