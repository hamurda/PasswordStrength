using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CAppPasswordStrength
{
    public static class StrengthAPIHelper
    {
        public static HttpClient ClientStrength { get; set; }
        private static string _strengthAPIUrlBase;

        public static string StrengthAPIUrlBase
        {
            get
            {
                _strengthAPIUrlBase = "http://localhost:{yourhostnumber}/api/PasswordCheck/";
                return _strengthAPIUrlBase;
            }
        }

        public static void InitilizeClient()
        {
            ClientStrength = new HttpClient();           
            ClientStrength.DefaultRequestHeaders.Accept.Clear();
            ClientStrength.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        }

        public static async Task<string> GetStrength(string password)
        {
            password.Trim(' ');         
            string APIUrl = StrengthAPIUrlBase + password;
            ClientStrength.BaseAddress = new Uri(APIUrl);

            using (HttpResponseMessage response = await ClientStrength.GetAsync(APIUrl))
            {
                if (response.IsSuccessStatusCode)
                {
                    var strengthInfo = await response.Content.ReadAsAsync<string>();

                    return strengthInfo;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }

}
