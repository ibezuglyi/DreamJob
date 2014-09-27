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

        public DjOperationResult<string> RegisterDeveloper(UserRegistrationDto model)
        {
            var result = this.registerService.AddNewDeveloper(model);
            emailService.SendDeveloperGreetings(model.Email, model.DisplayName);
            return result;
        }

        public DjOperationResult<string> RegisterRecruiter(UserRegistrationDto model)
        {
            var result = this.registerService.AddNewRecruiter(model);
            emailService.SendRecruiterGreetings(model.Email, model.DisplayName);
            return result;
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