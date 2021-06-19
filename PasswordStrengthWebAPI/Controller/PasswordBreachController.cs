using PasswordStrengthWebAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Web.Http;

namespace PasswordStrengthWebAPI.Controller
{
    
    public class PasswordBreachController : ApiController
    {
        PasswordBreach pwd = new PasswordBreach();

        // GET: api/PasswordBreach
        public HttpResponseMessage Get()
        {
            string message = "Invalid";

            return Request.CreateResponse(HttpStatusCode.OK, message);
        }

        // GET: api/PasswordBreach/5
        public HttpResponseMessage Get(string password)
        {
            PawnAPIHelper.InitializeClient();

            pwd = PawnAPIHelper.GetBreachCount(password).Result;
            string message = pwd.BreachQuantity.ToString();

            return Request.CreateResponse(HttpStatusCode.OK, message);
        }

    }
}
