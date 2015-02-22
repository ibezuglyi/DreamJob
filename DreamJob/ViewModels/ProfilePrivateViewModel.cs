namespace DreamJob.ViewModels
{
    using DreamJob.Dtos;

    public class ProfilePrivateViewModel
    {
        public ProfilePrivateViewModel():this(new ProfilePrivateEditDto())
        {}

        public ProfilePrivateViewModel(ProfilePrivateEditDto dto)
        {
            this.Developer = new ProfilePrivateDeveloperViewModel(dto.Developer);
            this.Recruiter = new ProfilePrivateRecruiterViewModel(dto.Recruiter);
            this.Role = dto.Role;
        }

        public ProfilePrivateDeveloperViewModel Developer { get; set; }
        public ProfilePrivateRecruiterViewModel Recruiter { get; set; }

        public ApplicationUserRole Role { get; set; }
    }
}