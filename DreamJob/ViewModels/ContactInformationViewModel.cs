using System.ComponentModel.DataAnnotations;

namespace DreamJob.ViewModels
{
    using System;

    public class ContactInformationViewModel
    {
        public ContactInformationViewModel()
        {
            this.FirstName = string.Empty;
            this.LastName = string.Empty;
            this.Email = string.Empty;
            this.Phone = string.Empty;
            this.Note = string.Empty;
            this.Id = -1;
            this.CreateDateTime = DateTime.MinValue;
        }

        public DateTime CreateDateTime { get; set; }

        [Display(
           ResourceType = typeof(Resources.Translations),
           Name = "ContactInformationViewModel_FirstName")]
        public string FirstName { get; set; }

        [Display(
           ResourceType = typeof(Resources.Translations),
           Name = "ContactInformationViewModel_LastName")]
        public string LastName { get; set; }

        [Display(
           ResourceType = typeof(Resources.Translations),
           Name = "ContactInformationViewModel_Email")]
        public string Email { get; set; }

        [Display(
           ResourceType = typeof(Resources.Translations),
           Name = "ContactInformationViewModel_Phone")]
        public string Phone { get; set; }

        [Display(
           ResourceType = typeof(Resources.Translations),
           Name = "ContactInformationViewModel_Note")]
        public string Note { get; set; }

        public long Id { get; set; }
        public long JobOfferId { get; set; }
    }
}