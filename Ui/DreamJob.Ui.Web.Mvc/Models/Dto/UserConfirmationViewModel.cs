using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DreamJob.Ui.Web.Mvc.Models.Dto
{
    public class UserConfirmationViewModel
    {
        public UserConfirmationDto UserConfirmationDto { get; set; }

        public UserConfirmationViewModel(UserConfirmationDto userConfirmationDto)
        {
            this.UserConfirmationDto = userConfirmationDto;
        }
    }
}