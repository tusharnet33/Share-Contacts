using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contacts5.Profiles;
using Xamarin.Forms;

namespace Contacts5
{
    public partial class MainPage : ContentPage
    {
        public string phoneNumber { get; set; }
        public MainPage(string phoneNumber)
        {
            InitializeComponent();
            this.phoneNumber = phoneNumber;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            
        }
        private void Navigate_Clicked(object sender, EventArgs e)
        {
            //Label label = FindByName("changeme") as Label;
            //label.Text = "Oh Yeh! It works!";

            //Navigation.PushAsync(new AddProfile(this.phoneNumber));
            //Navigation.PushAsync(new CreateNewProfile(this.phoneNumber));

        }
    }
}
