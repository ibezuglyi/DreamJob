namespace DreamJob.Controllers
{
    using System.Web.Mvc;

    using Services;

    public class MenuController : DjBaseController
    {
        private readonly IMenuService menuService;

        public MenuController(IMenuService menuService)
        {
            this.menuService = menuService;
        }

        //[HttpGet]
        [ChildActionOnly]
        public ActionResult NewMessages()
        {
            var viewModel = this.menuService.GetNewMessages();
            return this.PartialView("NewMessages", viewModel);

        }

    }
}