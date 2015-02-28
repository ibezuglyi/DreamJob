namespace DreamJob.Dtos
{
    using System.ComponentModel.DataAnnotations;

    public class DeveloperSkillDto
    {
        public long SkillId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public long Level { get; set; }
    }
}