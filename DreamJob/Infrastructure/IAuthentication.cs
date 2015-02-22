namespace DreamJob.Infrastructure
{
    using DreamJob.ViewModels;

    public interface IAuthentication
    {
        void LoginUser(ApplicationUser applicationUser);

        void LogoutUser();

        long GetCurrentLoggedUserId();

        ApplicationUserRole GetCurrentLoggedUserRole();
    }
}