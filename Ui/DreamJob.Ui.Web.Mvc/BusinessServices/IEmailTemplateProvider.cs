using DreamJob.Model.Domain;

namespace DreamJob.Ui.Web.Mvc.BusinessServices
{
    public interface IEmailTemplateProvider
    {
        string GetEmailText(EmailType emailType, object viewModel);
    }
}