using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using MyEmployee.DependencyServices;
using MyEmployee.iOS;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(VersionAndBuild_iOS))]
namespace MyEmployee.iOS
{
  public class VersionAndBuild_iOS : IAppVersionAndBuild
  {
    public string GetVersionNumber()
    {
      //var VersionNumber = NSBundle.MainBundle.InfoDictionary.ValueForKey(new NSString("CFBundleShortVersionString")).ToString();   
      return NSBundle.MainBundle.ObjectForInfoDictionary("CFBundleShortVersionString").ToString();
    }
    public string GetBuildNumber()
    {
      //var BuildNumber = NSBundle.MainBundle.InfoDictionary.ValueForKey(new NSString("CFBundleVersion")).ToString();   
      return NSBundle.MainBundle.ObjectForInfoDictionary("CFBundleVersion").ToString();
    }

    public string GetRam()
    {
      throw new NotImplementedException();
    }

    public string GetRom()
    {
      throw new NotImplementedException();
    }
  }
}
