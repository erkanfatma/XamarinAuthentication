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
            public NotePage() {
                  InitializeComponent();
                  LoadDataAsync();
            }

            private async void LoadDataAsync() {
                  noteList = await noteManager.GetAll();
                  NoteListView.ItemsSource = noteList;
            }
      }
}