using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace PasswordStrengthWebAPI.Model
{
    public class Conversion
    {
        public static string ConvertToSHA1(string password)
        {
            //Converts string to SHA1
            using (SHA1 sha1Hash = SHA1.Create())
            {
                //From String to byte array
                byte[] psw = Encoding.UTF8.GetBytes(password);
                byte[] encryPsw = sha1Hash.ComputeHash(psw);
                string hash = BitConverter.ToString(encryPsw).Replace("-", String.Empty);

                return hash;
            }
        }

        public static Dictionary<string, int> ConvertToDictionary(string data)
        {
            // Converts string data come from pwnedAPI to dictionary
            string[] lines = data.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
            Dictionary<string, int> newDict = new Dictionary<string, int>();

            foreach (string line in lines)
            {

                newDict.Add(line.Substring(0, 35), Convert.ToInt32(line.Substring(36)));

            }

            return newDict;
        }
    }
}