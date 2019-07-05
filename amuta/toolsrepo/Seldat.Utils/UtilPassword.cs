using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Seldat.Utils
{
    public static class UtilPassword
    {
        /// <summary>
        /// the function creates salted password and key(=salt itself) 
        /// </summary>
        /// <param name="password">the login password</param>
        /// <param name="saltPassword">out parameter to retrive the salted password</param>
        /// <param name="key">out parameter to retrive the key(securityStamp)</param>
        /// <param name="saltSize">salt bytes size. default 20 bytes</param>
        public static bool CreateSaltPassword(string password, out string saltPassword, out string key, int saltSize = 50)
        {
            bool success = true;
            try
            {
                using (var deriveBytes = new Rfc2898DeriveBytes(password, saltSize)) // 20-byte salt
                {
                    byte[] salt = deriveBytes.Salt;
                    byte[] randomKey = deriveBytes.GetBytes(saltSize);
                    saltPassword = Convert.ToBase64String(salt);
                    key = Convert.ToBase64String(randomKey);
                }
            }
            catch (Exception ex)
            {
                saltPassword = "";
                key = "";
                success = false;
            }
            return success;
        }

       /// <summary>
       /// the function athunticate password
       /// </summary>
       /// <param name="loginPass">the password from login</param>
       /// <param name="dbPassword">the passwordHash from database</param>
       /// <param name="dbKey">the securityStamp / key from database</param>
       /// <param name="saltSize">salt bytes size. default 20 bytes</param>
       /// <returns></returns>
        public static bool AthunticateSaltPassword(string loginPass, string dbPassword, string dbKey, int saltSize = 50)
        {     
            byte[] salt = Convert.FromBase64String(dbPassword);
            byte[] key = Convert.FromBase64String(dbKey);

            //salt the user's login password
            using (var deriveBytes = new Rfc2898DeriveBytes(loginPass, salt))
            {
                byte[] testKey = deriveBytes.GetBytes(saltSize); // 20-byte key
                return testKey.SequenceEqual(key);
            }
        }
    }
}
