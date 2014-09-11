namespace DreamJob.Ui.Web.Mvc.BusinessServices
{
    public interface ITemplateProvider
    {
        string GetEmailTextFromTemplate(EmailType emailType, object viewModel);
    }
}