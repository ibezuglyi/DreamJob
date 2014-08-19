namespace DreamJob.Ui.Web.Mvc.Helpers
{
    public interface IPasswordHasher
    {
        string GetHash(string password);
    }
}