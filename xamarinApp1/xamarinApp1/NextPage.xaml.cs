using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace xamarinApp1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NextPage : ContentPage
    {
        public NextPage(string paramater)
        {
            InitializeComponent();

            this.label.Text = paramater;
        }

      
        private async void Handle_Cliclked1(object sender, EventArgs e)
        {
            await this.Navigation.PopAsync();
        }
    }
}