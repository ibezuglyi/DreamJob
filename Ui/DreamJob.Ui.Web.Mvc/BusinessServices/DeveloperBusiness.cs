using DreamJob.Ui.Web.Mvc.Models.Dto;

namespace DreamJob.Ui.Web.Mvc.BusinessServices
{
    using DreamJob.Common.Enum;
    using DreamJob.Ui.Web.Mvc.Controllers;
    using DreamJob.Ui.Web.Mvc.Models;
    using DreamJob.Ui.Web.Mvc.Services;

    public class DeveloperBusiness : IDeveloperBusiness
    {
        private readonly IDeveloperService serviceDeveloper;

        private readonly ISession session;

        public DeveloperBusiness(IDeveloperService serviceDeveloper, ISession session)
        {
            this.serviceDeveloper = serviceDeveloper;
            this.session = session;
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

        public DjOperationResult<DeveloperPublicProfileViewModel> GetDeveloperPublicViewModel(string displayName)
        {
            var getDeveloperPublicDataResult = this.serviceDeveloper.GetDeveloperPublicProfile(displayName);
            if (getDeveloperPublicDataResult.IsSuccess == false)
            {
                return new DjOperationResult<DeveloperPublicProfileViewModel>(false, getDeveloperPublicDataResult.Errors);
            }

            var getCurrentUserResult = this.session.GetCurrentUser();
            if (getCurrentUserResult.IsSuccess == false)
            {
                return new DjOperationResult<DeveloperPublicProfileViewModel>(false, getDeveloperPublicDataResult.Errors);
            }


            var viewModel = new DeveloperPublicProfileViewModel(
                getDeveloperPublicDataResult.Data,
                getCurrentUserResult.Data.AccountType);

            var result = new DjOperationResult<DeveloperPublicProfileViewModel>(viewModel);
            return result;
        }
    }
}