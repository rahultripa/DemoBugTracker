using MyEmployee.Models;
using MyEmployee.Services;
using MyEmployee.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;


namespace MyEmployee.ViewModels
{
   


    public class EmployeeViewModelDB : INotifyPropertyChanged
    {

        INavigation navigation { get; set; }

        public EmployeeViewModelDB(INavigation _navigation)
        {
            services = new DBService();
            navigation = _navigation;
            getData();

        }
          DBService services;


        public  void getData()
        {
            IsBusy = true;

            EmployeeList = services.getEmployee();
            IsBusy = false;

        }

        private Employees employeeSelected;
        public Employees EmployeeSelected
        {
            get
            {
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

                    MyEmployee.Services.Services services = new MyEmployee.Services.Services();

                    //var status = await services.AddEmployee(employeeSelected);
                    //if (status)
                    //{
                    //    Errorcolor = Color.Green;
                    //    StatusMassege = "Data Inserted Successfully ";
                    //}
                    //else
                    //{
                    //    Errorcolor = Color.Green;
                    //    StatusMassege = "  Please try again later ";
                    //}
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
                    navigation.PushAsync(new AddEmployee(emp));
                });
            }
        }
        public Command UpdateEmp
        {
            get
            {
                return new Command( () =>
                {
                    IsBusy = true;

                    var status =  services.UpdateEmployee(employeeSelected);
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
