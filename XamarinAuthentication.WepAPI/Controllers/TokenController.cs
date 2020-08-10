using Microsoft.IdentityModel.JsonWebTokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using XamarinAuthentication.Entities.Models;

namespace XamarinAuthentication.WepAPI.Controllers {
     // [RoutePrefix("api/token")]
      public class TokenController : ApiController {
            [AllowAnonymous] 
            public string Get(string email, string password) {
                  if(CheckUser(email, password)) {
                        return JwtManager.GenerateToken(email);
                  }
                  throw new HttpResponseException(HttpStatusCode.Unauthorized);
            }

            public bool CheckUser(string email, string password) {
                  //check user in the database
                  using(var context = new AuthContext()) {
                        var user = context.Users.FirstOrDefault(c => c.Email == email && c.Password == password);
                        if(user != null) {
                              return true;
                        }
                        return false;
                  }
            }
      }
}
