using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace xamarinApp1
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
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
        private string message;
        //ローカル変数の定義

        public string Message
        {
            get { return this.message; }
            set { this.SerProperty(ref this.message, value); }
        }
        
        public Command NowCommand { get; }

        public MyPageViewModel()
        {
            this.NowCommand = new Command(_ => this.Message = DateTime.Now.ToString());
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

