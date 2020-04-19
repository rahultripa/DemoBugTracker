using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MyEmployee.Services;
using MyEmployee.Views;
using MyEmployee.DependencyServices;
using MyEmployee.Models;
using System.Diagnostics;
using Xamarin.Essentials;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MyEmployee
{
    public partial class App : Application
    {

    //public static string steps = "";

    //public static string NetworkSteps = "";
    Stopwatch beginSW = new Stopwatch();
    public  App()
        {
            InitializeComponent();
      
              MainPage =new  NavigationPage( new MyEmployees());
               BugTracker.BugTrackers.Bug();
      
    
       }
        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
