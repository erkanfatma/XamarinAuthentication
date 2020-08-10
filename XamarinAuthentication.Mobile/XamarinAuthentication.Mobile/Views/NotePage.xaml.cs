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

            private async void AddNoteButton_Clicked(object sender, EventArgs e) {
                  var result = await noteManager.Add(new NoteViewModel { Description = DescriptionEntry.Text, Title = TitleEntry.Text });
                  if(result)
                        await DisplayAlert("", "Added successfully", "OK");
                  else
                        await DisplayAlert("", "Error occured", "OK");   
            }

            private async void NoteListView_ItemSelected(object sender, SelectedItemChangedEventArgs e) {
                  if(e.SelectedItem == null)
                        return;

                  NoteViewModel selected = (NoteViewModel)e.SelectedItem;
                  var note = await noteManager.Get(selected.NoteId);
                  await DisplayAlert(note.Title, note.Description, "OK");
                  ListView listView = (ListView)sender;
                  listView.SelectedItem = null;
            }
      }
}