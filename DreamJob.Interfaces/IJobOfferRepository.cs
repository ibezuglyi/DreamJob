namespace DreamJob.Interfaces
{
    using DreamJob.Domain.Models;
    using DreamJob.Infrastructure.Interfaces.Base;

    public interface IJobOfferRepository : IBaseRepository<JobOffer>
    {
        void AddOffer(object recruitedId, object candidateId, object offer);

        void GetAllOffersForCandidate(object isAny);

        void GetOfferDetails(object isAny);

        void UpdateOfferStatus(JobOfferStatus @is);

        void MarkOffersRead(object isAny);
    }
}