namespace DreamJob.Dtos
{
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    public class ProfilePrivateRecruiterDto
    {
        [Required(
           ErrorMessageResourceType = typeof(Resources.Translations),
           ErrorMessageResourceName = "ProfilePrivateRecruiter_Dto_FirstName_Required")]
        [AllowHtml]
        public string FirstName { get; set; }

        [Required(
           ErrorMessageResourceType = typeof(Resources.Translations),
           ErrorMessageResourceName = "ProfilePrivateRecruiter_Dto_LastName_Required")]
        [AllowHtml]
        public string LastName { get; set; }

        [Required(
           ErrorMessageResourceType = typeof(Resources.Translations),
           ErrorMessageResourceName = "ProfilePrivateRecruiter_Dto_Email_Required")]
        [AllowHtml]
        public string Email { get; set; }

        [Required(
            ErrorMessageResourceType = typeof(Resources.Translations),
            ErrorMessageResourceName = "ProfilePrivateRecruiter_Dto_Employer_Required")]
        [AllowHtml]
        public string Employer { get; set; }

        public bool IsActive { get; set; }
    }
}