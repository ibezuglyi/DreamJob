using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Web;
using DreamJob.Ui.Web.Mvc.Models.Dto;

namespace DreamJob.Ui.Web.Mvc.Models
{
    public class UserRegistrationViewModel
    {
        public UserRegistrationDto User { get; set; }

        public UserRegistrationViewModel()
        {
            this.User = new UserRegistrationDto();
        }
    }
}