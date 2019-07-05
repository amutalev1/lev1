using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Seldat.Utils
{
    public static class UtilityMethods
    {
        public static string GetRandomNumericString(int length)
        {
            return GetRandomString(length, "0123456789");
        }

        public static string GetRandomAlfaNumericString(int length)
        {
            return GetRandomString(length, "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789"); 
        }

        public static string GetRandomString(int length, string input)
        {
            if (length <= 0) throw new ArgumentException("Invalid value for parameter.", "length");
            char[] chars = input.ToCharArray();
            RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider();
            byte[] data = new byte[length];
            crypto.GetNonZeroBytes(data);
            StringBuilder result = new StringBuilder(length);
            foreach (byte b in data)
            { result.Append(chars[b % (chars.Length - 1)]); }
            return result.ToString();
        }

        /// <summary>
        /// set C# naming convention to string
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string SetNamingConvention(string value)
        {
            if (value.Trim() != "")
            {
                try
                {

                    int index = 0;
                    var sb = new StringBuilder(value.ToLower().Trim());
                    while (index > -1)
                    {
                        index = sb.ToString().IndexOf("_");
                        if (index != -1)
                        {
                            sb.Remove(index, 1);//remove the "_"
                            sb.Replace(sb.ToString()[index], Char.ToUpper(sb.ToString()[index]), index, 1);//make the '_' followed char to upper
                        }
                    }
                    return Char.ToUpper(sb.ToString()[0]) + sb.ToString().Substring(1);
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            return string.Empty;
        }

        public static bool isValidID(string uid)
        {
            try
            {
                // Validate correct input
                if (!System.Text.RegularExpressions.Regex.IsMatch(uid, @"^\d{5,9}$"))
                    return false;

                // The number is too short - add leading 0000
                if (uid.Length < 9)
                {
                    return false;
                }

                // CHECK THE ID NUMBER
                int mone = 0;
                int incNum;
                for (int i = 0; i < 9; i++)
                {
                    incNum = Convert.ToInt32(uid[i].ToString());
                    incNum *= (i % 2) + 1;
                    if (incNum > 9)
                        incNum -= 9;
                    mone += incNum;
                }
                if (mone % 10 == 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
            
        }

    }

