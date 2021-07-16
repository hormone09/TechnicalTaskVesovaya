using System;
using System.Security.Cryptography;
using System.Text;

namespace MyIdentity
{
    public static class Handler
    {
        public static string GetPasswordHash(string password)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] checkSum = md5.ComputeHash(Encoding.UTF8.GetBytes(password));
            string hash = BitConverter.ToString(checkSum).Replace("-", String.Empty);
            
            return hash;
        }

        public static bool ParamsHandler(string[] mas)
        {
            bool IsCorrect = true;

            foreach (string str in mas)
                if (string.IsNullOrEmpty(str) || string.IsNullOrWhiteSpace(str))
                    IsCorrect = false;

            return IsCorrect;
        }
    }
}
