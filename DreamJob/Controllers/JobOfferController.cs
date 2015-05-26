using DreamJob.ExtensionMethods;

namespace DreamJob.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using Dtos;
    using Services;
    using ViewModels;

    [Authorize]
    public class JobOfferController : DjBaseController
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
            var viewModel = this.jobofferService.GetJobOfferSendViewModel(id);
            return this.View("Send", viewModel);
        }

        [HttpGet]
        public ActionResult SendJobOfferDialog(long id)
        {
            var result = new DjJsonResultDto<string>();
            var viewmodel = this.jobofferService.GetJobOfferSendViewModel(id);
            var viewAsString = this.PartialViewAsString("_SendJobOfferForm", viewmodel);
            result.Success = true;
            result.Data = viewAsString;
            var jsonResult = new JsonResult() { Data = result, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            return jsonResult;
        }

        [HttpPost]
        public ActionResult SendJobOfferDialog(JobOfferSendDto dto)
        {
            var result = new DjJsonResultDto<string>();
            if (this.ModelState.IsValid)
            {
                this.jobofferService.Add(dto);
                result.Success = true;
                result.Data = string.Empty;
            }
            else
            {
                result.Success = false;
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
                result.Errors = errors.ToList();
            }

            var jsonResult = new JsonResult { Data = result };
            return jsonResult;
        }

        [HttpPost]
        public ActionResult Send(JobOfferSendDto dto)
        {
            if (this.ModelState.IsValid)
            {
                this.jobofferService.Add(dto);
                return this.RedirectToAction("Index", "Home");
            }
            var viewmodel = this.jobofferService.GetJobOfferSendViewModel(dto);
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
        public ActionResult StatusChange(long id, JobOfferStatus status)
        {
            var viewAsString = string.Empty;
            var result = new DjJsonResultDto<string>();
            result.Success = true;
            switch (status)
            {
                case JobOfferStatus.Rejected:
                    var rejectViewModel = this.jobofferService.GetJobOfferRejectViewModel(id);
                    viewAsString = this.PartialViewAsString("_JobOfferRejectForm", rejectViewModel);
                    break;
                case JobOfferStatus.Canceled:
                    var cancelViewModel = this.jobofferService.GetJobOfferCancelViewModel(id);
                    viewAsString = this.PartialViewAsString("_JobOfferCancelForm", cancelViewModel);
                    break;
                case JobOfferStatus.Accepted:
                    var acceptViewModel = this.jobofferService.GetJobOfferAcceptViewModel(id);
                    viewAsString = this.PartialViewAsString("_JobOfferAcceptForm", acceptViewModel);
                    break;
                case JobOfferStatus.Confirmed:
                    var confirmViewModel = this.jobofferService.GetJobOfferConfirmViewModel(id);
                    viewAsString = this.PartialViewAsString("_JobOfferConfirmForm", confirmViewModel);
                    break;
                default:
                    result.Success = false;
                    result.Errors = new List<string> { "Status unknown" };
                    break;
            }

            result.Data = viewAsString;
            var jsonResult = new JsonResult { Data = result, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            return jsonResult;
        }

        [HttpPost]
        public ActionResult StatusChange(JobOfferStatusChangeDto dto)
        {
            var result = new DjJsonResultDto<string>();
            if (ModelState.IsValid)
            {
                this.jobofferService.ChangeStatus(dto);
                result.Success = true;
                result.Data = string.Empty;
            }
            else
            {
                result.Success = false;
                result.Errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
            }

            var jsonResult = new JsonResult { Data = result };
            return jsonResult;
        }

        [HttpGet]
        public ActionResult Reject(long id)
        {
            var viewmodel = this.jobofferService.GetJobOfferRejectViewModel(id);
            return this.View(viewmodel);
        }

        [HttpGet]
        public ActionResult Cancel(long id)
        {
            var viewmodel = this.jobofferService.GetJobOfferCancelViewModel(id);
            return this.View(viewmodel);
        }

        [HttpGet]
        public ActionResult Accept(long id)
        {
            var viewmodel = this.jobofferService.GetJobOfferAcceptViewModel(id);
            return this.View(viewmodel);
        }

        [HttpGet]
        public ActionResult Confirm(long id)
        {
            var viewmodel = this.jobofferService.GetJobOfferConfirmViewModel(id);
            return this.View( viewmodel);
        }


        [HttpPost]
        public ActionResult Reject(JobOfferRejectDto dto)
        {
            if (this.ModelState.IsValid)
            {
                this.jobofferService.RejectOffer(dto);
                return this.RedirectToAction("Details", "JobOffer", new { id = dto.JobOfferId });
            }
            var viewmodel = this.jobofferService.GetJobOfferRejectViewModel(dto);
            return this.View(viewmodel);

        }

        [HttpPost]
        public ActionResult Cancel(JobOfferCancelDto dto)
        {
            if (this.ModelState.IsValid)
            {
                this.jobofferService.CancelOffer(dto);
                return this.RedirectToAction("Details", "JobOffer", new { id = dto.JobOfferId });
            }
            var viewmodel = this.jobofferService.GetJobOfferCancelViewModel(dto);
            return this.View("Cancel", viewmodel);
        }

        [HttpPost]
        public ActionResult Accept(JobOfferAcceptDto jobOfferAcceptDto)
        {
            if (this.ModelState.IsValid)
            {
                this.jobofferService.AcceptOffer(jobOfferAcceptDto);
                return this.RedirectToAction("Details", "JobOffer", new { id = jobOfferAcceptDto.JobOfferId });
            }
            var viewmodel = jobofferService.GetJobOfferAcceptViewModel(jobOfferAcceptDto);
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
            var viewmodel = this.jobofferService.GetJobOfferConfirmViewModel(dto);
            return this.View("Confirm", viewmodel);
        }

        [HttpGet]
        public ActionResult ContactDetails(long id)
        {
            var viewmodel = this.jobofferService.GetContactDetailsById(id);
            return this.View("ContactDetails", viewmodel);
        }

        [HttpGet]
        public ActionResult ContactDetailsPartial(long id)
        {
            var viewmodel = this.jobofferService.GetContactDetailsById(id);
            var viewAsString = this.PartialViewAsString("ContactDetails", viewmodel);
            var result = new DjJsonResultDto<string>();
            result.Success = true;
            result.Data = viewAsString;
            var jsonResult = new JsonResult { Data = result, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            return jsonResult;
        }


    }
}