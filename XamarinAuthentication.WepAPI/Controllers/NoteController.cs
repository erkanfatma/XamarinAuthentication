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
                  return context.Notes.Where(x => x.UserId == userId).Select(d => new NoteViewModel { Description = d.Description, Title = d.Title, NoteId = d.NoteId }).ToList();
            }

            [JwtAuthentication]
            public bool AddNote(NoteViewModel model) {
                  try {
                        int userId = Convert.ToInt32(User.Identity.Name);
                        context.Notes.Add(new Note { UserId = userId, Description = model.Description, Title = model.Title });
                        context.SaveChanges();
                        return true;
                  } catch(Exception) {
                        return false;
                  }
            }

            [HttpGet, Route("get/{noteId}")]
            [JwtAuthentication]
            public NoteViewModel Get(int noteId) {
                  return context.Notes.Where(x => x.NoteId == noteId).Select(x => new NoteViewModel { Description = x.Description, Title = x.Title }).FirstOrDefault();
            }
      }
}
