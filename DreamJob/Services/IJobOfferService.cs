namespace DreamJob.Services
{
    using DreamJob.Dtos;
    using DreamJob.ViewModels;

    public interface IJobOfferService
    {
        void Add(JobOfferSendDto dto);

        JobOfferIndexViewModel GetJobOffers();
        JobOfferDetailsViewModel GetDetailsById(long id);
    }
}