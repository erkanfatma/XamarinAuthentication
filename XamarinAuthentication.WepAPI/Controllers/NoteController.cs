using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using XamarinAuthentication.Entities.Models;
using XamarinAuthentication.WepAPI.Models.ViewModels;

namespace XamarinAuthentication.WepAPI.Controllers {
      [RoutePrefix("api/notes")]
      public class NoteController : ApiController {
            AuthContext context = new AuthContext();

            [HttpGet, Route("{userId:int}")] 
            public List<NoteViewModel> GetNotes(int userId) {
                  try {
                        return context.Notes.Where(x => x.UserId == userId).Select(y => new NoteViewModel { Description = y.Description, Title =  y.Title }).ToList();
                  } catch(Exception) {
                        throw;
                  }

            }
      }
}
