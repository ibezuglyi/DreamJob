﻿namespace DreamJob.Infrastructure.Repositories
{
    using DreamJob.Domain.Models;
    using DreamJob.Interfaces;


    public class JobOfferRepository : BaseRepository<JobOffer>, IJobOfferRepository
    {

        public JobOfferRepository(IDreamJobContext context)
            : base(context)
        {

        }
        public void AddOffer(object recruitedId, object candidateId, object offer)
        {
        }

        public void GetAllOffersForCandidate(object isAny)
        {
            throw new System.NotImplementedException();
        }

        public void GetOfferDetails(object isAny)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateOfferStatus(JobOfferStatus @is)
        {
            throw new System.NotImplementedException();
        }

        public void MarkOffersRead(object isAny)
        {
            throw new System.NotImplementedException();
        }
    }
}