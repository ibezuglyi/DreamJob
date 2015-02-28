﻿namespace DreamJob.Dtos
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

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
        public string DisplayName { get; set; }
        [Required]
        public string AboutMe { get; set; }
        [Required]
        public string LookingFor { get; set; }
        public List<DeveloperSkillDto> Skills { get; set; }

        [Required]
        public decimal Salary { get; set; }
    }
}