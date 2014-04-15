namespace DreamJob.Services.Interfaces
{
    using DreamJob.Services.Interfaces.Model;

    public interface ILoginService
    {
        void Login(UserLoginData userLoginData);
        void Logout();
    }
}