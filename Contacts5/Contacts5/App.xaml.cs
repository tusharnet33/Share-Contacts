using System;
using System.IO;
using Contacts5.Data;
using Contacts5.Profiles;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Contacts5
{
    public partial class App : Application
    {
        static ProfileDatabase database;
        
        public static ProfileDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new ProfileDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Profiles.db3"));
                }
                return database;
            }
        }
        public App()
        {
            this.InitializeComponent();
        }
        public App(string phoneNumber)
        {
            InitializeComponent();

            //MainPage = new MainPage();
            
            MainPage = new NavigationPage(new AllProfiles(phoneNumber));
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

     
    }
}
