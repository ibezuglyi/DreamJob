namespace DreamJob.ViewModels
{
    using DreamJob.Dtos;

    public class DeveloperSkillViewModel
    {
        public DeveloperSkillViewModel():this(new DeveloperSkillDto())
        {}
        public DeveloperSkillViewModel(DeveloperSkillDto skill)
        {
            this.Name = skill.Name;
            this.Level = skill.Level;
            this.SkillId = skill.SkillId;
        }

        public string Name { get; set; }
        public long Level { get; set; }
        public long SkillId { get; set; }
    }
}