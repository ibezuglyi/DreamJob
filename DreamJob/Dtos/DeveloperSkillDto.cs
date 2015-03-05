namespace DreamJob.Dtos
{
    using System.Web.Mvc;

    public class DeveloperSkillDto
    {
        public long SkillId { get; set; }
        
        [AllowHtml]
        public string Name { get; set; }
        
        public long Level { get; set; }
    }
}