using AutoMapper;
using DreamJob.Common.Enum;
using DreamJob.Model.Domain;
using DreamJob.Ui.Web.Mvc.Models.Dto;
using DreamJob.Ui.Web.Mvc.Repositories;

namespace DreamJob.Ui.Web.Mvc.Services
{
    using DreamJob.Ui.Web.Mvc.Controllers;

    using Microsoft.Ajax.Utilities;

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

        public void UpdateRecruiterProfile(SaveRecruiterProfileDto model)
        {
            var recruiterResult = recruiterRepository.GetRecruiterById(model.Id);

            if (recruiterResult.IsSuccess)
            {
                var recruiter = recruiterResult.Data;
                recruiter.FirstName = model.FirstName;
                recruiter.LastName = model.LastName;
                recruiter.Mobile = model.Mobile;
                recruiter.Company = model.Company;
                this.recruiterRepository.UpdateRecruiterProfile(recruiter);
            }
        }
    }
}