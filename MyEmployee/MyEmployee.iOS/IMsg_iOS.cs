using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using MyEmployee.DependencyServices;
using MyEmployee.iOS;
using UIKit;
using Xamarin.Forms;

[assembly:Dependency(typeof(IMsg_iOS))]
namespace MyEmployee.iOS
{
    public class IMsg_iOS : IMsg
    {
        public string getMsg()
        {
            return "I m from iOS";
        }
    }
}