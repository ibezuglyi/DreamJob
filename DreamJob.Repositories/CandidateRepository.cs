namespace DreamJob.Infrastructure.Repositories
{
    using DreamJob.Domain.Models;
    using DreamJob.Infrastructure.Interfaces;

    public class CandidateRepository : BaseRepository<Candidate>, ICandidateRepository
    {
        public void AllCandidates()
        {
            throw new System.NotImplementedException();
        }

        public void GetCandidateFullDetails(object isAny)
        {
            throw new System.NotImplementedException();
        }
    }
}
