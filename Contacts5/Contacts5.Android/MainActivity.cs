using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Telephony;
using Android;




namespace Contacts5.Droid
{
    [Activity(Label = "Contacts5", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        readonly string[] PermissionsNeeded =
        {
            Manifest.Permission.ReadPhoneState
        };
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

            TelephonyManager telephonyManager = (TelephonyManager)this.GetSystemService(TelephonyService);
            string phone = "";
            

            if(CheckSelfPermission(Manifest.Permission.ReadPhoneState) != (int)Permission.Granted)
            {
                RequestPermissions(PermissionsNeeded, 0);
            }

            if (CheckSelfPermission(Manifest.Permission.ReadPhoneState) == (int)Permission.Granted)
            {
                phone = telephonyManager.Line1Number;
                
                
                LoadApplication(new App(phone));
            }

        }



        


    }
}