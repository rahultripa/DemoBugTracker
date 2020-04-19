using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MyEmployee.DependencyServices;
using MyEmployee.Droid;
using Xamarin.Forms;

[assembly: Dependency(typeof(Msg_Android))]
namespace MyEmployee.Droid
{
    public class Msg_Android : IMsg
    {
        public string getMsg()
        {
            return "I m from Android ";
        }
    }
}