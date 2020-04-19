using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MyEmployee.CustomeRenderer
{
   public  class MyLabel : Label 
    {

        public static readonly BindableProperty BackColorProperty =
        BindableProperty.Create("BackColor", typeof(Color), typeof(MyLabel), Color.Blue, BindingMode.TwoWay, null, null);
        public Color BackColor
        {
            get { return (Color)GetValue(BackColorProperty); }
            set { SetValue(BackColorProperty, value); }
        }
    }
}
