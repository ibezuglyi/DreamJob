namespace DreamJob.Controllers
{
    using System.Web.Mvc;

    using DreamJob.Dtos;
    using DreamJob.Services;

    public class CommentController : Controller
    {
        private readonly ICommentService commentService;

        public CommentController(ICommentService commentService)
        {
            this.commentService = commentService;
        }

        public ActionResult Add(CommentAddDto dto)
        {
            if (this.ModelState.IsValid)
            {
                this.commentService.Add(dto);
            }
            return this.RedirectToAction("Details", "JobOffer", new { id=dto.JobOfferId });
        }

    }
}