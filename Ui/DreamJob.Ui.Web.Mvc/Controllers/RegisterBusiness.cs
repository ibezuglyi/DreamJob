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

        public DjOperationResult<RegisterUserViewModel> GetRegisterViewModel()
        {
            var data = new RegisterUserViewModel();
            var result = new DjOperationResult<RegisterUserViewModel>(data);
            return result;
        }

        public DjOperationResult<bool> RegisterDeveloper(RegisterUserViewModel model)
        {
            var result = this.registerService.AddNewDeveloper(model);
            return result;
        }

        public DjOperationResult<bool> RegisterRecruiter(RegisterUserViewModel model)
        {
            var result = this.registerService.AddNewRecruiter(model);
            return result;
        }
    }
}