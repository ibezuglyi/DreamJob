namespace DreamJob.Interfaces
{
    public interface IOfferService
    {
        void SendOffer(object recruiterIdentificationData, object candidateIdentificationData, object offerData);
        
        object GetAllOffersForCandidate(object candidateIdentificationData);
        object GetOfferDetails(object identificationData, object offerIdentificationData);

        void AcceptOffer(object offerIdentificationData, object candidateContactData);
        void RejectOffer(object offerIdentificationData, object offerRejectReason);
    }
}