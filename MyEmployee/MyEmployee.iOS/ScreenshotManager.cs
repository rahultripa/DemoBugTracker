using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using MyEmployee.DependencyServices;
using MyEmployee.iOS;
using UIKit;
[assembly: Xamarin.Forms.Dependency(typeof(ScreenshotManager))]
namespace MyEmployee.iOS
{
  public class ScreenshotManager : IScreenshotManager
  {
    public async System.Threading.Tasks.Task<byte[]> CaptureAsync()
    {
      try {
      var view = UIApplication.SharedApplication.Delegate.GetWindow().RootViewController.View;

      UIGraphics.BeginImageContext(view.Frame.Size);
      view.DrawViewHierarchy(view.Frame, true);
      var image = UIGraphics.GetImageFromCurrentImageContext();
      UIGraphics.EndImageContext();

        using (var imageData = image.AsPNG())
        {
          var bytes = new byte[imageData.Length];
          System.Runtime.InteropServices.Marshal.Copy(imageData.Bytes, bytes, 0, Convert.ToInt32(imageData.Length));
          return bytes;
        }
        }catch (Exception ex)
      {

        return null;
      }
    

    }
  }
}
