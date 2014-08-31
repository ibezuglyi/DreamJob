namespace DreamJob.Ui.Web.Mvc.Models.Dto
{
    using System;

    public class UserProfileDto
    {
        public long Id { get; set; }
        public string DisplayName { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public DateTime Registered { get; set; }
        public string AccountType { get; set; }
        public string Title { get; set; }
        public string Profile { get; set; }
        public string ProjectPreferences { get; set; }
        public long MinSalary { get; set; }
        public string City { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Mobile { get; set; }
        public string Company { get; set; }
    }
}