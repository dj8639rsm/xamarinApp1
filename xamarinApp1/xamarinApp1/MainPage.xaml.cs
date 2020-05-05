using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Dynamic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace xamarinApp1
{

    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]

    public class SampleBehavior:Behavior<View>
    {
        protected override void OnAttachedTo(View bindable)
        {
            base.OnAttachedTo(bindable);
        }

        protected override void OnDetachingFrom(View bindable)
        {
            base.OnDetachingFrom(bindable);
        }
    }

    public class NotSelectableListViewBehavior:Behavior<ListView>
    {
        protected override void OnAttachedTo(ListView bindable)
        {
            base.OnAttachedTo(bindable);
            bindable.ItemSelected += this.bindable_ItemSelected;
        }

    }
    public class EventToCommandBehavior:Behavior<VisualElement>
    {
        Delegate eventhandler;

        public static readonly BindableProperty EventNameProperty =
            BindableProperty.Create("EventName", typeof(string), typeof(EventToCommandBehavior), null, propertyChanged: OnEventNameChanged);

        public static readonly BindableProperty CommandProperty =
            BindableProperty.Create("Command", typeof(ICommand), typeof(EventToCommandBehavior), null);

        public static readonly BindableProperty CommandParameterProperty =
            BindableProperty.Create("CommandParameter", typeof(object), typeof(EventToCommandBehavior), null);

        public static readonly BindableProperty InputConverterProperty =
            BindableProperty.Create("Converter", typeof(IValueConverter), typeof(EventToCommandBehavior), null);

        public string Eventname
        {
            get { return (string)GetValue(EventNameProperty); }
            set { SetValue(EventNameProperty, value); }
        }

        public object Commandparameter
        {
            get { return GetValue(CommandParameterProperty); }
            set { SetValue(CommandParameterProperty, value); }
        }

        public IValueConverter Converter
        {
            get { return (IValueConverter)GetValue(InputConverterProperty); }
            set { SetValue(InputConverterProperty, value); }
        }

        protected override void OnAttachedTo(VisualElement bindable)
        {
            base.OnAttachedTo(bindable);
            RegisterEvent(Eventname);
        }

        protected override void OnDetachingFrom(VisualElement bindable)
        {
            DeregisterEvent(Eventname);
            base.OnDetachingFrom(bindable);
        }

        void RegisterEvent(string name)
        {
            if(string.IsNullOrWhiteSpace(name))
            {
                return;
            }

            EventInfo eventInfo = AssociatedObject.Get.type().GetRuntimeEvent(name);
            if (eventInfo == null)
            {
                throw new ArgumentException(string.Format("EventToCommandBehavior:Can't register the '{0}' event", Eventname));
            }
            MethodInfo methodInfo = typeof(EventToCommandBehavior).GetTypeInfo().GetDeclaredMethod("OnEvent");
            eventhandler = methodInfo.CreateDelegate(eventInfo.EventHandlerType, this);
            eventInfo.AddEventHandler(AssociatedObject, eventhandler);
        }

        void DeregisterEvent(string name)
        {
            if(string.IsNullOrWhiteSpace(name))
            {
                return;
            }

            if(eventhandler == null)
            {
                return;
            }
            EventInfo eventInfo = AssociatedObject.GetType().GetRuntimeEvent(name);
            if(eventInfo == null)
            {
                throw new ArgumentException(string.Format("EventToCommanBehavior:Can't de-register the '{0}' event", Eventname));
            }

            eventInfo.RemoveEventHandler(AssociatedObject, eventhandler);
            eventhandler = null;
        }

        void OnEvent(object sender, object eventArgs)
        {
            if(Command == null)
            {
                return;
            }

            object resolveParameter;
            if(Commandparameter != null)
            {
                resolveParameter = Commandparameter;
            }
            else if(Converter != null)
            {
                resolveParameter = Converter.Convert(eventArgs, typeof(object), null, null);
            }
            else
            {
                resolveParameter = eventArgs;
            }

            if(Command.CanExcute(resolveParameter))
            {
                Command.Excute(resolveParameter);
            }

            static void OnEventNameChanged(BindableObject bindable, object oldValue, object newValue)
            {
                var behavior = (EventToCommandBehavior)bindable;
                if(behavior.AssociateObject == null)
                {
                    return;
                }

                string oldEventName = (string)oldValue;
                string newEventName = (string)newValue;

                behavior.DeregisterEvent(oldEventName);
                behavior.RegisterEvent(newEventName);
            }
        }



        

    }







    public class isGreaterZeroConverter:IValueConverter
    {
        public object Converter(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((int)value) > 0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }

    public class NotSelectableListViewTrggerAction:TriggerAction<ListView>
    {
        protected override void Invoke(ListView sender)
        {
            sender.SelectedItem = null;
        }
    }

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
        private int TapCount { get; set; }

        public MainPage()
        {
            InitializeComponent();  
        }
    }
}

