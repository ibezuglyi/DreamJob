namespace DreamJob.Dtos
{
    using System.Collections.Generic;

    public class ProfilePrivateDeveloperEditDto
    {
        public ProfilePrivateDeveloperEditDto()
        {
            this.Skills = new List<DeveloperSkillDto>();
            this.DisplayName = string.Empty;
            this.AboutMe = string.Empty;
            this.LookingFor = string.Empty;
            this.Salary = 0;
        }

        public string DisplayName { get; set; }
        public string AboutMe { get; set; }
        public string LookingFor { get; set; }
        public List<DeveloperSkillDto> Skills { get; set; }

        public decimal Salary { get; set; }
    }
}