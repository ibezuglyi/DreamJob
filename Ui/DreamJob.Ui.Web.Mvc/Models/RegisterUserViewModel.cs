namespace DreamJob.Ui.Web.Mvc.Models
{
    using DreamJob.Ui.Web.Mvc.Models.Dto;

    public class UserRegistrationViewModel
    {
        public UserRegistrationViewModel()
        {
            this.User = new UserRegistrationDto();
        }

        public UserRegistrationDto User { get; set; }
    }
}