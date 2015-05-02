namespace DreamJob.ValueResolvers
{
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using Models;
    using ViewModels;

    internal class DeveloperToListOfDeveloperSkillsViewModel :
        ValueResolver<Developer, List<DeveloperSkillViewModel>>
    {
        protected override List<DeveloperSkillViewModel> ResolveCore(Developer source)
        {
            var skills =
                source.Skills.Select(s => new DeveloperSkillViewModel(s.Skill.Name, s.Level, s.SkillId)).ToList();
            return skills;
        }
    }
}