namespace DreamJob.Ui.Web.Mvc.BusinessServices
{
    using DreamJob.Common.Enum;
    using DreamJob.Ui.Web.Mvc.Controllers;
    using DreamJob.Ui.Web.Mvc.Models;

    public interface IDeveloperBusiness
    {
        DjOperationResult<AllDevelopersViewModel> GetAllDevelopersViewModel();
        DjOperationResult<DeveloperPublicProfileViewModel> GetDeveloperPublicViewModel(long id);
    }
}