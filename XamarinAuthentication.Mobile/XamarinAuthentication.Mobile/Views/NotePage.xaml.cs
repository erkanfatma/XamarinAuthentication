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
      public partial class NotePage : ContentPage {
            NoteManager noteManager = new NoteManager();
            IEnumerable<NoteViewModel> noteList = new List<NoteViewModel>();
            public NotePage(int userId) {
                  InitializeComponent();
                  LoadDataAsync(userId);
            }

            private async void LoadDataAsync(int userId) {
                  noteList = await noteManager.GetAll(userId);
                  NoteListView.ItemsSource = noteList;
            }
      }
}