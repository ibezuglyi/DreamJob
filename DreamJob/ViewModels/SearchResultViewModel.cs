namespace DreamJob.ViewModels
{
    using System.Collections.Generic;

    public class SearchResultViewModel
    {
        public List<DeveloperHeadlineViewModel> Headlines { get; set; }
        public List<SkillViewModel> SkillsMatchedFount { get; set; }

        public SearchResultViewModel(List<DeveloperHeadlineViewModel> headlines)
            : this(headlines, new List<SkillViewModel>())
        { }

        public SearchResultViewModel(List<DeveloperHeadlineViewModel> headlines, List<SkillViewModel> skillsMatchedFount)
        {
            this.Headlines = headlines;
            this.SkillsMatchedFount = skillsMatchedFount;
        }
    }
}