using MyEmployee.DependencyServices;
using MyEmployee.Models;
using SQLite.Net;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Linq;

namespace MyEmployee.Services
{
  public  class DBService
    {
        List<Employees> listEmployee { get; set; }


        SQLiteConnection _connection;
     
        public DBService()
        {
            _connection = DependencyService.Get<ISQL>().getSQLConnection();
            _connection.CreateTable<Employees>();
        }

        public List<Employees> getEmployee()
        {

            return (from t in _connection.Table<Employees>()
                    select t).ToList();
        }


        public bool AddEmployee(Employees emp)
        {
            var newEmployees = new Employees
            {
                Name = emp.Name,
                Department = emp.Department
            };

            _connection.Insert(newEmployees);
            return true;
        }
        public bool UpdateEmployee(Employees emp)
        {

            var newEmployees = new Employees
            {
                Id = emp.Id,
                Name = emp.Name,
                Department = emp.Department
            };

            _connection.Update(newEmployees);
            return true;

        }





    }
}
