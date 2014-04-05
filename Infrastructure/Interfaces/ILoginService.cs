namespace DreamJob.Interfaces
{
    public interface ILoginService
    {
        void Login(object recruiterLoginData);
        void Logout();
    }
}