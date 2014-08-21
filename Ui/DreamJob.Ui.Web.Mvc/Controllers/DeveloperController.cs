namespace DreamJob.Ui.Web.Mvc.Controllers
{
    using System;
    using System.Web.Mvc;

    [Authorize]
    public class DeveloperController : Controller
    {
        private readonly IDeveloperBusiness businessDeveloper;

        public DeveloperController(IDeveloperBusiness businessDeveloper)
        {
            this.businessDeveloper = businessDeveloper;
        }

        public ActionResult Index()
        {
            var allDevsViewModelResult = this.businessDeveloper.GetAllDevelopersViewModel();
            if (allDevsViewModelResult.IsSuccess)
            {
                return this.View("Index", allDevsViewModelResult.Data);
            }

            throw new Exception("Index");
        }
    }
}