namespace DreamJob.Ui.Web.Mvc.Repositories
{
    using DreamJob.Model.Domain;

    public interface IDeveloperRepository
    {
        void Add(Developer developer);
        void ConfirmDeveloperRegistration(string hash);
    }
}