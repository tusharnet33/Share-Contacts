using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QRCoder;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing;
using ZXing.Common;
using ZXing.QrCode;
using System.Drawing;

namespace Contacts5
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddProfile : ContentPage
	{
        public string PhoneNumberProperty { get; set; }
        public string OriginalNumber { get; set; }
		public AddProfile (string phoneNumber)
		{
			InitializeComponent ();
            this.OriginalNumber = phoneNumber;
            this.PhoneNumberProperty = GetQRCodeNumber(phoneNumber);
		}

        private string GetQRCodeNumber(string phoneNumber)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qRCodeData = qrGenerator.CreateQrCode(phoneNumber, QRCodeGenerator.ECCLevel.Q);
            AsciiQRCode qRCode = new AsciiQRCode(qRCodeData);

            return qRCode.GetGraphic(1);
        }

        private void ShowNumber_Clicked(object sender, EventArgs e)
        {
            Label label = FindByName("PhoneNumber") as Label;
            
            label.Text = this.PhoneNumberProperty;
            this.GetQrCodeImage(this.OriginalNumber);
            
            //Navigation.PushAsync(new AddProfile());
        }

        public async void GetQrCodeImage(string qrValue)
        {

            var writer = new BarcodeWriter<Bitmap>
            {
                Format = BarcodeFormat.QR_CODE,
                Options = new QrCodeEncodingOptions
                {
                    Width = 100,
                    Height = 100,
                }
            };

            var qrCodeImage = writer.Write(qrValue); // BOOM!!

            var image =  this.FindByName("QRImage") as Xamarin.Forms.Image;
            //image.Source = result;
            


        }


    }
}