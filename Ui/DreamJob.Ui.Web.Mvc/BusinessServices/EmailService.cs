using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
                                              "key-XXX");
            RestRequest request = new RestRequest();
            request.AddParameter("domain",
                                "mg.dream-job.pl", ParameterType.UrlSegment);
            request.Resource = "{domain}/messages";
            request.AddParameter("from", "<noreply@mg.dream-job.pl>");
            request.AddParameter("to", to);
            request.AddParameter("subject", "Hello form dreamjob, yo, yo, yo!!111oneoneone");
            request.AddParameter("text", "Congratulations dreamjob, you just sent an email!");
            request.Method = Method.POST;
            return client.Execute(request);
        }
    }
}