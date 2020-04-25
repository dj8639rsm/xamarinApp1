using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace xamarinApp1
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]

    public class Person : BindableObject
    {
        public static readonly BindableProperty NameProperty = BindableProperty.Create(
            "name",
            typeof(string),
            typeof(Person),
            "tanaka",
            propertyChanged:OnNameChanged,
            validateValue:OnNameValidationValue,
            coerceValue:OnNameCoerceValue);

        

        private static object OnNameCoerceValue(BindableObject bindable, object value)
        {
            //値の調整ロジックを記述
            var name = (string)value;
            if(name.Length > 10)
            {
                name = name.Substring(0,10);
            }
            return name;
        }
        private static bool OnNameValidationValue(BindableObject bindable, object value)
        {
            //バリデーションロジックを記述
            var name = (string)value;

            return !string.IsNullOrEmpty(name);
        }

        public static void OnNameChanged(BindableObject bindable,object oldValue, object newValue)
        {
            //変更前と変更後の値を使って何かをする

        }

        public string Name
        {
            get { return (string)this.GetValue(NameProperty);}
            set { this.SetValue(NameProperty, value); }
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

