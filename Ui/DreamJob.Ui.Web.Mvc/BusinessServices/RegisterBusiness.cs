using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Web.Mvc;

namespace DreamJob.Ui.Web.Mvc.BusinessServices
{
    using DreamJob.Common.Enum;
    using DreamJob.Ui.Web.Mvc.Models;
    using DreamJob.Ui.Web.Mvc.Models.Dto;
    using DreamJob.Ui.Web.Mvc.Services;

    public class RegisterBusiness : IRegisterBusiness
    {
        private readonly IRegisterService registerService;
        private readonly IEmailService emailService;

        public RegisterBusiness(IRegisterService registerService, IEmailService emailService)
        {
            this.registerService = registerService;
            this.emailService = emailService;
        }

        public DjOperationResult<UserRegistrationViewModel> GetRegisterViewModel()
        {
            var data = new UserRegistrationViewModel();
            var result = new DjOperationResult<UserRegistrationViewModel>(data);
            return result;
        }

        public DjOperationResult<string> RegisterDeveloper(UserRegistrationDto model, UrlHelper url, string scheme)
        {
            var confirmationResult = this.registerService.AddNewDeveloper(model);
            var activationUrl = GetActivationUrl(url, confirmationResult, scheme);
            emailService.SendDeveloperGreetings(model.Email, model.DisplayName, activationUrl);
            return confirmationResult;
        }

        private static string GetActivationUrl(UrlHelper url, DjOperationResult<string> confirmationResult, string scheme)
        {
            var activationUrl = url.Action("Confirm", "Register", new { h = confirmationResult.Data }, scheme);
            return activationUrl;
        }

        public DjOperationResult<string> RegisterRecruiter(UserRegistrationDto model, UrlHelper url, string scheme)
        {
            var confirmationResult = this.registerService.AddNewRecruiter(model);
            var activationUrl = GetActivationUrl(url, confirmationResult, scheme);
            emailService.SendRecruiterGreetings(model.Email, model.DisplayName, activationUrl);
            return confirmationResult;
        }

        public void ConfirmUserRegistration(string hash)
        {
            this.registerService.ConfirmUserRegistration(hash);
        }

        public bool IsEmailUnique(string email)
        {
            return registerService.IsEmailUnique(email);
        }

        public bool IsDisplayNameUnique(string displayName)
        {
            return registerService.IsDisplayNameUnique(displayName);
        }

        public bool IsLoginUnique(string login)
        {
            return registerService.IsLoginUnique(login);
        }
    }
}