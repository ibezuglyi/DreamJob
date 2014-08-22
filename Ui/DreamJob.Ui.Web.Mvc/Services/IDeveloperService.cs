namespace DreamJob.Ui.Web.Mvc.Services
{
    using System.Collections.Generic;

    using DreamJob.Common.Enum;
    using DreamJob.Ui.Web.Mvc.Models.Dto;

    public interface IDeveloperService
    {
        DjOperationResult<List<DeveloperShortInformationDto>> GetAllDevelopersShortInfo();
        DjOperationResult<DeveloperPublicDataDto> GetDeveloperPublicData(long developerId);
    }

    public class DeveloperPublicDataDto
    {
        public long DeveloperId { get; set; }
        public string DisplayName { get; set; }
        public string Title { get; set; }
        public string Profile { get; set; }
        public string ProjectPreferences { get; set; }
        public long MinSalary { get; set; }
        public string City { get; set; }
    }
}