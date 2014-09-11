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

        public EmailService(IEmailTemplateProvider emailTemplateProvider)
        {
            this.emailTemplateProvider = emailTemplateProvider;
            EmailFrom = WebConfigurationManager.AppSettings["Email_From"];
            EmailDomain = WebConfigurationManager.AppSettings["Email_Domain"];
            EmailResource = WebConfigurationManager.AppSettings["Email_Resource"];
            EmailBaseUrl = WebConfigurationManager.AppSettings["Email_BaseUrl"];
        }

        public string EmailBaseUrl { get; set; }
        public string EmailResource { get; set; }
        public string EmailDomain { get; set; }
        public string EmailFrom { get; set; }

        public void SendEmailMessage(string to, string from, string subject, string content)
        {
            var client = GetRestClient();
            var request = GetEmailRequest(to, from, subject, content);
            client.ExecuteAsync(request, response =>
            {
                //to log
            });
        }

        public void SendDeveloperGreetings(string to, string userName)
        {
            var content = emailTemplateProvider.GetEmailText(EmailType.DeveloperGreetings, new { UserName = userName });
            SendEmailMessage(to, EmailFrom, WelcomeToDreamJobSubject, content);
        }

        public void SendRecruiterGreetings(string to, string userName)
        {
            var content = emailTemplateProvider.GetEmailText(EmailType.RecruiterGreeting, new { UserName = userName });
            SendEmailMessage(to, EmailFrom, WelcomeToDreamJobSubject, content);
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
            client.Authenticator = new HttpBasicAuthenticator("api", "key-XXX");
            return client;
        }
    }
}