namespace DreamJob.Services
{
    using System.Collections.Generic;

    using DreamJob.Domain.Models;
    using DreamJob.Infrastructure.Interfaces;
    using DreamJob.Services.Interfaces;

    public class CandidateService :  ICandidateService
    {
        private ICandidateRepository candidateRepository;

        public CandidateService(ICandidateRepository candidateRepository)
        {
            this.candidateRepository = candidateRepository;
        }

        public IList<Candidate> GetAllCandidates()
        {
            return this.candidateRepository.GetAllCandidates();
        }

        public void GetCandidateDetails(object candidateId)
        {
            throw new System.NotImplementedException();
        }
    }
}