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

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Note { get; set; }
        public long Id { get; set; }
        public DateTime CreateDateTime { get; set; }
    }
}