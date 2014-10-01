using System.Configuration;
using System.Runtime.Remoting.Messaging;
using System.Web.Razor;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace DreamJob.Ui.Web.Mvc.BusinessServices
{
    public class EmailService : IEmailService
    {
        private readonly IEmailTemplateProvider emailTemplateProvider;
        private const string WelcomeToDreamJobSubject = "Welcome to Dream job";
        private const string NewMessageSubject = "New message";

        private readonly string EmailBaseUrl;
        private readonly string EmailResource;
        private readonly string EmailDomain;
        private readonly string EmailFrom;
        private readonly string EmailApiCode;

        public EmailService(IEmailTemplateProvider emailTemplateProvider)
        {
            this.emailTemplateProvider = emailTemplateProvider;
            EmailFrom = WebConfigurationManager.AppSettings["Email_From"];
            EmailDomain = WebConfigurationManager.AppSettings["Email_Domain"];
            EmailResource = WebConfigurationManager.AppSettings["Email_Resource"];
            EmailBaseUrl = WebConfigurationManager.AppSettings["Email_BaseUrl"];
            EmailApiCode = WebConfigurationManager.AppSettings["Email_ApiCode"];
        }



        public void SendEmailMessage(string to, string from, string subject, string content)
        {
            var client = GetRestClient();
            var request = GetEmailRequest(to, from, subject, content);
            client.ExecuteAsync(request, response =>
            {
                //to log
            });
        }

        public void SendDeveloperGreetings(string to, string userName, string confirmationUrl)
        {
            SendGreetings(EmailType.DeveloperGreetings, to, userName, confirmationUrl);
        }

        private void SendGreetings(EmailType emailType, string to, string userName, string confirmationUrl)
        {
            var content = emailTemplateProvider.GetEmailText(emailType, new { UserName = userName, ConfirmationUrl = confirmationUrl });
            var inlineCssHtml = PreMailer.Net.PreMailer.MoveCssInline(content);
            SendEmailMessage(to, EmailFrom, WelcomeToDreamJobSubject, inlineCssHtml.Html);
        }

        public void SendRecruiterGreetings(string to, string userName, string confirmationUrl)
        {
            SendGreetings(EmailType.RecruiterGreeting, to, userName, confirmationUrl);
        }

        public void NotifyNewMessageReceived(string recepientEmail, string subject, string recepientDisplayName,
            string senderDisplayName, string loginUrl)
        {
            var content = emailTemplateProvider.GetEmailText(EmailType.NewMessage, new { UserName = recepientDisplayName, LoginUrl = loginUrl, Subject = subject, From = senderDisplayName });
            var inlineCssHtml = PreMailer.Net.PreMailer.MoveCssInline(content);
            SendEmailMessage(recepientEmail, EmailFrom, subject, inlineCssHtml.Html);
        }

        public void NotifyNewMessageReceived(string recepientEmail, string recepientDisplayName, string senderDisplayName,
            string loginUrl)
        {
            NotifyNewMessageReceived(recepientEmail, NewMessageSubject, recepientDisplayName, senderDisplayName,
                loginUrl);
        }

        private RestRequest GetEmailRequest(string to, string from, string subject, string content)
        {
            var request = new RestRequest(Method.POST);
            request.Resource = EmailResource;
            request.AddParameter("domain", EmailDomain, ParameterType.UrlSegment);
            request.AddParameter("from", from);
            request.AddParameter("to", to);
            request.AddParameter("subject", subject);
            request.AddParameter("html", content);
            return request;
        }

        private RestClient GetRestClient()
        {
            var client = new RestClient(EmailBaseUrl);
            client.Authenticator = new HttpBasicAuthenticator("api", EmailApiCode);
            return client;
        }

    }
}