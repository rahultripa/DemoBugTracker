using MyEmployee.Models;
using MyEmployee.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MyEmployee.ViewModels
{
   public class EmployeeViewModel : INotifyPropertyChanged
    {

        INavigation navigation { get; set; }

       public EmployeeViewModel(INavigation _navigation)
        {
            services= new MyEmployee.Services.Services();
            navigation = _navigation;
            getData();

     

     
            BugTracker.BugTrackers.steps += " Time : " + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss") + "ViewModel  : EmployeeViewModel \r \n ";

    }
        MyEmployee.Services.Services services;
        public ICommand AdvanceSearchCommand => new Command<Employees>(AdvanceSearchAsync);
        private async void AdvanceSearchAsync(Employees emp)
        {
        
        }


        public async void getData()
        {
            IsBusy = true;
      BugTracker.BugTrackers.steps += " Time : " + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss") + "Funcation   : getData \r \n ";


      EmployeeList = await services.getEmployee();
            IsBusy = false;

        }

        private Employees employeeSelected;
        public Employees EmployeeSelected
        {
            get
            {;
                return employeeSelected;
            }

            set
            {
                employeeSelected = value;
                OnPropertyChanged();
            }
        }

        private List<Employees> employeeList;
        public List<Employees> EmployeeList
        {
            get
            {
                return employeeList;
            }

            set
            {
                employeeList = value;
                OnPropertyChanged();
            }
        }

        private string statusMassege;
        public string StatusMassege
        {
            get
            {
                return statusMassege;
            }

            set
            {
                statusMassege = value;
                OnPropertyChanged();
            }
        }
        private bool isBusy;
        public bool IsBusy
        {
            get
            {
                return isBusy;
            }

            set
            {
                isBusy = value;
                OnPropertyChanged();
            }
        }

        private Color errorcolor;
        public Color Errorcolor
        {
            get
            {
                return errorcolor;
            }

            set
            {
                errorcolor = value;
                OnPropertyChanged();
            }
        }
        public Command AddEmp
        {
            get
            {
                return new Command(async () =>
                {
                    IsBusy = true;
                  BugTracker.BugTrackers.steps += " Time : " + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss") + "Funcation   : AddEmp \r \n ";

                  MyEmployee.Services.Services services = new MyEmployee.Services.Services();

                    var status = await services.AddEmployee(employeeSelected);
                    if(status!=null)
                    {
                       Errorcolor = Color.Green;
                       StatusMassege = "Data Inserted Successfully ";
                    }
                    else
                    {
                        Errorcolor = Color.Green;
                        StatusMassege = "  Please try again later ";
                    }
                    IsBusy = false;



                });
            }
        }

        public Command GoToNextPage
        {
            get
            {
                return new Command(() =>
                {
                  BugTracker.BugTrackers.steps += " Time : " + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss") + "Funcation   : AddEmployee \r \n ";

                  navigation.PushAsync(new AddEmployee());
                });
            }
        }

        public Command GoToAddEmployeePage
        {
            get
            {
                return new Command<Employees>((emp) =>
                {
                  BugTracker.BugTrackers.steps += " Time : " + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss") + "Funcation   : GoToAddEmployeePage \r \n ";
                  navigation.PushAsync(new AddEmployee(emp));
                });
            }
        }
        public Command UpdateEmp
        {
            get
            {
                return new Command(async () =>
                {
                    IsBusy = true;
                  BugTracker.BugTrackers.steps += " Time : " + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss") + "Funcation   : UpdateEmp \r \n ";
                  var status = await services.UpdateEmployee(employeeSelected);
                    if (status)
                    {
                        Errorcolor = Color.Green;
                        StatusMassege = "Data Update Successfully ";
                    }
                    else
                    {
                        Errorcolor = Color.Green;
                        StatusMassege = "  Please try again later ";
                    }
                    IsBusy = false;



                });
            }
        }

        public Command Refresh
        {
            get
            {
                return new Command(() =>
                {
                    IsBusy = true;
                    getData();
                    IsBusy = false;



                });
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;


        private void OnPropertyChanged([CallerMemberName]string caller = null)
        {
            // make sure only to call this if the value actually changes

            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(caller));
            }
        }
    }
}
