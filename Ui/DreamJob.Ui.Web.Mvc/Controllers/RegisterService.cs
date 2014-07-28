using System;
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

        public DjOperationResult<string> AddNewDeveloper(UserRegistrationDto model)
        {
            var developer = Mapper.Map<UserRegistrationDto, Developer>(model);
            developer.AccountType = UserAccountType.Developer;
            developer.LastLoginDateTime = this.datetime.Now;
            developer.Registered = this.datetime.Now;
            developer.PasswordHash = this.passwordHasher.GetHash(model.Password);
            developer.ConfirmationCode =String.Format("{0}{1}","d", this.passwordHasher.GetHash(string.Format("{0}+{1}*){2}_a", developer.Login, developer.Email,
                    developer.Registered)));
            this.developerRepository.Add(developer);

            return new DjOperationResult<string>(developer.ConfirmationCode);
        }

        public DjOperationResult<string> AddNewRecruiter(UserRegistrationDto model)
        {
            var recruiter = Mapper.Map<UserRegistrationDto, Recruiter>(model);
            recruiter.AccountType = UserAccountType.Recruiter;
            recruiter.LastLoginDateTime = this.datetime.Now;
            recruiter.Registered = this.datetime.Now;
            recruiter.PasswordHash = this.passwordHasher.GetHash(model.Password);
            recruiter.ConfirmationCode = string.Format("{0}{1}","r",
                this.passwordHasher.GetHash(string.Format("{0}-{1}={2}_a", recruiter.Login, recruiter.Email,
                    recruiter.Registered)));
            this.recruiterRepository.Add(recruiter);

            return new DjOperationResult<string>(recruiter.ConfirmationCode);
        }

        public void ConfirmUserRegistration(string hash)
        {
            if(string.IsNullOrWhiteSpace(hash))
                return;

            if (hash.StartsWith("r"))
            {
                recruiterRepository.ConfirmRecruterRegistration(hash);
            }
            else if(hash.StartsWith("d"))
            {
                developerRepository.ConfirmDeveloperRegistration(hash);
            }
        }
    }
}