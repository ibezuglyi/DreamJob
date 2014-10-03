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

        private IGuidAdapter guid
            ;

        public RegisterService(
            IDateTimeAdapter datetime,
            IDeveloperRepository developerRepository,
            IPasswordHasher passwordHasher,
            IRecruiterRepository recruiterRepository,
            IGuidAdapter guid)
        {
            this.datetime = datetime;
            this.developerRepository = developerRepository;
            this.passwordHasher = passwordHasher;
            this.recruiterRepository = recruiterRepository;
            this.guid = guid;
        }

        public DjOperationResult<string> AddNewDeveloper(UserRegistrationDto model)
        {
            var developer = Mapper.Map<UserRegistrationDto, Developer>(model);
            developer.AccountType = UserAccountType.Developer;
            var now = this.datetime.Now;

            developer.LastLoginDateTime = now;
            developer.Add = now;
            developer.Registered = now;
            developer.Edit = now;
            developer.PasswordHash = this.passwordHasher.GetHash(model.Password, now.ToFileTime().ToString());
            var confirmationKey = "D" + this.guid.GetTimesBy(10);
            var newConfirmation = new Confirmation(confirmationKey);
            newConfirmation.Add = now;
            newConfirmation.Edit = now;
            developer.Confirmations.Add(newConfirmation);

            this.developerRepository.Add(developer);

            return new DjOperationResult<string>(newConfirmation.ConfirmationCode);
        }

        public DjOperationResult<string> AddNewRecruiter(UserRegistrationDto model)
        {
            var recruiter = Mapper.Map<UserRegistrationDto, Recruiter>(model);
            recruiter.AccountType = UserAccountType.Recruiter;
            var now = this.datetime.Now;
            recruiter.LastLoginDateTime = now;
            recruiter.Registered = now;
            recruiter.PasswordHash = this.passwordHasher.GetHash(model.Password, now.ToFileTime().ToString());
            var confirmationKey = "R" + this.guid.GetTimesBy(10);
            var newConfirmation = new Confirmation(confirmationKey);
            recruiter.Add = now;
            recruiter.Edit = now;
            newConfirmation.Add = now;
            newConfirmation.Edit = now;
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