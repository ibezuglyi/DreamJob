namespace DreamJob.Services.Interfaces
{
    using DreamJob.Domain.Models;
    using System.Collections.Generic;

    public interface ICandidateService
    {
        IList<Candidate> GetAllCandidates();
        void GetCandidateDetails(object candidateId);
    }
}
