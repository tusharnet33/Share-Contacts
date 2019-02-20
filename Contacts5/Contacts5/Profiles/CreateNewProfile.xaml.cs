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
	public partial class CreateNewProfile : ContentPage
	{
        public string DevicePhoneNumber { get; set; }
		public CreateNewProfile (string phoneNumber)
		{
			InitializeComponent ();
            this.DevicePhoneNumber = phoneNumber;
            var entry = this.FindByName("PhoneNumber") as Entry;
            entry.Text = phoneNumber;
        }

        async void OnSaveButton_Clicked(object sender, EventArgs e)
        {
            var profile = new Profile();
            profile.FirstName = ((Entry)this.FindByName("FirstName")).Text;
            profile.LastName = ((Entry)this.FindByName("LastName")).Text;
            profile.Phone = ((Entry)this.FindByName("PhoneNumber")).Text;
            profile.FullName = profile.FirstName + " " +profile.LastName;
            await App.Database.SaveProfileAsync(profile);
            //await Navigation.PopAsync();
            await Navigation.PushAsync(new AllProfiles(profile.Phone));
        }

        async void OnDeleteButton_Clicked(object sender, EventArgs e)
        {
            
        }
    }
}