﻿namespace DreamJob.Ui.Web.Mvc.Controllers
{
    using System;
    using System.Web.Mvc;

    using DreamJob.Common.Enum;
    using DreamJob.Ui.Web.Mvc.BusinessServices;

    [Authorize]
    public class DeveloperController : Controller
    {
        private readonly IDeveloperBusiness businessDeveloper;
        private readonly ISession session;

        public DeveloperController(IDeveloperBusiness businessDeveloper, ISession session)
        {
            this.businessDeveloper = businessDeveloper;
            this.session = session;
        }

        public ActionResult Index()
        {
            var allDevsViewModelResult = this.businessDeveloper.GetAllDevelopersViewModel();
            if (allDevsViewModelResult.IsSuccess)
            {
                return this.View("Index", allDevsViewModelResult.Data);
            }

            throw new Exception("Index");
        }

        public ActionResult Profile(long id)
        {
            var getDeveloperProfileResult = this.businessDeveloper.GetDeveloperPublicViewModel(id);
            if (getDeveloperProfileResult.IsSuccess == false)
            {
                throw new Exception("Developer");
            }

            return this.View("Developer", getDeveloperProfileResult.Data);
        }
    }
}