using DreamJob.Ui.Web.Mvc.Helpers;

namespace DreamJob.Ui.Web.Mvc.Controllers
{
    using System.Web.Mvc;

    using DreamJob.Ui.Web.Mvc.BusinessServices;
    
    [Authorize]
    public class CommentController : Controller
    {
        private readonly ICommentBusiness commentBusiness;

        public CommentController(ICommentBusiness commentBusiness)
        {
            this.commentBusiness = commentBusiness;
        }

        [HttpPost]
        public JsonResult Add(long offerId, string text)
        {
            var result = this.commentBusiness.AddNewComment(offerId, text, this.GetSystemLoginUrl());
            return this.Json(result);
        }
    }
}
