namespace DreamJob.ViewModels
{
    using System.Collections.Generic;

    using DreamJob.Dtos;

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

        public string DisplayName { get; set; }
        public string Email { get; set; }

        public string AboutMe { get; set; }
        public string LookingFor { get; set; }
        public bool IsActive { get; set; }


        public List<DeveloperSkillViewModel> Skills { get; set; }

        public decimal Salary { get; set; }
    }
}