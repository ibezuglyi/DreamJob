namespace DreamJob.Services
{
    using Dtos;
    using ViewModels;

    public interface IJobOfferService
    {
        void Add(JobOfferSendDto dto);

        JobOfferIndexViewModel GetJobOffers();
        JobOfferDetailsViewModel GetDetailsById(long id);

        JobOfferRejectViewModel GetJobOfferRejectViewModel(long id);
        JobOfferCancelViewModel GetJobOfferCancelViewModel(long id);
        JobOfferAcceptViewModel GetJobOfferAcceptViewModel(long id);
        JobOfferConfirmViewModel GetJobOfferConfirmViewModel(long id);

        void RejectOffer(JobOfferRejectDto dto);
        void CancelOffer(JobOfferCancelDto dto);
        void AcceptOffer(JobOfferAcceptDto dto);
        void ConfirmOffer(JobOfferConfirmDto dto);
        void ChangeStatus(JobOfferStatusChangeDto dto);

        JobOfferContactDetailsViewModel GetContactDetailsById(long id);

        JobOfferAcceptViewModel GetJobOfferAcceptViewModel(JobOfferAcceptDto dto);
        JobOfferCancelViewModel GetJobOfferCancelViewModel(JobOfferCancelDto dto);
        JobOfferRejectViewModel GetJobOfferRejectViewModel(JobOfferRejectDto dto);
        JobOfferConfirmViewModel GetJobOfferConfirmViewModel(JobOfferConfirmDto dto);
        JobOfferSendViewModel GetJobOfferSendViewModel(long id);
        JobOfferSendViewModel GetJobOfferSendViewModel(JobOfferSendDto dto);
    }
}