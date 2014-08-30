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

        public DjOperationResult<UserProfileDto> GetDeveloperPublicProfile(long developerId)
        {
            var getByIdResult = this.repositoryDeveloper.GetById(developerId);
            if (getByIdResult.IsSuccess == false)
            {
                return new DjOperationResult<UserProfileDto>(false, getByIdResult.Errors);
            }

            var developerPublicProfile = Mapper.Map<Developer, UserProfileDto>(getByIdResult.Data);
            var result = new DjOperationResult<UserProfileDto>(developerPublicProfile);
            return result;
        }

        public void UpdateDeveloper(long id, UserProfileDto profile)
        {
            var developerResult = repositoryDeveloper.GetById(id);
            var developer = developerResult.Data;
            developer.City = profile.City;
            developer.MinSalary = profile.MinSalary;
            developer.Title = profile.Title;
            developer.Profile = profile.Profile;
            developer.ProjectPreferences = profile.ProjectPreferences;
            repositoryDeveloper.UpdateDeveloper(developer);
        }

        public List<string> GetDeveloperCities(string cityPart)
        {
            var result = repositoryDeveloper.GetDeveloperCities(cityPart);
            return result;

        }
    }
}