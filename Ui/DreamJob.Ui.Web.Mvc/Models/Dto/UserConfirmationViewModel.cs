namespace DreamJob.Ui.Web.Mvc.Models.Dto
{
    public class UserConfirmationViewModel
    {
        public UserConfirmationViewModel(UserConfirmationDto userConfirmationDto)
        {
            this.UserConfirmationDto = userConfirmationDto;
        }

        public UserConfirmationDto UserConfirmationDto { get; set; }
    }
}