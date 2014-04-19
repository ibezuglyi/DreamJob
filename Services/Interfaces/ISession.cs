namespace DreamJob.Services.Interfaces
{
    using DreamJob.Infrastructure.Interfaces;

    public interface ISession
    {
        void SetLoggedUser(UserPublicData userPublicData);
        void Logout();
    }
}
