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

        public DjOperationResult<bool> AddNewDeveloper(RegisterUserViewModel model)
        {
            var developer = Mapper.Map<RegisterUserViewModel, Developer>(model);
            developer.AccountType = UserAccountType.Developer;
            developer.Add = this.datetime.Now;
            developer.Edit = this.datetime.Now;
            developer.LastLoginDateTime = this.datetime.Now;
            developer.Registered = this.datetime.Now;
            developer.PasswordHash = this.passwordHasher.GetHash(model.Password);

            this.developerRepository.Add(developer);

            return DjOperationResult<bool>.Success();
        }

        public DjOperationResult<bool> AddNewRecruiter(RegisterUserViewModel model)
        {
            var recruiter = Mapper.Map<RegisterUserViewModel, Recruiter>(model);
            recruiter.AccountType = UserAccountType.Developer;
            recruiter.Add = this.datetime.Now;
            recruiter.Edit = this.datetime.Now;
            recruiter.LastLoginDateTime = this.datetime.Now;
            recruiter.Registered = this.datetime.Now;
            recruiter.PasswordHash = this.passwordHasher.GetHash(model.Password);

            this.recruiterRepository.Add(recruiter);

            return DjOperationResult<bool>.Success();
        }
    }
}