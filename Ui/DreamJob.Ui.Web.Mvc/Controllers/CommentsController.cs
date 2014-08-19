namespace DreamJob.Ui.Web.Mvc.Controllers
{
    using System.Web.Mvc;

    public class CommentsController : Controller
    {
        private readonly ICommentsLogic commentsLogic;

        public CommentsController(ICommentsLogic commentsLogic)
        {
            this.commentsLogic = commentsLogic;
        }

        [HttpPost]
        [Authorize]
        public JsonResult Add(long offerId, string text)
        {
            var result = this.commentsLogic.AddNewComment(offerId, text);
            return this.Json(result);
        }
    }
}
