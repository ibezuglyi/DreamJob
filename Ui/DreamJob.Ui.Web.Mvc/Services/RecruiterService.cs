using AutoMapper;
using DreamJob.Common.Enum;
using DreamJob.Model.Domain;
using DreamJob.Ui.Web.Mvc.Models.Dto;
using DreamJob.Ui.Web.Mvc.Repositories;

namespace DreamJob.Ui.Web.Mvc.Services
{
    public class RecruiterService : IRecruiterService
    {
        private readonly IRecruiterRepository recruiterRepository;

        public RecruiterService(IRecruiterRepository recruiterRepository)
        {
            this.recruiterRepository = recruiterRepository;
        }

        public DjOperationResult<UserProfileDto> GetRecruiterPublicProfile(long id)
        {
            var recruiterResult = recruiterRepository.GetRecruiterById(id);
            if (recruiterResult.IsSuccess == false)
            {
                return new DjOperationResult<UserProfileDto>(false, recruiterResult.Errors);
            }

            return new DjOperationResult<UserProfileDto>(Mapper.Map<Recruiter, UserProfileDto>(recruiterResult.Data));
        }

        public void UpdateRecruiterProfile(long id, UserProfileDto profile)
        {
            var recruiterResult = recruiterRepository.GetRecruiterById(id);
            if (recruiterResult.IsSuccess)
            {
                var recruiter = recruiterResult.Data;
                recruiter.FirstName = profile.FirstName;
                recruiter.LastName = profile.LastName;
                recruiter.Mobile = profile.Mobile;
                recruiter.Company = profile.Company;
                this.recruiterRepository.UpdateRecruiterProfile(recruiter);
            }
        }
    }
}