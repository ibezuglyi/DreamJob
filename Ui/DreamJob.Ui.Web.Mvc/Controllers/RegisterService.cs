using DreamJob.Ui.Web.Mvc.Models.Dto;

namespace DreamJob.Ui.Web.Mvc.Controllers
{
    using AutoMapper;

    using DreamJob.Common.Enum;
    using DreamJob.Model.Domain;

    public class RegisterService : IRegisterService
    {
        private readonly IDateTimeAdapter datetime;
        private readonly IPasswordHasher passwordHasher;
        private readonly IDeveloperRepository developerRepository;
        private readonly IRecruiterRepository recruiterRepository;

        public RegisterService(
            IDateTimeAdapter datetime,
            IDeveloperRepository developerRepository,
            IPasswordHasher passwordHasher,
            IRecruiterRepository recruiterRepository)
        {
            this.datetime = datetime;
            this.developerRepository = developerRepository;
            this.passwordHasher = passwordHasher;
            this.recruiterRepository = recruiterRepository;
        }

        public DjOperationResult<bool> AddNewDeveloper(UserRegistrationDto model)
        {
            var developer = Mapper.Map<UserRegistrationDto, Developer>(model);
            developer.AccountType = UserAccountType.Developer;
            developer.LastLoginDateTime = this.datetime.Now;
            developer.Registered = this.datetime.Now;
            developer.PasswordHash = this.passwordHasher.GetHash(model.Password);

            this.developerRepository.Add(developer);

            return DjOperationResult<bool>.Success();
        }

        public DjOperationResult<bool> AddNewRecruiter(UserRegistrationDto model)
        {
            var recruiter = Mapper.Map<UserRegistrationDto, Recruiter>(model);
            recruiter.AccountType = UserAccountType.Recruiter;
            recruiter.LastLoginDateTime = this.datetime.Now;
            recruiter.Registered = this.datetime.Now;
            recruiter.PasswordHash = this.passwordHasher.GetHash(model.Password);

            this.recruiterRepository.Add(recruiter);

            return DjOperationResult<bool>.Success();
        }
    }
}