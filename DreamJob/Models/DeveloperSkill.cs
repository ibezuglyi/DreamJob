namespace DreamJob.Models
{
    using System.ComponentModel.DataAnnotations;

    public class DeveloperSkill : DJDbBase
    {
        public DeveloperSkill()
        { }

        public DeveloperSkill(long skillId, long developerId, long level)
        {
            this.SkillId = skillId;
            this.DeveloperId = developerId;
            this.Level = level;
        }

        public long Level { get; set; }

        public long SkillId { get; set; }
        
        public virtual Skill Skill { get; set; }

        public long DeveloperId { get; set; }
        
        [Required]
        public virtual Developer Developer { get; set; }
    }
}