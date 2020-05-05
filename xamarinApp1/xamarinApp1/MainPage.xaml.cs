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
using Xamarin.Forms;

namespace xamarinApp1
{

    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]


   
    
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            MessagingCenter.Subscribe<NextPage, DateTime>(
                this,
                "completed",
                (sender, args) =>
                {
                    this.labelState.Text = $"Completed at {args}";
                });
        }

        private async void ButtonNextPage_Clicked(object sender, EventArgs e)
        {
            await this.Navigation.PushModalAsync(new NextPage());
        }
    }
}

