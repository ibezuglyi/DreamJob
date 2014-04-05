namespace DreamJob.Infrastructure.Repositories
{
    using DreamJob.Domain.Models;
    using DreamJob.Infrastructure.Repositories;
    using DreamJob.Interfaces;


    public class JobOfferRepository : BaseRepository<JobOffer>, IJobOfferRepository
    {

        public JobOfferRepository(object persistenceContext)
            : base(persistenceContext)
        {

        }
        public void AddOffer(object recruitedId, object candidateId, object offer)
        {
            throw new System.NotImplementedException();
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
