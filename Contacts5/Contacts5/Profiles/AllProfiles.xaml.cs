using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contacts5.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Contacts5.Profiles
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AllProfiles : ContentPage
	{
        public string PhoneNumber { get; set; }
		public AllProfiles (string phoneNumber)
		{
			InitializeComponent ();
            this.PhoneNumber = phoneNumber;
		}

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            ListView listView = this.FindByName("AllProfilesListView") as Xamarin.Forms.ListView;
            listView.ItemsSource = await App.Database.GetProfilesAsync();
            
        }

        async void DeleteProfile_Clicked(object sender, EventArgs e)
        {
            var mi = ((MenuItem)sender);
            var profile = mi.CommandParameter as Profile;
            await DisplayAlert("Delete Alert", "Remove Profile For " + profile.FullName, "OK");
            await App.Database.DeleteProfileAsync(profile);
            
            await Navigation.PushAsync(new AllProfiles(this.PhoneNumber));
            
        }

        private void AddNewProfile_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CreateNewProfile(this.PhoneNumber));
        }

        private  void ShowQRCode_Tapped(object sender, EventArgs e)
        {
            var textCellInfo = ((TextCell)sender);
            var fullName = textCellInfo.Text;
            var phone = textCellInfo.Detail;
            Navigation.PushAsync(new QRCodePage(fullName,phone), true);
        }

        private void ScanNumber_Clicked(object sender, EventArgs e)
        {

        }
    }
}