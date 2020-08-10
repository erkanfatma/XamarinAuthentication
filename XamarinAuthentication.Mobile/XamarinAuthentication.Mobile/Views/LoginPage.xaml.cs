using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinAuthentication.Mobile.Models.ViewModels;
using XamarinAuthentication.Mobile.Provider;

namespace XamarinAuthentication.Mobile.Views {
      [XamlCompilation(XamlCompilationOptions.Compile)]
      public partial class LoginPage : ContentPage {
            AccountManager accountManager = new AccountManager();
            public LoginPage() {
                  InitializeComponent();
            }

            private async void LoginButton_Clicked(object sender, EventArgs e) {
                  var result = await accountManager.LoginAsync(new LoginViewModel { Email = EmailEntry.Text, Password = PasswordEntry.Text });
                  TokenLabel.Text = result;
                  Application.Current.Properties["AUTHORIZATIONTOKEN"] = result;
                  await Navigation.PushAsync(new NavigationPage(new NotePage()));
                  

            }
      }
}
 