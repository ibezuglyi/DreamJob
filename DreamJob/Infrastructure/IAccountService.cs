namespace DreamJob.Infrastructure
{
    using DreamJob.Dtos;
    using DreamJob.ViewModels;

    public interface IAccountService
    {
        void Logout();

        bool Login(ProfileLoginDto dto);

        void RegisterDeveloper(ProfileRegisterDto dto);

        void RegisterRecruiter(ProfileRegisterDto dto);

        long GetCurrentLoggedUserId();

        ApplicationUserRole GetCurrentLoggedUserRole();

    }
}