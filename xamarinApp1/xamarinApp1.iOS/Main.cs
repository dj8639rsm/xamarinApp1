using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ResolutionGroupName("xamarinApp1")]
[assembly: ExportEffect(typeof(xamarinApp1.iOS.UnderlineEffectt), "UnderlineEffect")]

namespace xamarinApp1.iOS
{
    public class UnderlineEffectt : PlatformEffect
    {
        protected override void OnAttached()
        {
            var label = this.Control as UILabel;
            if(label == null) { return; }

            label.AttributedText = new Foundation.NSAttributedString(
                label.Text?? "",
                underlineStyle: Foundation.NSUnderlineStyle.Single);
        }

        protected override void OnDetached()
        {
            
        }

        protected override void OnElementPropertyChanged(PropertyChangedEventArgs args)
        {
            

            if (args.PropertyName == nameof(UILabel.Text))
            {
                var label = this.Control as UILabel;
                if (label == null) { return; }

                label.AttributedText = new Foundation.NSAttributedString(
                    label.Text?? "",
                    underlineStyle: Foundation.NSUnderlineStyle.Single);
            }
        }
    }

    public class Application
    {
        // This is the main entry point of the application.
        static void Main(string[] args)
        {
            // if you want to use a different Application Delegate class from "AppDelegate"
            // you can specify it here.
            UIApplication.Main(args, null, "AppDelegate");
        }
    }
}
