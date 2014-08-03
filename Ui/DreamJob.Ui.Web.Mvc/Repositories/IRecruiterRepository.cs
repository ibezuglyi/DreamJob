using DreamJob.Model.Domain;

namespace DreamJob.Ui.Web.Mvc.Repositories
{
    public interface IRecruiterRepository
    {
        void Add(Recruiter recruiter);
        void ConfirmRecruterRegistration(string hash);
    }
}