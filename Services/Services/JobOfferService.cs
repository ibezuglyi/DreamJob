namespace DreamJob.Services
{
    using DreamJob.Interfaces;
    using DreamJob.Services.Interfaces;

    public class JobOfferService : IJobOfferService
    {
        public JobOfferService(IJobOfferRepository jobOfferRepository)
        {
            throw new System.NotImplementedException();
        }

        public void SendOffer(long recruiterIdentificationData, long candidateIdentificationData, long offerData)
        {
            throw new System.NotImplementedException();
        }

        public object GetAllOffersForCandidate(object candidateIdentificationData)
        {
            throw new System.NotImplementedException();
        }

        public object GetOfferDetails(object offerIdentificationData)
        {
            throw new System.NotImplementedException();
        }

        public void AcceptOffer(object offerIdentificationData, object candidateContactData)
        {
            throw new System.NotImplementedException();
        }
    }
}