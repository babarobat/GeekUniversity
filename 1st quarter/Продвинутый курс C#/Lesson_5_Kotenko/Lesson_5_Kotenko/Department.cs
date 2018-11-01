using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_5_Kotenko
{
    /// <summary>
    /// Содержит параметры и логику департамента
    /// </summary>
    public class Department : IEquatable<Department>
    {
        /// <summary>
        /// статический параметр для создания уникального имени
        /// </summary>
        public static int Index { get; private set; } = 0;
        ~Department()
        {
            Index--;
        }
        /// <summary>
        /// Имя работника.
        /// Если ввести пустую строку присвоит стандартное имя
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// Коллекция сотрудников департамента
        /// </summary>
        public ObservableCollection<Employee> Employees { get; private set; }
        /// <summary>
        /// Конструктор без параметров
        /// </summary>
        public Department()
        {
            Index++;
            Employees = new ObservableCollection<Employee>();
        }
        /// <summary>
        /// Возвращает департамент, заполненный случайными сотрудниками
        /// </summary>
        public static  Department GetRandomDepartment()
        {
            Department tmpDep = new Department();
            tmpDep.Name = "Simple Department Name " + Index;
            
            for (int i = 0; i < Util.GetRandom(5, 20); i++)
            {
                tmpDep.Employees.Add(Employee.GetRandomEmployee());
            }
            return tmpDep;
        }
        /// <summary>
        /// Создает департамент с заданными параметрами
        /// </summary>
        /// <param name="name">Имя</param>
        /// <param name="age">Возраст</param>
        /// <param name="sel">Зарплата</param>
        public Department(string name, ObservableCollection<Employee> employees)
        {
            Name = name;
            Employees = employees;
        }
        /// <summary>
        /// Сравнение двух департаментов на равенство
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(Department other)
        {
            if (other.Name != Name)
            {
                return false;
            }
            else if (other.Employees.Count != Employees.Count)
            {
                return false;
            }
            else
            {
                for (int i = 0; i < other.Employees.Count; i++)
                {
                    if (!other.Employees[i].Equals(Employees[i]))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public void AddEmployee(Employee employee)
        {
            if (employee!=null)
            {
                Employees.Add(employee);
            } 
        }
        public void AddEmployee(string name)
        {
            Employee tmpEmployee = new Employee()
            {
                Name = name
            };
            Employees.Add(tmpEmployee);
        }
        //public override string ToString()
        //{
        //    return Name;
        //}
    }
}
