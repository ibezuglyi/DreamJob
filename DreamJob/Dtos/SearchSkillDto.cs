namespace DreamJob.Dtos
{
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    public class SearchSkillDto
    {
        [Required(
             ErrorMessageResourceType = typeof(Resources.Translations),
             ErrorMessageResourceName = "SearchSkill_Dto_Skill_Required")]
        [AllowHtml]
        public string Skill { get; set; }
    }
}