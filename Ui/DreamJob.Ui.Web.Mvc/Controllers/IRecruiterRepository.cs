namespace DreamJob.Ui.Web.Mvc.Controllers
{
    using DreamJob.Model.Domain;

    public interface IRecruiterRepository
    {
        void Add(Recruiter recruiter);
        void ConfirmRecruterRegistration(string hash);
    }
}