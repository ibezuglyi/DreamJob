namespace DreamJob.ViewModels
{
    public class ProfilePublicViewModel
    {
        public ProfilePublicViewModel()
        {
            this.Developer = new ProfilePublicDeveloperViewModel();
            this.Recruiter = new ProfilePublicRecruiterViewModel();
        }

        public ApplicationUserRole ProfileRole { get; set; }
        public ProfilePublicDeveloperViewModel Developer { get; set; }
        public ProfilePublicRecruiterViewModel Recruiter { get; set; }

        public ApplicationUserRole CurrentUserRole { get; set; }

        public bool CurrentUserProfileIsActive { get; set; }
        public bool IsRecruiterAbleToSendOffer
        {
            get
            {
                return CurrentUserRole == ApplicationUserRole.Recruiter
                    && ProfileRole == ApplicationUserRole.Developer
                    && CurrentUserProfileIsActive;
            }
        }

        public bool IsRecruiterInactive
        {
            get
            {
                return CurrentUserRole == ApplicationUserRole.Recruiter
                    && CurrentUserProfileIsActive == false;
            }
        }
    }
}