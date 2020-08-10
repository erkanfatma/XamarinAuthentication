using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using XamarinAuthentication.WepAPI.Filters;

namespace XamarinAuthentication.WepAPI.Controllers { 
      public class ValueController : ApiController {
            [JwtAuthentication] 
            public string Get() {
                  return "value";
            }
      }
}
