namespace DreamJob.Controllers
{
    using System.Web.Mvc;

    using DreamJob.Dtos;
    using DreamJob.Services;
    using DreamJob.ViewModels;

    public class JobOfferController : Controller
    {
        private readonly IJobOfferService jobofferService;

        public JobOfferController(IJobOfferService jobofferService)
        {
            this.jobofferService = jobofferService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var viewmodel = this.jobofferService.GetJobOffers();
            return this.View("Index", viewmodel);
        }

        [HttpGet]
        public ActionResult Send(long id)
        {
            var viewmodel = new JobOfferSendViewModel(id);
            return this.View("Send", viewmodel);
        }

        [HttpPost]
        public ActionResult Send(JobOfferSendDto dto)
        {
            if (ModelState.IsValid)
            {
                this.jobofferService.Add(dto);
                return RedirectToAction("Index", "Home");
            }
            var viewmodel = new JobOfferSendViewModel(dto);
            return this.View("Send", viewmodel);
        }

        [HttpGet]
        public ActionResult Details(long id)
        {
            var viewmodel = this.jobofferService.GetDetailsById(id);
            return this.View("Details", viewmodel);
        }
    }
}