
using SQLite.Net;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyEmployee.DependencyServices
{
   public interface ISQL
    {

        SQLiteConnection getSQLConnection();
    }
}
