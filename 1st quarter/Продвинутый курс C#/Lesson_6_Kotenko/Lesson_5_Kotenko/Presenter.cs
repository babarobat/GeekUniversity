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
    /// <summary>
    /// Связывает логику и отображение
    /// </summary>
    class Presenter
    {
        /// <summary>
        /// ссылка на обьект Model
        /// </summary>
        private Model _model;
        /// <summary>
        /// ссылка на обьект IView
        /// </summary>
        private IView _view;
        /// <summary>
        /// Конструктор, создает новый экземпляр Model
        /// </summary>
        /// <param name="view"></param>
        public Presenter(IView view)
        {
            _view = view;
            _model = new Model();
        }
        private Presenter() { }
        /// <summary>
        /// Загружает данные из Model 
        /// </summary>
        public void LoadCompany()
        {
            _model.LoadData();
            _view.Company = _model.Company.Departments;
        }
        /// <summary>
        /// Отображает сотрудников выбранного департамента
        /// </summary>
        /// <param name="dep"></param>
        public void ShowDep(Department dep)
        {
            if (dep != null)
            {
                _view.Department = dep.Employees;
            }
            
        }
        /// <summary>
        /// отображает параметры выбранного сотрудника
        /// </summary>
        /// <param name="emp"></param>
        public void ShowEmp(Employee emp)
        {
            _view.Employee = emp;
        }
        /// <summary>
        /// изменяет департамент выбранного сотрудника
        /// </summary>
        /// <param name="newDep">новый департамент</param>
        /// <param name="oldDep">текущий департамент</param>
        /// <param name="emp">сотрудник</param>
        public void ChangeDep(Department newDep, Department oldDep, Employee emp )
        {
            if (newDep!=null && oldDep != null && newDep!=oldDep )
            {
                newDep.AddEmployee(emp);
                oldDep.RemoveEmplyee(emp);
            }            
        }
        /// <summary>
        /// удаляет сотрудника из выбранного департамента
        /// </summary>
        public void RemoveEmployee()
        {
            if (_view.Employee!=null&&_view.Department != null)
            {
                _view.Department.Remove(_view.Employee);
            }
        }
        /// <summary>
        /// добавляет сотрудника в выбранный департамент
        /// </summary>
        public void AddEmployee()
        {
            if (_view.Department != null)
            {
                var tmpEmp = new Employee() { Name = "New Empployee" };
                _view.Department.Add(tmpEmp);
                _view.Employee = tmpEmp;
            }
        }
        /// <summary>
        /// добавляет новый департамент
        /// </summary>
        public void AddDep()
        {
                var tmpDep = new Department("New Dep", true);
                _view.Company.Add(tmpDep);
                _view.Department = tmpDep.Employees;   
        }
        /// <summary>
        /// удаляет выбраный департамент, если у него есть возможность удаления
        /// </summary>
        /// <param name="dep"></param>
        public void RemoveDep(Department dep)
        {
            if (dep != null && dep.Deletable)
            {
                foreach (var emp in dep.Employees)
                {
                    _model.Company.NoDepEmployees.AddEmployee(emp);
                }
                _view.Company.Remove(dep);
                _view.Department = _view.Company[0].Employees;
            }
        }
        /// <summary>
        /// изменяет имя департамента
        /// </summary>
        /// <param name="dep"></param>
        /// <param name="name"></param>
        public void ChangeDepName(Department dep, string name)
        {
            _model.Company.Departments[_view.Company.IndexOf(dep)].Name = name;
            _view.Company = _model.Company.Departments;


        }

    }
}
