namespace DreamJob.Ui.Web.Mvc.Services
{
    using System.Collections.Generic;

    using DreamJob.Common.Enum;
    using DreamJob.Ui.Web.Mvc.Models.Dto;

    public interface IDeveloperService
    {
        DjOperationResult<List<DeveloperShortInformationDto>> GetAllDevelopersShortInfo();
        DjOperationResult<UserProfileDto> GetDeveloperPublicProfile(long developerId);
        void UpdateDeveloper(long id, UserProfileDto profile);
    }
}