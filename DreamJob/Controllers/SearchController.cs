namespace DreamJob.Controllers
{
    using System.Web.Mvc;

    using Dtos;
    using Services;
    using ViewModels;

    [Authorize]
    public class SearchController : DjBaseController
    {
        private readonly IProfileService profileService;

        public SearchController(IProfileService profileService)
        {
            this.profileService = profileService;
        }

        [AllowAnonymous]
        public ActionResult Index()
        {
            var viewmodel = new SearchIndexViewModel();
            return this.View("Index", viewmodel);
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Skill(SearchSkillDto dto)
        {
            if (!ModelState.IsValid)
            {
                return this.View("Index", new SearchIndexViewModel());
            }
            var viewModel = this.profileService.GetDevelopersHeadlinesWithSkill(dto);
            return this.View("Skill", viewModel);
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Salary(SearchSalaryDto dto)
        {
            var viewModel = this.profileService.GetDevelopersHeadlinesWithSalaryInRange(dto);
            return this.View("Salary", viewModel);
        }
    }
}