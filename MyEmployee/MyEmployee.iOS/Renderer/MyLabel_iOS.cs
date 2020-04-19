using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreGraphics;
using Foundation;
using MyEmployee.CustomeRenderer;
using MyEmployee.iOS.Renderer;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
[assembly: ExportRenderer(typeof(MyLabel), typeof(MyLabel_iOS))]

namespace MyEmployee.iOS.Renderer
{
  public  class MyLabel_iOS : LabelRenderer
    {

        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                Control.BackgroundColor = UIColor.Blue;
            }

        }
    }
}