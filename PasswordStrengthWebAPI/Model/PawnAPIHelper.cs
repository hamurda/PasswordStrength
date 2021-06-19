using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace PasswordStrengthWebAPI.Model
{
    public static class PawnAPIHelper
    {
        private static string _urlBase;

        public static string UrlBase
        {
            get
            {
                _urlBase = "https://api.pwnedpasswords.com/range/";
                return _urlBase;
            }
        }

        public static HttpClient Client { get; set; }

        public static void InitializeClient()
        {
            Client = new HttpClient();
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public static async Task<PasswordBreach> GetBreachCount(string password)
        {
            //Creates a PasswordBreach instance
            PasswordBreach Pwd = new PasswordBreach();
            Pwd.EncryPass = Conversion.ConvertToSHA1(password);
            Pwd.BreachQuantity = 0;  //Initial assumption is that it was never pawned

            string firstFiveChars = Pwd.EncryPass.Substring(0, 5); //For API URL
            string url = UrlBase + firstFiveChars; 
            Client.BaseAddress = new Uri(url);

            using (HttpResponseMessage response = await Client.GetAsync(url).ConfigureAwait(false))
            {
                if (response.IsSuccessStatusCode)
                {
                    var breachInfo = await response.Content.ReadAsStringAsync();

                    Dictionary<string, int> breachPwds = new Dictionary<string, int>();
                    breachPwds = Conversion.ConvertToDictionary(breachInfo);

                    string toCheck = Pwd.EncryPass.ToString().Substring(5);

                    //Checks if the rest of SHA1 exists as a key
                    if (breachPwds.ContainsKey(toCheck))
                    {
                        int pawnedCount = breachPwds[toCheck];
                        Pwd.BreachQuantity = pawnedCount; // updates quantity in case it was pawned before
                    }

                    return Pwd;

                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }

            }
        }
       
    }

}
