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
        public NextPage()
        {
            InitializeComponent();
        }

        private async void Handle_clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send<NextPage, DateTime>(
                this,
                "completed",
                DateTime.Now);
            await this.Navigation.PopModalAsync();
        }
    }
}