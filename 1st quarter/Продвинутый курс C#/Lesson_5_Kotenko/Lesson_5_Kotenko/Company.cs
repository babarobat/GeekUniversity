using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_5_Kotenko
{
    /// <summary>
    /// Логика и свойства компании
    /// </summary>
    public class Company
    {
        /// <summary>
        /// Коллекция департаментов
        /// </summary>
        public ObservableCollection<Department> Departments;

        /// <summary>
        /// Коллекция работников, не принадлежащих к какому-либо департаменту
        /// </summary>
        public ObservableCollection<Employee> NoDepEmployees;
        
        /// <summary>
        /// Конструктор без параметров
        /// </summary>
        public Company()
        {
            Departments = new ObservableCollection<Department>();
            NoDepEmployees = new ObservableCollection<Employee>();
        }
        public void RemoveDepartment(Department department)
        {
            foreach (var employee in department.Employees)
            {
                NoDepEmployees.Add(employee);
            }
            Departments.Remove(department);
        }
        public void AddDepartment(string name)
        {
            Department tmpDep = new Department
            {
                Name = name
            };
        }
        public static Company GetRandomCompany()
        {
            Company tmpCompany = new Company();
            var x = Util.GetRandom(5, 20);
            for (int i = 0; i < x; i++)
            {
                tmpCompany.Departments.Add(Department.GetRandomDepartment());
            }
            return tmpCompany;
        }
    }
}
