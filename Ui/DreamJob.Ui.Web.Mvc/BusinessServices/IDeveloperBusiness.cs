namespace DreamJob.Ui.Web.Mvc.BusinessServices
{
    using DreamJob.Common.Enum;
    using DreamJob.Ui.Web.Mvc.Controllers;
    using DreamJob.Ui.Web.Mvc.Services;

    public interface IDeveloperBusiness
    {
        DjOperationResult<AllDevelopersViewModel> GetAllDevelopersViewModel();
        DjOperationResult<DeveloperPublicProfileViewModel> GetDeveloperPublicViewModel(long id);
    }

    public class DeveloperPublicProfileViewModel
    {
        public DeveloperPublicProfileViewModel(
            DeveloperPublicDataDto developerPublicDataDto,
            UserAccountType userAccountType)
        {
            this.DeveloperPublicDataDto = developerPublicDataDto;
            this.UserAccountType = userAccountType;
        }

        public DeveloperPublicDataDto DeveloperPublicDataDto { get; set; }
        public UserAccountType UserAccountType { get; set; }
    }
}