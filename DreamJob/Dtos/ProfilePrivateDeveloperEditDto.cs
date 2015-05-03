﻿namespace DreamJob.Dtos
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

        [Required(
           ErrorMessageResourceType = typeof(Resources.Translations),
           ErrorMessageResourceName = "ProfilePrivateDeveloperEdit_Dto_DisplayName_Required")]
        [AllowHtml]
        public string DisplayName { get; set; }

        [Required(
           ErrorMessageResourceType = typeof(Resources.Translations),
           ErrorMessageResourceName = "ProfilePrivateDeveloperEdit_Dto_AboutMe_Required")]
        [AllowHtml]
        public string AboutMe { get; set; }

        [Required(
           ErrorMessageResourceType = typeof(Resources.Translations),
           ErrorMessageResourceName = "ProfilePrivateDeveloperEdit_Dto_LookingFor_Required")]
        [AllowHtml]
        public string LookingFor { get; set; }

        public List<DeveloperSkillDto> Skills { get; set; }

        [Required(
           ErrorMessageResourceType = typeof(Resources.Translations),
           ErrorMessageResourceName = "ProfilePrivateDeveloperEdit_Dto_CurrentWorkingLocation_Required")]
        public string CurrentWorkingLocation { get; set; }

        public bool WillingToRelocateToDifferentCity { get; set; }

        public bool WillingToRelocateToDifferentCountry { get; set; }

        [Required(
           ErrorMessageResourceType = typeof(Resources.Translations),
           ErrorMessageResourceName = "ProfilePrivateDeveloperEdit_Dto_Salary_Required")]
        [Range(typeof(decimal), "1", "1000000000",
            ErrorMessageResourceType = typeof(Resources.Translations),
           ErrorMessageResourceName = "ProfilePrivateDeveloperEdit_Dto_Salary_Range")]
        public decimal Salary { get; set; }

        [Range(typeof(int), "0", "100",
            ErrorMessageResourceType = typeof(Resources.Translations),
           ErrorMessageResourceName = "ProfilePrivateDeveloperEdit_Dto_Experience_Range")]
        [Required(
          ErrorMessageResourceType = typeof(Resources.Translations),
          ErrorMessageResourceName = "ProfilePrivateDeveloperEdit_Dto_Experience_Required")]
        public int ExperienceInYears { get; set; }

        public string Action { get; set; }

        public bool IsActive { get; set; }
    }
}