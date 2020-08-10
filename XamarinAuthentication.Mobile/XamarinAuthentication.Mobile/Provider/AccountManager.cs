using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using XamarinAuthentication.Mobile.Models.ViewModels;

namespace XamarinAuthentication.Mobile.Provider {
      public class AccountManager {
            private string Url = "http://192.168.1.21/XamarinAuthentication.WepAPI/api/account/";

            HttpClient client = new HttpClient();
            private Task<HttpClient> GetClient() {
                  return Task.Run(() => {
                        client.DefaultRequestHeaders.Add("Accept", "application/json");
                        return client;
                  });
            }

            public async Task<string> LoginAsync(LoginViewModel model) {
                  var client = await GetClient();
                  var json = await client.PostAsync(Url + "", new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json"));
                  var result = JsonConvert.DeserializeObject<string>(await json.Content.ReadAsStringAsync());
                  return result;
            }

      }
}
