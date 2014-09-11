namespace DreamJob.Ui.Web.Mvc.BusinessServices
{
    public class EmailTemplateProvider : IEmailTemplateProvider
    {
        private readonly ITemplateProvider templateProvider;

        public EmailTemplateProvider(ITemplateProvider templateProvider)
        {
            this.templateProvider = templateProvider;
        }

        public string GetEmailText(EmailType emailType, object viewModel)
        {
            var content = templateProvider.GetEmailTextFromTemplate(emailType, viewModel);
            return content;
        }
    }
}