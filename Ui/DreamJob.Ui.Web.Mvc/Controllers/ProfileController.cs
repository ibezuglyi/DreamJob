﻿using DreamJob.Common.Enum;
using DreamJob.Ui.Web.Mvc.Models.Dto;
using  DreamJob.Ui.Web.Mvc.Helpers;

namespace DreamJob.Ui.Web.Mvc.Controllers
{
    using System;
    using System.Web.Mvc;

    using DreamJob.Ui.Web.Mvc.BusinessServices;

    [Authorize]
    public class ProfileController : Controller
    {
        private readonly IProfileBusiness profileBusiness;

        public ProfileController(IProfileBusiness profileBusiness)
        {
            this.profileBusiness = profileBusiness;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return this.View("Index");
        }

        [HttpPost]
        public JsonResult CurrentUser(UserProfileDto profile)
        {
            LoginUserDto currentUser = HttpContext.Session[DjSessionKeys.CurrentUser] as LoginUserDto;
            var updateResult = new DjOperationResult<bool>(true);
            if (currentUser.AccountType == UserAccountType.Developer)
            {
                updateResult = this.profileBusiness.UpdateDeveloperProfile(currentUser.Id, profile);
            }
            else
            {
                
            }
            return this.DjJson(updateResult);
        }

        [HttpGet]
        public JsonResult CurrentUser()
        {
            var getprofileResult = this.profileBusiness.GetCurrentUserProfile();
            return this.DjJson(getprofileResult);
        }

        
    }
}