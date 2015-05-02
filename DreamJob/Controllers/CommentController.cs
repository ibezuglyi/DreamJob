using DreamJob.ExtensionMethods;

namespace DreamJob.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Dtos;
    using Services;

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
            var result = new DjJsonResultDto<bool>();
            if (this.ModelState.IsValid)
            {
                this.commentService.Add(dto);
                result.Success = true;
                result.Data = true;
            }
            else
            {
                result.Success = false;
                var errors = this.ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
                result.Errors = errors.ToList();
            }

            var jsonResult = new JsonResult { Data = result };
            return jsonResult;
        }


        [HttpGet]
        public ActionResult GetNewComments(long jobOfferId, int commentsCount)
        {
            var result = new DjJsonResultDto<string>();
            var viewModel = this.commentService.GetNewComments(jobOfferId, commentsCount);
            var viewAsString = this.PartialViewAsString("_JobOfferComments", viewModel);
            result.Success = true;
            result.Data = viewAsString;
            var jsonResult = new JsonResult { Data = result, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            return jsonResult;
        }
    }
}