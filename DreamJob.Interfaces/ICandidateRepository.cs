
namespace DreamJob.Infrastructure.Interfaces
{
    using DreamJob.Domain.Models;
    using DreamJob.Infrastructure.Interfaces.Base;


    public interface ICandidateRepository : IBaseRepository<Candidate>
    {
        void AllCandidates();
        void GetCandidateFullDetails(object isAny);
    }
}