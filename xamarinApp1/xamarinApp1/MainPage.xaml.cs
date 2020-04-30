using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Dynamic;
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

        protected virtual bool SetProperty<T>(ref T field, T value, [CallerMemberName]string propertyName = null)
        {
            if(object.Equals(field, value)) { return false; }

            field = value;
            this.OnPropertyChanged(propertyName);
            return true;
        }
    }

    public class MyPageViewModel : BindableBase
    {
        private string message;

        public string Message
        {
            get {return this.message;}
            set { this.SetProperty(ref this.message,value); }

        }

        public Command NowCommand { get; }

        private bool canExcute;

        public bool CanExcute
        {
            get { return this.canExcute; }
            set
            {
                this.SetProperty(ref this.canExcute, value);
                this.NowCommand.ChangeCanExecute();
            }
        }

        public MyPageViewModel()
        {
            this.NowCommand = new Command(
                x => this.Message = DateTime.Now.ToString((string)x),
                _ => this.CanExcute);
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

