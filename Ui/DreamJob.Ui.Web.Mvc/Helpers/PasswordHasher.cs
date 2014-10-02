namespace DreamJob.Ui.Web.Mvc.Helpers
{
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;

    public class PasswordHasher : IPasswordHasher
    {
        public string GetHash(string password, string salt)
        {
            var sha = SHA512.Create();
            var hashInput = password + salt;

            var bytesToHash = Encoding.UTF8.GetBytes(hashInput);

            var hashedBytes = sha.ComputeHash(bytesToHash);

            var sb = new StringBuilder(hashedBytes.Length);
            hashedBytes.ToList().ForEach(b => sb.AppendFormat((string)"{0:X}", (object)b));
            return sb.ToString();
        }
    }
}