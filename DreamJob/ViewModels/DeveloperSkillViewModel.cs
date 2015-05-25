using System.ComponentModel.DataAnnotations;

namespace DreamJob.ViewModels
{
    using Dtos;

    public class DeveloperSkillViewModel
    {
        public DeveloperSkillViewModel() : this(string.Empty, -1, -1)
        { }

        public DeveloperSkillViewModel(DeveloperSkillDto skill) : this(skill.Name, skill.Level, skill.SkillId)
        { }

        public DeveloperSkillViewModel(string name, long level, long skillId)
        {
            this.Name = name;
            this.Level = level;
            this.SkillId = skillId;
        }

        [Display(
            ResourceType = typeof(Resources.Translations),
            Name = "DeveloperSkillViewModel_Name")]
        public string Name { get; set; }
        [Display(
            ResourceType = typeof(Resources.Translations),
            Name = "DeveloperSkillViewModel_Level")]
        public long Level { get; set; }

        public long SkillId { get; set; }
    }
}