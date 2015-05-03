namespace DreamJob.Dtos
{
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    public class ContactInformationDto
    {
        [Required(
            ErrorMessageResourceType = typeof(Resources.Translations),
            ErrorMessageResourceName = "ContactInformation_Dto_FirstName_Required")]
        [AllowHtml]
        public string FirstName { get; set; }
        
        [AllowHtml]
        public string LastName { get; set; }

        [Required(
            ErrorMessageResourceType = typeof(Resources.Translations),
            ErrorMessageResourceName = "ContactInformation_Dto_Email_Required")]
        [AllowHtml]
        public string Email { get; set; }

        [Required(
            ErrorMessageResourceType = typeof(Resources.Translations),
            ErrorMessageResourceName = "ContactInformation_Dto_Phone_Required")]
        [AllowHtml]
        public string Phone { get; set; }
        
        [AllowHtml]
        public string Note { get; set; }
    }
}