namespace DreamJob.Dtos
{
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    public class SearchSkillDto
    {
        [Required]
        [AllowHtml]
        public string Skill { get; set; }
    }
}