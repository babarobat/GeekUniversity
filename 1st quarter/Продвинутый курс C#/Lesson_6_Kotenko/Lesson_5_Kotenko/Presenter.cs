using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Lesson_5_Kotenko
{
    class Presenter
    {
        private Model _model;
        private IView _view;

        public Presenter(IView view)
        {
            _view = view;
            _model = new Model();
        }
        public void LoadCompany()
        {
            _model.LoadData();
            _view.Departments = _model.Company.Departments;
        }
        public ObservableCollection <Department> GetDepartments()
        {
            return _view.Departments;
        }
        public ObservableCollection<Employee> GetEmplyees()
        {
            return _view.Employees;
        }
        public void ShowDep(ListBox s, ObservableCollection<Employee> employees)
        {
            s.ItemsSource = employees;
        }
    }
}
