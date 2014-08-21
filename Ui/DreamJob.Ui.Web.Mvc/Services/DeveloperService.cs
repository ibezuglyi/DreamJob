namespace DreamJob.Ui.Web.Mvc.Services
{
    using System.Collections.Generic;

    using AutoMapper;

    using DreamJob.Common.Enum;
    using DreamJob.Model.Domain;
    using DreamJob.Ui.Web.Mvc.Controllers;
    using DreamJob.Ui.Web.Mvc.Models.Dto;
    using DreamJob.Ui.Web.Mvc.Repositories;

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