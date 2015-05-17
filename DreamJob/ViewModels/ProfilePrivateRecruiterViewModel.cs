
namespace DreamJob.ViewModels
{
    using System.ComponentModel.DataAnnotations;
    using Dtos;

    public class ProfilePrivateRecruiterViewModel
    {
        public ProfilePrivateRecruiterViewModel():this(new ProfilePrivateRecruiterDto())
        {}

        public ProfilePrivateRecruiterViewModel(ProfilePrivateRecruiterDto recruiter)
        {
            this.FirstName = string.Empty;
            this.LastName = string.Empty;
            this.Employer = string.Empty;
            this.PhoneNumber = string.Empty;
            this.Email = string.Empty;
        }

        [Display(
            ResourceType = typeof(Resources.Translations),
            Name = "ProfilePrivateRecruiterViewModel_FirstName")]
        public string FirstName { get; set; }

        [Display(
            ResourceType = typeof(Resources.Translations),
            Name = "ProfilePrivateRecruiterViewModel_LastName")]
        public string LastName { get; set; }

        [Display(
            ResourceType = typeof(Resources.Translations),
            Name = "ProfilePrivateRecruiterViewModel_Employer")]
        public string Employer { get; set; }

        [Display(
            ResourceType = typeof(Resources.Translations),
            Name = "ProfilePrivateRecruiterViewModel_PhoneNumber")]
        public string PhoneNumber { get; set; }

        [Display(
            ResourceType = typeof(Resources.Translations),
            Name = "ProfilePrivateRecruiterViewModel_Email")]
        public string Email { get; set; }

        [Display(
            ResourceType = typeof(Resources.Translations),
            Name = "ProfilePrivateRecruiterViewModel_IsActive")]
        public bool IsActive { get; set; }
    }
}