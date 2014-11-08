using DreamJob.Common.Enum;

namespace DreamJob.Ui.Web.Mvc.BusinessServices
{
    public interface INotificationBusiness
    {
        DjOperationResult<long> GetNewOffersCount();
    }
}