namespace DreamJob.Dtos
{
    using System.ComponentModel.DataAnnotations;

    public class SearchSkillDto
    {
        [Required]
        public string Skill { get; set; }
    }
}