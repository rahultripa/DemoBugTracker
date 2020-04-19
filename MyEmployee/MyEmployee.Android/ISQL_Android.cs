using System;
using System.Collections.Generic;
using System.IO;
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
using SQLite.Net;
using Xamarin.Forms;

[assembly:Dependency(typeof(ISQL_Android))]
namespace MyEmployee.Droid
{
    public class ISQL_Android : ISQL
    {
        public SQLiteConnection getSQLConnection()
        {
            var fileName = "Employee1.db3";
            var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsPath, fileName);

            //var platform = new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid();

            // var plat = new Xamarin.Forms.Platform.Android. ;// Platform.XamarinAndroid.SQLitePlatformAndroid();
            //  var connection = new SQLiteConnection(
          var platform = new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid();
           // var platform = new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroidN();
            var connection = new SQLiteConnection(platform, path);

            return connection;
        }
    }
}