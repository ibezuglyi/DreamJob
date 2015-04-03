using System.ComponentModel.DataAnnotations;

namespace DreamJob.Dtos
{
    using System.Web.Mvc;

    public class DeveloperSkillDto
    {
        public DeveloperSkillDto()
        {
            this.SkillId = 0;
            this.Name = string.Empty;
            this.Level = 1;
        }

        public long SkillId { get; set; }

        [AllowHtml]
        public string Name { get; set; }

        [Range(typeof(long), "1", "10")]
        public long Level { get; set; }
    }
}