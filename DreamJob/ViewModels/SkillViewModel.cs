using System.ComponentModel.DataAnnotations;

namespace DreamJob.ViewModels
{
    public class SkillViewModel
    {
        public long Id { get; set; }
        [Display(
            ResourceType = typeof(Resources.Translations),
            Name = "SkillViewModel_Name")]
        public string Name { get; set; }
    }
}