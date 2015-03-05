namespace DreamJob.Dtos
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

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

        [Required]
        [AllowHtml]
        public string DisplayName { get; set; }

        [Required]
        [AllowHtml]
        public string AboutMe { get; set; }
        
        [Required]
        [AllowHtml]
        public string LookingFor { get; set; }
        
        public List<DeveloperSkillDto> Skills { get; set; }

        [Required]
        public decimal Salary { get; set; }

        public string Action { get; set; }
        
        public bool IsActive { get; set; }
    }
}