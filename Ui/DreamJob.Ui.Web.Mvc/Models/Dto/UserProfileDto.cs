namespace DreamJob.Ui.Web.Mvc.Models.Dto
{
    using System;

    using DreamJob.Common.Enum;

    public class UserProfileDto
    {
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
    }
}