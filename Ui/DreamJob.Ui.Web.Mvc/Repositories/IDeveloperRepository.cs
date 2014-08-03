using DreamJob.Model.Domain;

namespace DreamJob.Ui.Web.Mvc.Repositories
{
    public interface IDeveloperRepository
    {
        void Add(Developer developer);
        void ConfirmDeveloperRegistration(string hash);
    }
}