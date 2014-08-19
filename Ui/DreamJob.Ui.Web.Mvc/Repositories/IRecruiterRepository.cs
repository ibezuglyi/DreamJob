namespace DreamJob.Ui.Web.Mvc.Repositories
{
    using DreamJob.Model.Domain;

    public interface IRecruiterRepository
    {
        void Add(Recruiter recruiter);
        void ConfirmRecruiterRegistration(string hash);
    }
}