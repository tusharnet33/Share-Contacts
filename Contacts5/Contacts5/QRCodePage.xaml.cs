using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QRCoder;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing;
using ZXing.Net.Mobile.Forms;
using ZXing.QrCode;

namespace Contacts5
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class QRCodePage : ContentPage
	{
		public QRCodePage ()
		{
			InitializeComponent ();
		}

        public QRCodePage(string fullName, string phone)
        {
            InitializeComponent();
            var qrImage = FindByName("codeImage") as ZXingBarcodeImageView;
            qrImage.BarcodeValue = "Name: " + fullName + " Phone: " + phone;
           
        }
    }
}