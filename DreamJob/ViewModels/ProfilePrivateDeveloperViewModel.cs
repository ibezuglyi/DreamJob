using System.ComponentModel.DataAnnotations;

namespace DreamJob.ViewModels
{
    using System.Collections.Generic;

    using Dtos;

    public class ProfilePrivateDeveloperViewModel
    {
        public ProfilePrivateDeveloperViewModel()
            : this(new ProfilePrivateDeveloperEditDto())
        { }

        public ProfilePrivateDeveloperViewModel(ProfilePrivateDeveloperEditDto dto)
        {
            this.DisplayName = dto.DisplayName;
            this.AboutMe = dto.AboutMe;
            this.LookingFor = dto.LookingFor;
            this.Skills = new List<DeveloperSkillViewModel>();
            dto.Skills.ForEach(skill => this.Skills.Add(new DeveloperSkillViewModel(skill)));
        }

        [Display(
            ResourceType = typeof(Resources.Translations),
            Name = "ProfilePrivateDeveloperViewModel_DisplayName")]
        public string DisplayName { get; set; }

        [Display(
            ResourceType = typeof(Resources.Translations),
            Name = "ProfilePrivateDeveloperViewModel_CurrentWorkingLocation")]
        public string CurrentWorkingLocation { get; set; }

        [Display(
            ResourceType = typeof(Resources.Translations),
            Name = "ProfilePrivateDeveloperViewModel_WillingToRelocateToDifferentCity")]
        public bool WillingToRelocateToDifferentCity { get; set; }

        [Display(
            ResourceType = typeof(Resources.Translations),
            Name = "ProfilePrivateDeveloperViewModel_WillingToRelocateToDifferentCountry")]
        public bool WillingToRelocateToDifferentCountry { get; set; }

        [Display(
            ResourceType = typeof(Resources.Translations),
            Name = "ProfilePrivateDeveloperViewModel_AboutMe")]
        public string AboutMe { get; set; }

        [Display(
            ResourceType = typeof(Resources.Translations),
            Name = "ProfilePrivateDeveloperViewModel_LookingFor")]
        public string LookingFor { get; set; }

        [Display(
            ResourceType = typeof(Resources.Translations),
            Name = "ProfilePrivateDeveloperViewModel_IsActive")]
        public bool IsActive { get; set; }

        [Display(
            ResourceType = typeof(Resources.Translations),
            Name = "ProfilePrivateDeveloperViewModel_ExperienceInYears")]
        public int ExperienceInYears { get; set; }
        

        public List<DeveloperSkillViewModel> Skills { get; set; }

        [Display(
            ResourceType = typeof(Resources.Translations),
            Name = "ProfilePrivateDeveloperViewModel_Salary")]
        public decimal Salary { get; set; }
    }
}