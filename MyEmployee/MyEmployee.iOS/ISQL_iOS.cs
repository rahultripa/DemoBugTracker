using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Foundation;
using MyEmployee.DependencyServices;
using MyEmployee.iOS;
using SQLite.Net;
using UIKit;
using Xamarin.Forms;

[assembly:Dependency(typeof(ISQL_iOS))]
namespace MyEmployee.iOS
{
    public class ISQL_iOS : ISQL
    {

        public SQLiteConnection getSQLConnection()
        {
            var fileName = "Employee.db3";
            var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsPath, fileName);

            var platform = new SQLite.Net.Platform.XamarinIOS.SQLitePlatformIOS();

            // var plat = new Xamarin.Forms.Platform.Android. ;// Platform.XamarinAndroid.SQLitePlatformAndroid();
            var connection = new SQLiteConnection(platform, path);

            return connection;
        }
    }
}