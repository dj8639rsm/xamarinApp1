using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
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
    }
    public class BindableBase:INotifyPropertyChanged
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
            if(object.Equals(field, value)) { return false; }

            field = value;
            this.OnPropertyChanged(propertyName);
            return true;
        }
    }

    public class MyPageViewModel:BindableBase
    {
        public ObservableCollection<Person> perple { get; } = new ObservableCollection<Person>();

        public MyPageViewModel()
        {
            var r = new Random();
            Device.StartTimer(
                TimeSpan.FromSeconds(5),
                () =>
                {
                    this.perple.Add(new Person { Name = $"tanaka{ r.Next()} " });
                    return true;
                });
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

