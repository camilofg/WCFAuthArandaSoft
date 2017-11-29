using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class PasswordManager
    {

        private String CreateSalt(int size)
        {
            var rng = new RNGCryptoServiceProvider();
            var buff = new byte[size];
            rng.GetBytes(buff);
            return Convert.ToBase64String(buff);

        }

        public String GenerateSHA256Hash(String input, String salt)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(input + salt);
            SHA256Managed sha256HashString = new SHA256Managed();
            byte[] hash = sha256HashString.ComputeHash(bytes);

            return Convert.ToBase64String(hash);
        }


        public List<string> GeneratePassword(String input, int saltSize)
        {
            List<string> saltHash = new List<string>();
            string salt = CreateSalt(saltSize);

            string pass = GenerateSHA256Hash(input, salt);

            saltHash.Add(salt);
            saltHash.Add(pass);
            return saltHash;
        }
    }
}
