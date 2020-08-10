using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinAuthentication.Mobile.Models.ViewModels;

namespace XamarinAuthentication.Mobile.Provider {
      public class NoteManager {
            private string Url = "http://192.168.1.21/XamarinAuthentication.WepAPI/api/note/";

            HttpClient client = new HttpClient();
            private Task<HttpClient> GetClient() {
                  return Task.Run(() => {
                        client.DefaultRequestHeaders.Add("Accept", "application/json");
                        client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Application.Current.Properties["AUTHORIZATIONTOKEN"].ToString() );

                        #region ToSendTokenwithHeader
                        //if(client.DefaultRequestHeaders.Contains("Authorization")) {
                        //      client.DefaultRequestHeaders.Remove("Authorization");
                        //}
                        //client.DefaultRequestHeaders.Add("Authorization", $"{Application.Current.Properties["AUTHORIZATIONTOKEN"]}");
                        #endregion
                        return client;
                  });
            }

            public async Task<IEnumerable<NoteViewModel>> GetAll() {
                  client = await GetClient();
                  var json = await client.GetStringAsync($"{Url}");
                  return JsonConvert.DeserializeObject<IEnumerable<NoteViewModel>>(json);
            }
      }
}
 