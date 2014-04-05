namespace DreamJob.Services.Interfaces
{
    public interface IJobOfferService
    {
        void SendOffer(object recruiterIdentificationData, object candidateIdentificationData, object offerData);
        object GetAllOffersForCandidate(object candidateIdentificationData);
        object GetOfferDetails(object offerIdentificationData);

        void AcceptOffer(object offerIdentificationData, object candidateContactData);
    }
}