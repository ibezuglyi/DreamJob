﻿namespace DreamJob.Ui.Web.Mvc.Helpers
{
    using System.Security.Cryptography;
    using System.Text;

    public class Md5PasswordHasher : IPasswordHasher
    {
        public string GetHash(string password)
        {
            MD5 md5 = MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(password);
            byte[] hash = md5.ComputeHash(inputBytes);

            var sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }

            return sb.ToString();
        }
    }
}