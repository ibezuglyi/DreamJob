namespace DreamJob.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using DreamJob.Controllers.ExtensionMethods;
    using DreamJob.Dtos;
    using DreamJob.Services;

    [Authorize]
    public class CommentController : Controller
    {
        private readonly ICommentService commentService;

        public CommentController(ICommentService commentService)
        {
            this.commentService = commentService;
        }

        [HttpPost]
        public ActionResult Add(CommentAddDto dto)
        {
            if (this.ModelState.IsValid)
            {
                this.commentService.Add(dto);
            }
            return this.RedirectToAction("Details", "JobOffer", new { id = dto.JobOfferId });
        }

        [HttpPost]
        public ActionResult AddPartial(CommentAddDto dto)
        {
            var result = new DjJsonResultDto<string>();
            if (this.ModelState.IsValid)
            {
                var viewModel = this.commentService.AddAndGetViewModelForCurrentUser(dto);
                var viewAsString = this.PartialViewAsString("_JobOfferComment", viewModel);
                result.Success = true;
                result.Data = viewAsString;
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

    }
}