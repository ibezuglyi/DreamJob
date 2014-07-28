namespace DreamJob.Ui.Web.Mvc.Controllers
{
    using DreamJob.Common.Enum;

    public interface ILogoffBusiness
    {
        DjOperationResult<bool> LogoffUser();
    }
}