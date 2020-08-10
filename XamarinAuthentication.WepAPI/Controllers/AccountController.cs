using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;
using XamarinAuthentication.Entities.Models;
using XamarinAuthentication.WepAPI.Models.ViewModels;

namespace XamarinAuthentication.WepAPI.Controllers {
      public class AccountController : ApiController {
            [AllowAnonymous]
            public string Login(LoginViewModel model) {
                  using(var context = new AuthContext()) {
                        var user = context.Users.FirstOrDefault(x => x.Email == model.Email && x.Password == model.Password);
                        if(user != null) {
                              return JwtManager.GenerateToken(model.Email);
                        }
                  }
                  throw new HttpResponseException(HttpStatusCode.Unauthorized);
            }
      }
}
