using DreamJob.Ui.Web.Mvc.Helpers;

namespace DreamJob.Ui.Web.Mvc.Controllers
{
    using System.Web.Mvc;

    using DreamJob.Ui.Web.Mvc.BusinessServices;

    public class CommentController : BaseController
    {
        private readonly ICommentBusiness commentBusiness;

        public CommentController(ICommentBusiness commentBusiness, IEmailService emailService)
            : base(emailService)
        {
            this.commentBusiness = commentBusiness;
        }

        [HttpPost]
        [Authorize]
        public JsonResult Add(long offerId, string text)
        {
            var result = this.commentBusiness.AddNewComment(offerId, text, this.GetSystemLoginUrl());
            return this.Json(result);
        }
    }
}
