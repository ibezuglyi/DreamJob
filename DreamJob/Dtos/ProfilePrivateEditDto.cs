namespace DreamJob.Dtos
{
    using DreamJob.ViewModels;

    public class ProfilePrivateEditDto
    {
        public ProfilePrivateEditDto()
        {
            this.Role = ApplicationUserRole.None;
            this.Developer = new ProfilePrivateDeveloperEditDto();
            this.Recruiter = new ProfilePrivateRecruiterDto();
        }

        public ApplicationUserRole Role { get; set; }
        public ProfilePrivateDeveloperEditDto Developer { get; set; }
        public ProfilePrivateRecruiterDto Recruiter { get; set; }

        public string Action { get; set; }
    }
}