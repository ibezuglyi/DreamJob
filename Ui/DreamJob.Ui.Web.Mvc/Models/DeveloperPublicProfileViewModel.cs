namespace DreamJob.Ui.Web.Mvc.Models
{
    using DreamJob.Common.Enum;
    using DreamJob.Ui.Web.Mvc.Services;

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