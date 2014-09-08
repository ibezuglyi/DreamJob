using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RestSharp;

namespace DreamJob.Ui.Web.Mvc.BusinessServices
{
    public class EmailService:IEmailService
    {
        public IRestResponse SendSimpleMessage(string to = "dreamjob <noreply.dreamjob@gmail.com>")
        {
            RestClient client = new RestClient();
            client.BaseUrl = "https://api.mailgun.net/v2";
            client.Authenticator =
                   new HttpBasicAuthenticator("api",
                                              "key-cd8c73eca447de1e5c5315c2d7ad778d");
            RestRequest request = new RestRequest();
            request.AddParameter("domain",
                                "sandbox316ca7e6749a4dd19ec21a92d17ab1f7.mailgun.org", ParameterType.UrlSegment);
            request.Resource = "{domain}/messages";
            request.AddParameter("from", "Mailgun Sandbox <postmaster@sandbox316ca7e6749a4dd19ec21a92d17ab1f7.mailgun.org>");
            request.AddParameter("to", to);
            request.AddParameter("subject", "Hello dreamjob");
            request.AddParameter("text", "Congratulations dreamjob, you just sent an email with Mailgun!  You are truly awesome!  You can see a record of this email in your logs: https://mailgun.com/cp/log .  You can send up to 300 emails/day from this sandbox server.  Next, you should add your own domain so you can send 10,000 emails/month for free.");
            request.Method = Method.POST;
            return client.Execute(request);
        }
    }
}