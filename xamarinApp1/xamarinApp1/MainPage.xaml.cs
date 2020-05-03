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

    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    public class PersonDataTemplateSelector:DataTemplateSelector
    {
        public DataTemplate SilverTempkate { get; set; }
        public DataTemplate NormalTemplate { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
           

            return ((Person)item).Age >= 65 ? this.SilverTempkate : this.NormalTemplate;
        }
    }
    public class BindableBase : INotifyPropertyChanged
    {


        protected BindableBase()
        {

        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected virtual bool SerProperty<T>(ref T field, T value, [CallerMemberName]string propertyName = null)
        {
            if (object.Equals(field, value)) { return false; }

            field = value;
            this.OnPropertyChanged(propertyName);
            return true;
        }
    }

    public class MyPageViewModel : BindableBase
    {

        public ObservableCollection<Person> People { get; } = new ObservableCollection<Person>(
            Enumerable.Range(1, 5).Select(x => new Person { Name = $"okazaki{x}" }));

        public Command command { get; }

        public MyPageViewModel()

        {

        }
    }

    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();

          
        }
       
    }
}

