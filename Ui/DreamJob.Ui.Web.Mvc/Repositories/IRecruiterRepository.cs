using DreamJob.Common.Enum;
using DreamJob.Ui.Web.Mvc.Models.Dto;

namespace DreamJob.Ui.Web.Mvc.Repositories
{
    using DreamJob.Model.Domain;

    public interface IRecruiterRepository
    {
        void Add(Recruiter recruiter);
        void ConfirmRecruiterRegistration(string hash);
        DjOperationResult<Recruiter> GetRecruiterById(long id);
        void UpdateRecruiterProfile(Recruiter recruiter);
    }
}