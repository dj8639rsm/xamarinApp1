using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace xamarinApp1
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]

    public partial class MainPage : ContentPage
    {
        private ObservableCollection<Person> People { get; } = new ObservableCollection<Person>(
            Enumerable.Range(1, 5).Select(x => new Person { Name = $"okazaki{x}" }));

        public MainPage()
        {
            InitializeComponent();

            this.listView.ItemsSource = this.People;
        }
        private void MenuItem1_Clicked(object sender, EventArgs e)
        {
            var selectedItem = ((MenuItem)sender).BindingContext as Person;
            this.DisplayAlert(
                "Info",
                $"{selectedItem.Name}selocted",
                "OK");
        }
        private void MenuItem2_Clicked(object sender, EventArgs e)
        {
            var selectedItem = ((MenuItem)sender).BindingContext as Person;
            this.DisplayAlert(
                "Info",
                $"{selectedItem.Name}selected",
                "OK");
        }
        private void MenuItem3_Clicked(object sender, EventArgs e)
        {
            var selectedItem = ((MenuItem)sender).BindingContext as Person;
            this.DisplayAlert(
                "Info",
                $"{selectedItem.Name}selected",
                "OK");
        }





        public class Person
        {
            public string Name { get; set; }
        }
    }
}

