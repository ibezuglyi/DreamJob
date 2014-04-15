namespace DreamJob.Services.Interfaces
{
    public interface IJobOfferService
    {
        void SendOffer(long recruiterIdentificationData, long candidateIdentificationData, long offerData);
        object GetAllOffersForCandidate(object candidateIdentificationData);
        object GetOfferDetails(object offerIdentificationData);

        void AcceptOffer(object offerIdentificationData, object candidateContactData);
    }
}