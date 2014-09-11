using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Razor;
using System.Web.UI.WebControls;
using Microsoft.CSharp;
using RazorEngine;
using RazorEngine.Templating;

namespace DreamJob.Ui.Web.Mvc.BusinessServices
{
    public class RazorTemplateProvider : ITemplateProvider
    {
        public string GetEmailTextFromTemplate(EmailType emailType, object viewModel)
        {
            var type = emailType.ToString();
            var path = HttpContext.Current.Server.MapPath(string.Format("~/EmailTemplates/{0}.html", type));
            var template = File.ReadAllText(path);
            string result = Razor.Parse(template, viewModel);
            return result;
        }
    }
}