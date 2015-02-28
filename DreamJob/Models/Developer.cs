namespace DreamJob.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Developer : DJDbBase
    {
        public string DisplayName { get; set; }
        public string AboutMe { get; set; }
        public string LookingFor { get; set; }
        public decimal Salary { get; set; }
        public bool IsActive { get; set; }

        public long UserAccountId { get; set; }

        [Required]
        public virtual UserAccount Account { get; set; }

        public virtual List<DeveloperSkill> Skills { get; set; }

    }
}