namespace DreamJob.Interfaces
{
    public interface IUserRepository
    {
        void Insert(object userData);
        void Save();

        void Find(object recruiterLoginData);
    }
}