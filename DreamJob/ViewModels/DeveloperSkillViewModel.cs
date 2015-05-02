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

        public string Name { get; set; }
        public long Level { get; set; }
        public long SkillId { get; set; }
    }
}