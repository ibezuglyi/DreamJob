using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DreamJob.Ui.Web.Mvc.BusinessServices
{
    public class ErrorsBusiness : IErrorsBusiness
    {
        private readonly IEmailService emailService;

        public ErrorsBusiness(IEmailService emailService)
        {
            this.emailService = emailService;
        }

        public void SendEmailOnInternalError(Exception exception)
        {
            emailService.NotifyNewErrorOccurs(exception);
        }
    }
}