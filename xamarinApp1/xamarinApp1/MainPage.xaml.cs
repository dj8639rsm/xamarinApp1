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
        public MainPage()
        {
            InitializeComponent();

            this.image.Source = ImageSource.FromStream(() =>
              {
                //MemorｙStorymなどに画像データを流し込む
                var ms = new MemoryStream();

                //初期位置に戻して返す
                ms.Seek(0, SeekOrigin.Begin);
                  return ms;
              });

        }

   
    }
}

