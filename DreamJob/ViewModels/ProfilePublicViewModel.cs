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
    }
}