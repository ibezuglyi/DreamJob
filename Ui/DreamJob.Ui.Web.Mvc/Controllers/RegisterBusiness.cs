using DreamJob.Ui.Web.Mvc.Models;
using DreamJob.Ui.Web.Mvc.Models.Dto;

namespace DreamJob.Ui.Web.Mvc.Controllers
{
    using DreamJob.Common.Enum;

    class RegisterBusiness : IRegisterBusiness
    {
        private readonly IRegisterService registerService;

        public RegisterBusiness(IRegisterService registerService)
        {
            this.registerService = registerService;
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
            return result;
        }

        public DjOperationResult<string> RegisterRecruiter(UserRegistrationDto model)
        {
            var result = this.registerService.AddNewRecruiter(model);
            return result;
        }

        public void ConfirmUserRegistration(string hash)
        {
            this.registerService.ConfirmUserRegistration(hash);
        }
    }
}