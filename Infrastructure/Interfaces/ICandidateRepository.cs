
namespace DreamJob.Infrastructure.Interfaces
{
    using DreamJob.Domain.Models;
    using DreamJob.Infrastructure.Interfaces.Base;
    using System.Collections.Generic;


    public interface ICandidateRepository : IBaseRepository<Candidate>
    {
        IList<Candidate> GetAllCandidates();
        void GetCandidateFullDetails(object isAny);
    }
}