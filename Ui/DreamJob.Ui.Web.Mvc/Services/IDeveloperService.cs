namespace DreamJob.Ui.Web.Mvc.Services
{
    using System.Collections.Generic;

    using DreamJob.Common.Enum;
    using DreamJob.Ui.Web.Mvc.Controllers;
    using DreamJob.Ui.Web.Mvc.Models.Dto;

    public interface IDeveloperService
    {
        DjOperationResult<List<DeveloperShortInformationDto>> GetAllDevelopersShortInfo();
        DjOperationResult<UserProfileDto> GetDeveloperPublicProfile(string displayName);
        DjOperationResult<UserProfileDto> GetDeveloperPublicProfile(long developerId);
        List<string> GetDeveloperCities(string cityPart);
        List<DeveloperProfileDto> SearchForDevelopers(string technology, string city);
        void UpdateDeveloper(Controllers.SaveDeveloperProfileDto model);
    }
}