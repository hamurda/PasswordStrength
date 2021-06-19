using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace PasswordStrengthWebAPI.Model
{
    public class PasswordBreach
    {
        public string EncryPass { get; set; }
        public int BreachQuantity { get; set; }

    }
}