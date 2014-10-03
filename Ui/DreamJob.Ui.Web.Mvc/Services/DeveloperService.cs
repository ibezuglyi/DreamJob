using System.Data.Entity.Core.Objects;
using System.Linq;
using DreamJob.Ui.Web.Mvc.Helpers;

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
        private readonly IDateTimeAdapter dateTimeAdapter;

        public DeveloperService(IDeveloperRepository repositoryDeveloper, IDateTimeAdapter dateTimeAdapter)
        {
            this.repositoryDeveloper = repositoryDeveloper;
            this.dateTimeAdapter = dateTimeAdapter;
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

        public DjOperationResult<UserProfileDto> GetDeveloperPublicProfile(string displayName)
        {
            var getByDisplayNameResult = this.repositoryDeveloper.GetByDisplayName(displayName);
            return GetDeveloperPublicProfile(getByDisplayNameResult);
        }

        public DjOperationResult<UserProfileDto> GetDeveloperPublicProfile(long developerId)
        {
            var getByIdResult = this.repositoryDeveloper.GetById(developerId);
            return GetDeveloperPublicProfile(getByIdResult);
        }

        private static DjOperationResult<UserProfileDto> GetDeveloperPublicProfile(DjOperationResult<Developer> getByIdResult)
        {
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
            var skillsToUpdate = GetSkillsToUpdate(profile);
            repositoryDeveloper.RemoveAllSkillsForDeveloper(id);
            var developerResult = repositoryDeveloper.GetById(id);
            var developer = UpdateDeveloperProfile(profile, developerResult.Data, skillsToUpdate);
            
            repositoryDeveloper.UpdateDeveloper(developer);
        }

        private static Developer UpdateDeveloperProfile(UserProfileDto profile, Developer developer,
            List<Skill> skillsToUpdate)
        {
            developer.City = profile.City;
            developer.MinSalary = profile.MinSalary;
            developer.Title = profile.Title;
            developer.Profile = profile.Profile;
            developer.ProjectPreferences = profile.ProjectPreferences;
            developer.Skills = skillsToUpdate;
            return developer;
        }

        private List<Skill> GetSkillsToUpdate(UserProfileDto profile)
        {
            var skillsToUpdate = profile.Skills.Where(r => !string.IsNullOrEmpty(r.Description)).ToList();
            var skills = Mapper.Map<List<Skill>>(skillsToUpdate);
            foreach (var skill in skills)
            {
                skill.Add = dateTimeAdapter.Now;
                skill.Edit = dateTimeAdapter.Now;
            }
            return skills;
        }

        public List<string> GetDeveloperCities(string cityPart)
        {
            var result = repositoryDeveloper.GetDeveloperCities(cityPart);
            return result;
        }

        public List<DeveloperProfileDto> SearchForDevelopers(string technology, string city)
        {
            var developers = repositoryDeveloper.SearchForDevelopers(technology, city);
            return Mapper.Map<List<DeveloperProfileDto>>(developers);
        }
    }
}