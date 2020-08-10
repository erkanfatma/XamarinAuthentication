using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using XamarinAuthentication.WepAPI.Filters;

namespace XamarinAuthentication.WepAPI.Controllers {
   //   [RoutePrefix("api/value")]
      public class ValueController : ApiController {
            [JwtAuthentication]
       //     [HttpGet]
            public string Get() {
                  return "value";
            }
      }
}
