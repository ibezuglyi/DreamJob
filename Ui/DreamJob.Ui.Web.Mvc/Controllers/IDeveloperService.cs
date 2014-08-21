namespace DreamJob.Ui.Web.Mvc.Controllers
{
    using System.Collections.Generic;

    using AutoMapper;

    using DreamJob.Common.Enum;
    using DreamJob.Model.Domain;
    using DreamJob.Ui.Web.Mvc.Repositories;

    public interface IDeveloperService
    {
        DjOperationResult<List<DeveloperShortInformationDto>> GetAllDevelopersShortInfo();
    }

    public class DeveloperService : IDeveloperService
    {
        private readonly IDeveloperRepository repositoryDeveloper;

        public DeveloperService(IDeveloperRepository repositoryDeveloper)
        {
            this.repositoryDeveloper = repositoryDeveloper;
        }

        public DjOperationResult<List<DeveloperShortInformationDto>> GetAllDevelopersShortInfo()
        {
            var allDevelopersOperationResult = this.repositoryDeveloper.All();
            if (allDevelopersOperationResult.IsSuccess == false)
            {
                return new DjOperationResult<List<DeveloperShortInformationDto>>(false, allDevelopersOperationResult.Errors);
            }

            var developersShortInfoList =
                Mapper.Map<List<Developer>, List<DeveloperShortInformationDto>>(allDevelopersOperationResult.Data);

            var result = new DjOperationResult<List<DeveloperShortInformationDto>>(developersShortInfoList);
            return result;
        }
    }
}