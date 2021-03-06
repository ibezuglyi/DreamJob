﻿using System.Linq;
using DreamJob.Ui.Web.Mvc.Models.Dto;

namespace DreamJob.Ui.Web.Mvc
{
    using System.Web;

    using DreamJob.Common.Enum;

    class Session : ISession
    {
        public DjOperationResult<bool> SetCurrentUser(LoginUserDto data)
        {
            HttpContext.Current.Session[DjSessionKeys.CurrentUser] = data;
            HttpContext.Current.Session[DjSessionKeys.DisplayName] = data.DisplayName;
            return DjOperationResult<bool>.Success();
        }

        public DjOperationResult<bool> ClearUserData()
        {
            HttpContext.Current.Session.Clear();
            return DjOperationResult<bool>.Success();
        }

        public DjOperationResult<LoginUserDto> GetCurrentUser()
        {
            var loggedInUser = HttpContext.Current.Session[DjSessionKeys.CurrentUser] as LoginUserDto;
            if (loggedInUser == null)
            {
                return new DjOperationResult<LoginUserDto>(false, Enumerable.Repeat("User is not logged in", 1));
            }

            return new DjOperationResult<LoginUserDto>(loggedInUser);
        }
    }
}