using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Dynamic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;

namespace xamarinApp1
{

    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]

    public interface IplatformNameProvider
    {
        string GetName();
    }
   
    
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();


            //iOSに余白を持たせる
            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    this.Padding = new Thickness(0, 20, 0, 0);
                    break;
            }

            this.labelPlatform.Text = DependencyService
                .Get<IplatformNameProvider>()
                .GetName();

        }



        private void Handle_clicked(object sender, EventArgs e)
        {
            if(Device.RuntimePlatform == Device.iOS)
            {
                Launcher.OpenAsync("http://maps.apple.com/?q=Tokyo");
            }
           
            else if (Device.RuntimePlatform == Device.Android)
            {
                Launcher.OpenAsync("geo:0,0?q=Tokyo");
            }


           
        }
    }
}

