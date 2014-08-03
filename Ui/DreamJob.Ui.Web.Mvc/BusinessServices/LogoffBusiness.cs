﻿using DreamJob.Common.Enum;

namespace DreamJob.Ui.Web.Mvc.BusinessServices
{
    class LogoffBusiness : ILogoffBusiness
    {
        private readonly IAuthentication authentication;

        private readonly ISession session;

        public LogoffBusiness(IAuthentication authentication, ISession session)
        {
            this.authentication = authentication;
            this.session = session;
        }

        public DjOperationResult<bool> LogoffUser()
        {
            var logoffResult = this.authentication.LogoffUser();
            if (logoffResult.IsSuccess == false)
            {
                return logoffResult;
            }

            var sessionResult = this.session.ClearUserData();
            return sessionResult;
        }
    }
}