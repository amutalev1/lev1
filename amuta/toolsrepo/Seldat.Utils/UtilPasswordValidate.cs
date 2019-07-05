using Seldat.SWTools.Configs;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Seldat.Utils
{
  public  class UtilPasswordValidate
    {
        public static string GenerateRandomPassword()
        {
            var PasswordOptionsConfig = ConfigurationManager.GetSection("PasswordOptions") as PasswordOptions;

            if (PasswordOptionsConfig == null)
                PasswordOptionsConfig = new PasswordOptions()
                {
                    RequiredLength = 8,
                    RequiredUniqueChars = 4,
                    RequireDigit = true,
                    RequireLowercase = true,
                    RequireNonAlphanumeric = true,
                    RequireUppercase = true
                };

            string[] randomChars = new[] {
            "ABCDEFGHJKLMNOPQRSTUVWXYZ",    // uppercase 
            "abcdefghijkmnopqrstuvwxyz",    // lowercase
            "0123456789",                   // digits
            "!@$?_-"                        // non-alphanumeric
        };

            Random rand = new Random(Environment.TickCount);
            List<char> chars = new List<char>();

            if (PasswordOptionsConfig.RequireUppercase)
                chars.Insert(rand.Next(0, chars.Count),
                    randomChars[0][rand.Next(0, randomChars[0].Length)]);

            if (PasswordOptionsConfig.RequireLowercase)
                chars.Insert(rand.Next(0, chars.Count),
                    randomChars[1][rand.Next(0, randomChars[1].Length)]);

            if (PasswordOptionsConfig.RequireDigit)
                chars.Insert(rand.Next(0, chars.Count),
                    randomChars[2][rand.Next(0, randomChars[2].Length)]);

            if (PasswordOptionsConfig.RequireNonAlphanumeric)
                chars.Insert(rand.Next(0, chars.Count),
                    randomChars[3][rand.Next(0, randomChars[3].Length)]);

            for (int i = chars.Count; i < PasswordOptionsConfig.RequiredLength
                || chars.Distinct().Count() < PasswordOptionsConfig.RequiredUniqueChars; i++)
            {
                string rcs = randomChars[rand.Next(0, randomChars.Length)];
                chars.Insert(rand.Next(0, chars.Count),
                    rcs[rand.Next(0, rcs.Length)]);
            }

            return new string(chars.ToArray());
        }



        public static string GeneratePassword()
        {
            var PasswordOptionsConfig = ConfigurationManager.GetSection("PasswordOptions") as PasswordOptions;

            if (PasswordOptionsConfig == null)
                PasswordOptionsConfig = new PasswordOptions()
                {
                    RequiredLength = 8,
                    RequiredUniqueChars = 4,
                    RequireDigit = true,
                    RequireLowercase = true,
                    RequireNonAlphanumeric = true,
                    RequireUppercase = true
                };

            string[] randomChars = new[] {
            "ABCDEFGHJKLMNOPQRSTUVWXYZ",    // uppercase 
            "abcdefghijkmnopqrstuvwxyz",    // lowercase
            "@!#$%&"                        // non-alphanumeric
        };

            Random rand = new Random(Environment.TickCount);
            List<string> chars = new List<string>();

            if (PasswordOptionsConfig.RequireUppercase)
                chars.Insert(0,
                    randomChars[0][rand.Next(0, randomChars[0].Length)].ToString());

            if (PasswordOptionsConfig.RequireLowercase)
                chars.Insert(1,
                    randomChars[1][rand.Next(0, randomChars[1].Length)].ToString());

            if (PasswordOptionsConfig.RequireDigit)
            {
                string number = rand.Next(0, 100000).ToString("D5");
                chars.Insert(2, number); 
            }

            if (PasswordOptionsConfig.RequireNonAlphanumeric)
                chars.Insert(3,
                    randomChars[2][rand.Next(0, randomChars[2].Length)].ToString());

            return String.Join(String.Empty, chars); 
        }
    }
}
