namespace DreamJob.Ui.Web.Mvc.Models
{
    using DreamJob.Common.Enum;
    using DreamJob.Ui.Web.Mvc.Models.Dto;

    public class DeveloperPublicProfileViewModel
    {
        public DeveloperPublicProfileViewModel(UserProfileDto developerPublicDataDto, UserAccountType userAccountType)
        {
            this.DeveloperPublicDataDto = developerPublicDataDto;
            this.UserAccountType = userAccountType;
        }

        public UserProfileDto DeveloperPublicDataDto { get; set; }

        public UserAccountType UserAccountType { get; set; }
    }
}