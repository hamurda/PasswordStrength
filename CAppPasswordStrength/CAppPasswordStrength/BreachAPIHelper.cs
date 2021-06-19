using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CAppPasswordStrength
{
    public static class BreachAPIHelper
    {
        public static HttpClient ClientBreach { get; set; }
        private static string _breachAPIUrlBase;

        public static string BreachAPIUrlBase
        {
            get
            {
                _breachAPIUrlBase = "http://localhost:{yourhostnumber}/api/PasswordBreach/";
                return _breachAPIUrlBase;
            }
        }

        public static void InitilizeClient()
        {
            ClientBreach = new HttpClient();
            ClientBreach.DefaultRequestHeaders.Accept.Clear();
            ClientBreach.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        }

        public static async Task<string> GetBreachInfo(string password)
        {
            password.Trim(' ');
            string APIUrl = BreachAPIUrlBase + password;
            ClientBreach.BaseAddress = new Uri(APIUrl);

            using (HttpResponseMessage response = await ClientBreach.GetAsync(APIUrl))
            {
                if (response.IsSuccessStatusCode)
                {
                    var breachInfo = await response.Content.ReadAsAsync<string>();

                    return breachInfo;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}
