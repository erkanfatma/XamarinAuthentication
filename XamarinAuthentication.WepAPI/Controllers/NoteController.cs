using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using XamarinAuthentication.Entities.Models;
using XamarinAuthentication.WepAPI.Filters;
using XamarinAuthentication.WepAPI.Models.ViewModels;

namespace XamarinAuthentication.WepAPI.Controllers {
      public class NoteController : ApiController {
            AuthContext context = new AuthContext();
            
            [JwtAuthentication]
            public List<NoteViewModel> GetNotes() {
                  int userId = Convert.ToInt32(User.Identity.Name);
                  return context.Notes.Where(x => x.UserId == userId).Select(d => new NoteViewModel { Description = d.Description, Title = d.Title }).ToList();
            }
      }
}
