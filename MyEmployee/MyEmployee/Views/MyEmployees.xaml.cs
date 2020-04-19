using MyEmployee.Models;
using MyEmployee.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyEmployee.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyEmployees : ContentPage
    {
     string name;
        EmployeeViewModel employeeViewModel;
        public MyEmployees()
        {
            InitializeComponent();
             //employeeViewModel = new EmployeeViewModelDB(Navigation);

           employeeViewModel = new EmployeeViewModel(Navigation);
            this.BindingContext = employeeViewModel;
            BugTracker.BugTrackers.steps += " Time : " + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss") + "Page Name : MyEmployees\r \n "; 
     

    }

        

    }
}
