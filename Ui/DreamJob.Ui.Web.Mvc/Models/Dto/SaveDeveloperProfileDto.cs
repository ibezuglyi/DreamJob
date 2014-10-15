namespace DreamJob.Ui.Web.Mvc.Controllers
{
    using System.Collections.Generic;

    using DreamJob.Model.Domain;

    public class SaveDeveloperProfileDto
    {
        public SaveDeveloperProfileDto()
        {
            this.Skills = new List<Skill>();
        }
        public long Id { get; set; }
        public List<Skill> Skills { get; set; }
        public string City { get; set; }
        public long MinSalary { get; set; }
        public string Title { get; set; }
        public string Profile { get; set; }
        public string ProjectPreferences { get; set; }
        public bool IsLookingForJob { get; set; }
    }
}