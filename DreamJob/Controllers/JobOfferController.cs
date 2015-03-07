namespace DreamJob.Controllers
{
    using System.Web.Mvc;

    using DreamJob.Dtos;
    using DreamJob.Services;
    using DreamJob.ViewModels;

    [Authorize]
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
            if (this.ModelState.IsValid)
            {
                this.jobofferService.Add(dto);
                return this.RedirectToAction("Index", "Home");
            }
            var viewmodel = new JobOfferSendViewModel(dto);
            return this.View("Send", viewmodel);
        }

        [HttpGet]
        public ActionResult Details(long id)
        {
            var viewmodel = this.jobofferService.GetDetailsById(id);
            if (viewmodel == null)
            {
                return new HttpUnauthorizedResult();
            }
            return this.View("Details", viewmodel);
        }

        [HttpGet]
        public ActionResult Reject(long id)
        {
            var viewmodel = this.jobofferService.GetJobOfferRejectViewModel(id);
            return this.View("Reject", viewmodel);
        }

        [HttpGet]
        public ActionResult Cancel(long id)
        {
            var viewmodel = this.jobofferService.GetJobOfferCancelViewModel(id);
            return this.View("Cancel", viewmodel);
        }

        [HttpGet]
        public ActionResult Accept(long id)
        {
            var viewmodel = this.jobofferService.GetJobOfferAcceptViewModel(id);
            return this.View("Accept", viewmodel);
        }

        [HttpGet]
        public ActionResult Confirm(long id)
        {
            var viewmodel = this.jobofferService.GetJobOfferConfirmViewModel(id);
            return this.View("Confirm", viewmodel);
        }


        [HttpPost]
        public ActionResult Reject(JobOfferRejectDto dto)
        {
            if (this.ModelState.IsValid)
            {
                this.jobofferService.RejectOffer(dto);
                return this.RedirectToAction("Details", "JobOffer", new { id = dto.JobOfferId });
            }
            var viewmodel = new JobOfferRejectViewModel(dto);
            return this.View("Reject", viewmodel);

        }

        [HttpPost]
        public ActionResult Cancel(JobOfferCancelDto dto)
        {
            if (this.ModelState.IsValid)
            {
                this.jobofferService.CancelOffer(dto);
                return this.RedirectToAction("Details", "JobOffer", new { id = dto.JobOfferId });
            }
            var viewmodel = new JobOfferCancelViewModel(dto);
            return this.View("Cancel", viewmodel);
        }

        [HttpPost]
        public ActionResult Accept(JobOfferAcceptDto dto)
        {
            if (this.ModelState.IsValid)
            {
                this.jobofferService.AcceptOffer(dto);
                return this.RedirectToAction("Details", "JobOffer", new { id = dto.JobOfferId });
            }
            var viewmodel = new JobOfferAcceptViewModel(dto);
            return this.View("Accept", viewmodel);
        }

        [HttpPost]
        public ActionResult Confirm(JobOfferConfirmDto dto)
        {
            if (this.ModelState.IsValid)
            {
                this.jobofferService.ConfirmOffer(dto);
                return this.RedirectToAction("Details", "JobOffer", new { id = dto.JobOfferId });
            }
            var viewmodel = new JobOfferConfirmViewModel(dto);
            return this.View("Confirm", viewmodel);
        }

        [HttpGet]
        public ActionResult ContactDetails(long id)
        {
            var viewmodel = this.jobofferService.GetContactDetailsById(id);
            return this.View("ContactDetails", viewmodel);
        }
    }
}