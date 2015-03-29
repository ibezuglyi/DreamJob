namespace DreamJob.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public sealed class Developer : DJDbBase
    {
        public Developer()
        {
            this.Skills = new List<DeveloperSkill>();
        }

        public string DisplayName { get; set; }
        public string AboutMe { get; set; }
        public string LookingFor { get; set; }
        public decimal Salary { get; set; }
        public bool IsActive { get; set; }

        public long UserAccountId { get; set; }

        [Required]
        public UserAccount Account { get; set; }

        public List<DeveloperSkill> Skills { get; set; }

    }
}