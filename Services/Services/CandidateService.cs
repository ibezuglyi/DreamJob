namespace DreamJob.Services.CandidateService
{
    using DreamJob.Domain.Models;
    using DreamJob.Infrastructure.Interfaces;
    using DreamJob.Services.Interfaces;
    using System.Collections.Generic;

    public class CandidateService :  ICandidateService
    {
        private ICandidateRepository candidateRepository;

        public CandidateService(ICandidateRepository candidateRepository)
        {
            this.candidateRepository = candidateRepository;
        }

        public IList<Candidate> GetAllCandidates()
        {
            return candidateRepository.GetAllCandidates();
        }

        public void GetCandidateDetails(object candidateId)
        {
            throw new System.NotImplementedException();
        }
    }
}