using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyEmployee.Models
{


    
  public class Employees
    {
         [PrimaryKey] [AutoIncrement]
        public int Id { get; set; }
        public String Name { get; set; }
        public String Department { get; set; }
    }
}
