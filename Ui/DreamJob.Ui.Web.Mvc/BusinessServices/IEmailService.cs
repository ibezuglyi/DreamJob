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
        void NotifyNewMessageReceived(string recepientEmail, string subject, string recepientDisplayName, string senderDisplayName, string loginUrl);
        void NotifyNewMessageReceived(string recepientEmail, string recepientDisplayName, string senderDisplayName, string loginUrl);
        void NotifyOfferAccepted(string email, string displayName, string title, string loginUrl);
        void NotifyOfferRejected(string email, string displayName, string title, string loginUrl);
        void NotifyOfferCanceled(string email, string displayName, string subject, string loginUrl);
        void NotifyNewErrorOccurs(Exception exception);
    }
}
