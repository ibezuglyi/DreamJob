namespace DreamJob.Ui.Web.Mvc.Controllers
{
    using DreamJob.Common.Enum;
    using DreamJob.Ui.Web.Mvc.Services;

    public interface INotificationBusiness
    {
        DjOperationResult<long> GetNewOffersCount();
    }

    class NotificationBusiness : INotificationBusiness
    {
        private readonly ISession sessionService;

        private readonly IOfferService offerService;

        public NotificationBusiness(ISession sessionService, IOfferService offerService)
        {
            this.sessionService = sessionService;
            this.offerService = offerService;
        }

        public DjOperationResult<long> GetNewOffersCount()
        {
            var currentUser = this.sessionService.GetCurrentUser().Data;
            var result = this.offerService.GetNewOffersCountByUserId(currentUser.Id);
            return result;
        }
    }
}