namespace DreamJob.Services
{
    using Dtos;
    using ViewModels;

    public interface IProfileService
    {
        ProfilePublicViewModel GetPublicProfileForUserId(long id);
        ProfilePublicViewModel GetPublicProfileForLoggedUser();
        ProfilePrivateViewModel GetPrivateProfileForLoggedUser();

        void UpdateDeveloperProfile(ProfilePrivateDeveloperEditDto dto);
        void UpdateRecruiterProfile(ProfilePrivateRecruiterDto dto);

        void RemoveSkillFromProfile(long skillId);

        HomeIndexViewModel GetDevelopersHeadlines();

        SearchResultViewModel GetDevelopersHeadlinesWithSkill(SearchSkillDto dto);
        SearchResultViewModel GetDevelopersHeadlinesWithSalaryInRange(SearchSalaryDto dto);
    }
}