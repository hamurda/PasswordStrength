using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Web.Http;
using PasswordStrengthWebAPI.Model;

namespace PasswordStrengthWebAPI.Controller
{
    public class PasswordCheckController : ApiController
    {
        PasswordCheck psw = new PasswordCheck();

        // GET: api/PasswordCheck
        public HttpResponseMessage Get()
        {
            PasswordStrenght strength = PasswordStrenght.Blank;
            string message = $"{strength.ToString()}";

            return Request.CreateResponse(HttpStatusCode.OK, message);
        }

        // GET: api/PasswordCheck/password
        public HttpResponseMessage Get(string password)
        {
            PasswordStrenght strength = psw.CheckStrength(password);
            string message = $"{strength.ToString()}";

            return Request.CreateResponse(HttpStatusCode.OK, message);
        }
    }
}
