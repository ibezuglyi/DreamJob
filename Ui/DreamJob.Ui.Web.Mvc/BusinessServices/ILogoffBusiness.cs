using DreamJob.Common.Enum;

namespace DreamJob.Ui.Web.Mvc.BusinessServices
{
    public interface ILogoffBusiness
    {
        DjOperationResult<bool> LogoffUser();
    }
}