namespace DreamJob.Infrastructure.Repositories
{
    using DreamJob.Domain.Models;
    using DreamJob.Infrastructure.Repositories;
    using DreamJob.Interfaces;
    using DreamJob.Repositories;


    public class JobOfferRepository : BaseRepository<JobOffer>, IJobOfferRepository
    {

        public JobOfferRepository(JobContext context)
            : base(context)
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
