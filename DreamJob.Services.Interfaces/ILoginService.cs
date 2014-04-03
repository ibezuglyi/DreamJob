namespace DreamJob.Services.Interfaces
{
    public interface ILoginService
    {
        void Login(object recruiterLoginData);
        void Logout();
    }
}