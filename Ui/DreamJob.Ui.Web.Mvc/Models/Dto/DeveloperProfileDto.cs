using System;

namespace DreamJob.Ui.Web.Mvc.Models.Dto
{
    public class DeveloperProfileDto    
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Profile { get; set; }
        public string Registered { get; set; }
        public string ProjectPreferences { get; set; }
        public long MinSalary { get; set; }
        public string City { get; set; }
    }
}