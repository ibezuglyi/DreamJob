namespace DreamJob.Interfaces
{
    using DreamJob.Models;

    public interface IOfferRepository
    {
        void AddOffer(object recruitedId, object candidateId, object offer);

        void Save();

        void GetAllOffersForCandidate(object isAny);

        void GetOfferDetails(object isAny);

        void UpdateOfferStatus(JobOfferStatus @is);

        void MarkOffersRead(object isAny);
    }
}