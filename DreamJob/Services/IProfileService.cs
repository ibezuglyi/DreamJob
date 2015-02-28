namespace DreamJob.Services
{
    using DreamJob.Dtos;
    using DreamJob.ViewModels;

    public interface IProfileService
    {
        void RegisterDeveloper(ProfileRegisterDto dto);

        ProfilePublicViewModel GetPublicDataForUserId(long id);
        ProfilePublicViewModel GetPublicDataForLoggedUser();
        ProfilePrivateViewModel GetPrivateDataForLoggedUser();

        void UpdateDeveloperProfile(ProfilePrivateDeveloperEditDto dto);
        void UpdateRecruiterProfile(ProfilePrivateRecruiterDto dto);

        void RemoveSkillFromProfile(long skillId);

        HomeIndexViewModel GetDevelopersHeadlines();

        SearchResultViewModel GetDevelopersHeadlinesWithSkill(SearchSkillDto dto);
        SearchResultViewModel GetDevelopersHeadlinesWithSalaryInRange(SearchSalaryDto dto);
    }
}