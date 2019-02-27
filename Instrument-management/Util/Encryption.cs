using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Instrument_management
{
    public static class Encryption
    {
        public static string MD5Hash(string input)
        {
            using (var md5 = MD5.Create())
            {
                var result = md5.ComputeHash(Encoding.ASCII.GetBytes(input));
                var strResult = BitConverter.ToString(result);
                return strResult.Replace("-", "").ToLower();
            }
        }

        public static string MD5HashWithSalt(string input, string salt)
        {
            if (string.IsNullOrEmpty(salt))
            {
                return MD5Hash(input);
            }
            else
            {
                return MD5Hash(input + salt);
            }
        }
    }
}
