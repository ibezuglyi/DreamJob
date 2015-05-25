namespace DreamJob.Dtos
{
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    public class ContactInformationDto
    {
        [Required(ErrorMessageResourceType = typeof(Resources.Translations),ErrorMessageResourceName = "ContactInformation_Dto_FirstName_Required")]
        [Display(ResourceType = typeof(Resources.Translations), Name = "ContactInformation_Dto_FirstName")]
        [AllowHtml]
        public string FirstName { get; set; }
        
        [AllowHtml]
        [Display(ResourceType = typeof(Resources.Translations),Name = "ContactInformation_Dto_LastName")]
        public string LastName { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Translations),ErrorMessageResourceName = "ContactInformation_Dto_Email_Required")]
        [Display(ResourceType = typeof(Resources.Translations),Name = "ContactInformation_Dto_Email")]
        [AllowHtml]
        public string Email { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Translations),ErrorMessageResourceName = "ContactInformation_Dto_Phone_Required")]
        [Display(ResourceType = typeof(Resources.Translations),Name = "ContactInformation_Dto_Phone")]
        [AllowHtml]
        public string Phone { get; set; }
        
        [Display(ResourceType = typeof(Resources.Translations),Name = "ContactInformation_Dto_Note")]
        [AllowHtml]
        public string Note { get; set; }
    }
}