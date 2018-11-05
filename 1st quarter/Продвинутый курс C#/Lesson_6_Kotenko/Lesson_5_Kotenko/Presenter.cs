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
            _view.Company = _model.Company.Departments;
        }
            
        public void ShowDep(Department dep)
        {
            _view.Department = dep.Employees;
        }
        public void ShowEmp(Employee emp)
        {
            _view.Employee = emp;
        }
        public void ChangeDep(Department newDep, Department oldDep, Employee emp )
        {
            if (newDep!=null && oldDep != null && newDep!=oldDep )
            {
                newDep.AddEmployee(emp);
                oldDep.RemoveEmplyee(emp);
            }            
        }
        public void RemoveEmployee()
        {
            if (_view.Employee!=null&&_view.Department != null)
            {
                _view.Department.Remove(_view.Employee);
            }
        }
        public void AddEmployee()
        {
            if (_view.Department != null)
            {
                var tmpEmp = new Employee() { Name = "New Empployee" };
                _view.Department.Add(tmpEmp);
                _view.Employee = tmpEmp;
            }
        }
        public void AddDep()
        {
                var tmpDep = new Department("New Dep", true);
                _view.Company.Add(tmpDep);
                _view.Department = tmpDep.Employees;   
        }
        public void RemoveDep()
        {
            _view.Company
           
        }

    }
}
