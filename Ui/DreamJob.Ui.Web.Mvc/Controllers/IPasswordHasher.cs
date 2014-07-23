namespace DreamJob.Ui.Web.Mvc.Controllers
{
    using System.Drawing.Imaging;

    using Encoder = System.Text.Encoder;

    public interface IPasswordHasher
    {
        string GetHash(string password);
    }
}