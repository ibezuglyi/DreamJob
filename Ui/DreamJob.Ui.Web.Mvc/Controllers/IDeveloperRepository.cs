namespace DreamJob.Ui.Web.Mvc.Controllers
{
    using DreamJob.Model.Domain;

    public interface IDeveloperRepository
    {
        void Add(Developer developer);
    }
}