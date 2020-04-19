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
    public partial class AddEmployee : ContentPage
    {
        EmployeeViewModel employeeViewModel;
        public AddEmployee()
        {
            InitializeComponent();
            employeeViewModel = new EmployeeViewModel(Navigation);
            this.BindingContext = employeeViewModel;
            employeeViewModel.EmployeeSelected = new Models.Employees();
      BugTracker.BugTrackers.steps += " Time : " + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss") + "Page Name : AddEmployee\r \n ";

    }
    public AddEmployee(Employees employee)
        {
            InitializeComponent();
            employeeViewModel = new EmployeeViewModel(Navigation);
            this.BindingContext = employeeViewModel;
            employeeViewModel.EmployeeSelected = employee;
      BugTracker.BugTrackers.steps += " Time : " + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss") + "Page Name : AddEmployee\r \n ";
    }
    }
}
