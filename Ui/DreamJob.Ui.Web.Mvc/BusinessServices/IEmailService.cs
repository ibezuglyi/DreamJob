using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DreamJob.Ui.Web.Mvc.BusinessServices
{
    public interface IEmailService
    {
        void SendEmailMessage(string to, string from, string subject, string content);
        void SendDeveloperGreetings(string to, string userName, string confirmationUrl);
        void SendRecruiterGreetings(string to, string userName, string confirmationUrl);
    }
}
