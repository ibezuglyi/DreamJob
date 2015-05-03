using System.Web.Mvc;
using DreamJob.Services;

namespace DreamJob.Controllers
{
    public class TestController : DjBaseController
    {
        private readonly ITestService testService;

        public TestController(ITestService testService)
        {
            this.testService = testService;
        }

        public ActionResult Index()
        {
            var viewModel = this.testService.GetViewModel();
            return this.View("Index", viewModel);
        }

        public ActionResult NewDeveloper(int d)
        {
            this.testService.CreateNewDevelopers(d);
            return this.RedirectToAction("Index");
        }

        public ActionResult NewRecruiter(int r)
        {
            this.testService.CreateNewRecruites(r);
            return this.RedirectToAction("Index");
        }

        public ActionResult NewComment(int c, int o)
        {
            this.testService.CreateComments(c, o);
            return this.RedirectToAction("Index");
        }

        public ActionResult NewOffer(int o)
        {
            this.testService.CreateOffers(o);
            return this.RedirectToAction("Index");

        }

        public ActionResult NewResponse(int r, int o)
        {
            this.testService.CreateOfferResponses(r, o);
            return this.RedirectToAction("Index");
        }

        public ActionResult Hijac()
        {
            this.testService.HijacIoc();
            return this.RedirectToAction("Index");
        }

        public ActionResult Restore()
        {
            this.testService.Restore();
            return this.RedirectToAction("Index");
        }
    }
}