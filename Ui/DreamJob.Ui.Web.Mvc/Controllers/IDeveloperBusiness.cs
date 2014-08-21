namespace DreamJob.Ui.Web.Mvc.Controllers
{
    using DreamJob.Common.Enum;

    public interface IDeveloperBusiness
    {
        DjOperationResult<AllDevelopersViewModel> GetAllDevelopersViewModel();
    }
}