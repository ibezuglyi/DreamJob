namespace DreamJob.Ui.Web.Mvc.Services
{
    using System;

    using AutoMapper;

    using DreamJob.Common.Enum;
    using DreamJob.Model.Domain;
    using DreamJob.Ui.Web.Mvc.Helpers;
    using DreamJob.Ui.Web.Mvc.Models.Dto;
    using DreamJob.Ui.Web.Mvc.Repositories;

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
            var newConfirmation =
                new Confirmation(String.Format("{0}{1}", "D",
                    this.passwordHasher.GetHash(string.Format("{0}+{1}*){2}_a", developer.Login, developer.Email,
                        developer.Registered))));
            newConfirmation.Add = this.datetime.Now;
            newConfirmation.Edit = this.datetime.Now;
            developer.Confirmations.Add(newConfirmation);

            this.developerRepository.Add(developer);

            return new DjOperationResult<string>(newConfirmation.ConfirmationCode);
        }

        public DjOperationResult<string> AddNewRecruiter(UserRegistrationDto model)
        {
            var recruiter = Mapper.Map<UserRegistrationDto, Recruiter>(model);
            recruiter.AccountType = UserAccountType.Recruiter;
            recruiter.LastLoginDateTime = this.datetime.Now;
            recruiter.Registered = this.datetime.Now;
            recruiter.PasswordHash = this.passwordHasher.GetHash(model.Password);
            var newConfirmation = new Confirmation(string.Format("{0}{1}", "R",
                this.passwordHasher.GetHash(string.Format("{0}-{1}={2}_a", recruiter.Login, recruiter.Email,
                    recruiter.Registered))));
            newConfirmation.Add = this.datetime.Now;
            newConfirmation.Edit = this.datetime.Now;
            recruiter.Confirmations.Add(newConfirmation);
            this.recruiterRepository.Add(recruiter);

            return new DjOperationResult<string>(newConfirmation.ConfirmationCode);
        }

        public void ConfirmUserRegistration(string hash)
        {
            if (string.IsNullOrWhiteSpace(hash))
            {
                return;
            }

            if (hash.StartsWith("R"))
            {
                this.recruiterRepository.ConfirmRecruiterRegistration(hash);
            }
            else if (hash.StartsWith("D"))
            {
                this.developerRepository.ConfirmDeveloperRegistration(hash);
            }
        }

        public bool IsEmailUnique(string email)
        {
            return developerRepository.IsEmailUnique(email);
        }

        public bool IsDisplayNameUnique(string displayName)
        {
            return developerRepository.IsDisplayNameUnique(displayName);
        }

        public bool IsLoginUnique(string login)
        {
            return developerRepository.IsLoginUnique(login);
        }
    }
}