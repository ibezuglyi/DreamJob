namespace DreamJob.Ui.Web.Mvc.BusinessServices
{
    using DreamJob.Common.Enum;
    using DreamJob.Ui.Web.Mvc.Controllers;
    using DreamJob.Ui.Web.Mvc.Services;

    public class DeveloperBusiness : IDeveloperBusiness
    {
        private readonly IDeveloperService serviceDeveloper;

        public DeveloperBusiness(IDeveloperService serviceDeveloper)
        {
            this.serviceDeveloper = serviceDeveloper;
        }

        public DjOperationResult<AllDevelopersViewModel> GetAllDevelopersViewModel()
        {
            var operationResult = this.serviceDeveloper.GetAllDevelopersShortInfo();
            if (operationResult.IsSuccess == false)
            {
                return new DjOperationResult<AllDevelopersViewModel>(false, operationResult.Errors);
            }

            var viewModel = new AllDevelopersViewModel(operationResult.Data);
            var result = new DjOperationResult<AllDevelopersViewModel>(viewModel);
            return result;

        }
    }
}