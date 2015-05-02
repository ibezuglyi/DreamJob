namespace DreamJob.ViewModels
{
    using System.Collections.Generic;

    public class ProfilePublicDeveloperViewModel
    {
        public ProfilePublicDeveloperViewModel()
        {
            this.SkillsViewModels = new List<DeveloperSkillViewModel>();
            this.DisplayName = string.Empty;
            this.AboutMe = string.Empty;
            this.LookingFor = string.Empty;
            this.Salary = 0;
            this.Id = 0;
        }

        public string CurrentWorkingLocation { get; set; }
        public bool WillingToRelocateToDifferentCity { get; set; }
        public bool WillingToRelocateToDifferentCountry { get; set; }
        public long Id { get; set; }
        public string DisplayName { get; set; }
        public string AboutMe { get; set; }
        public string LookingFor { get; set; }
        public decimal Salary { get; set; }
        public List<DeveloperSkillViewModel> SkillsViewModels { get; set; }

    }
}