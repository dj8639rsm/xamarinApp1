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

        private async void Handle_Refreshing(object sender, EventArgs e)
        {
            await Task.Delay(3000);
            for(int i=0;i<5;i++)
            {
                this.People.Add(new Person { Name = $"okazaki{this.People.Count + 1}" });
            }

            this.listView.IsRefreshing = false;
        }
    }

    public class Person
    {
        public string Name { get; set; }
    }

}

