using MyEmployee.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MyEmployee.DataTemplateSelector1
{
    public class EmployeeTemplateSelector : DataTemplateSelector
    {
        public DataTemplate ValidTemplate { get; set; }
        public DataTemplate InvalidTemplate { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            return ((Employees)item).Department == "IT" ? ValidTemplate : InvalidTemplate;
        }
    }
}
