using System.ComponentModel.DataAnnotations;

namespace DreamJob.ViewModels
{
    public class DeveloperHeadlineViewModel
    {

        public long Id { get; set; }

        [Display(
            ResourceType = typeof (Resources.Translations),
            Name = "DeveloperHeadlineViewModel_DisplayName")]
        public string DisplayName { get; set; }

        [Display(
            ResourceType = typeof (Resources.Translations),
            Name = "DeveloperHeadlineViewModel_SkillsCount")]
        public long SkillsCount { get; set; }

        [Display(
            ResourceType = typeof (Resources.Translations),
            Name = "DeveloperHeadlineViewModel_AboutMe")]
        public string AboutMe { get; set; }

        [Display(
            ResourceType = typeof (Resources.Translations),
            Name = "DeveloperHeadlineViewModel_LookingFor")]
        public string LookingFor { get; set; }

        [Display(
            ResourceType = typeof (Resources.Translations),
            Name = "DeveloperHeadlineViewModel_Salary")]
        public long Salary { get; set; }

        [Display(
            ResourceType = typeof (Resources.Translations),
            Name = "DeveloperHeadlineViewModel_ExperienceInYears")]
        public int ExperienceInYears { get; set; }
    }
}