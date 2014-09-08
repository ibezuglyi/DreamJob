namespace DreamJob.Ui.Web.Mvc.Controllers
{
    using DreamJob.Ui.Web.Mvc.Models.Dto;

    public class OfferIndexViewModel
    {
        public OfferIndexViewModel(LoginUserDto currentUser)
        {
            this.CurrentUser = currentUser;
        }

        public LoginUserDto CurrentUser { get; set; }
    }
}