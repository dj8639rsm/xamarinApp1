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
        private ObservableCollection<Family> People { get; }

        public MainPage()
        {
            InitializeComponent();

            this.People = new ObservableCollection<Family>
            {
                new Family("okazakifamily","o")
                {
                    new Person {Name = "okazaki1"},
                    new Person {Name = "okazaki2"},
                    new Person {Name = "okazaki3"},
                    new Person {Name = "okazaki4"},
                },
                new Family("tanakafamily","t")
                {
                    new Person {Name = "tanaka1"},
                    new Person {Name = "tanaka2"},
                    new Person {Name = "tanaka3"},
                    new Person {Name = "tanaka4"},
                },
                new Family("kimurafamily","k")
                {
                    new Person {Name = "kimura1"},
                    new Person {Name = "kimura2"},
                    new Person {Name = "kimura3"},
                    new Person {Name = "kimura4"},
                },
            };

            this.listView.ItemsSource = this.People;
        }
    }

    public class Family:ObservableCollection<Person>
    {
        public string Name { get; set; }
        public string ShortName { get; set; }

        public Family(string name,string shortName)
        {
            this.Name = name;
            this.ShortName = shortName;
        }
    }
        public class Person
        {
            public string Name { get; set; }
        }

    
}

