using MyEmployee.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MyEmployee.Behaviour
{
    public  class ItemSelectedToCommandBehaviour : Behavior<ListView>
    {

        protected override void OnAttachedTo(ListView bindable)
        {

            base.OnAttachedTo(bindable);

            bindable.ItemSelected += Bindable_ItemSelected;
        }

        private void Bindable_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var lv = sender as ListView;
            var emp = e.SelectedItem as Employees;
            var vm = lv.BindingContext as ViewModels.EmployeeViewModel;
            vm.GoToAddEmployeePage.Execute(emp);
        }

        protected override void OnDetachingFrom(ListView bindable)
        {
            base.OnDetachingFrom(bindable);
        }
    }
}
