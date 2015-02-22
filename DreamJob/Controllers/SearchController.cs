namespace DreamJob.Controllers
{
    using System.Web.Mvc;

    using DreamJob.Services;
    using DreamJob.ViewModels;

    public class SearchController : Controller
    {
        private readonly IProfileService profileService;

        public SearchController(IProfileService profileService)
        {
            this.profileService = profileService;
        }

        public ActionResult Index()
        {
            var viewmodel = new SearchIndexViewModel();
            return this.View("Index", viewmodel);
        }

        [HttpGet]
        public ActionResult Skill(SearchSkillDto dto)
        {
            var viewModel = this.profileService.GetDevelopersHeadlinesWithSkill(dto);
            return this.View("Skill", viewModel);
        }

        [HttpGet]
        public ActionResult Salary(SearchSalaryDto dto)
        {
            var viewModel = this.profileService.GetDevelopersHeadlinesWithSalaryInRange(dto);
            return this.View("Salary", viewModel);
        }
    }

    public class SearchSalaryDto
    {
        public decimal Minimum { get; set; }
        public decimal Maximum { get; set; }
    }

    public class SearchSkillDto
    {
        public string Skill { get; set; }
    }
}