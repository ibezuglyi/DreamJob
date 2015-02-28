namespace DreamJob.Dtos
{
    using System.ComponentModel.DataAnnotations;

    public class DeveloperSkillDto
    {
        public long SkillId { get; set; }
        public string Name { get; set; }
        public long Level { get; set; }
    }
}