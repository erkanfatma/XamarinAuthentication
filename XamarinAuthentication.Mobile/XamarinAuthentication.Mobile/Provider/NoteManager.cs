using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using XamarinAuthentication.Mobile.Models.ViewModels;

namespace XamarinAuthentication.Mobile.Provider {
      public class NoteManager {
            private string Url = "http://192.168.1.21/XamarinAuthentication.WepAPI/api/notes/";

            HttpClient client = new HttpClient();
            private Task<HttpClient> GetClient() {
                  return Task.Run(() => {
                        client.DefaultRequestHeaders.Add("Accept", "application/json");
                        return client;
                  });
            }

            public async Task<IEnumerable<NoteViewModel>> GetAll(int userId) {
                  client = await GetClient();
                  var json = await client.GetStringAsync($"{Url}/{userId}");
                  return JsonConvert.DeserializeObject<IEnumerable<NoteViewModel>>(json);
            }
      }
}
