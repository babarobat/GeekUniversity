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
    class Department : IEquatable<Department>
    {
        /// <summary>
        /// статический параметр для создания уникального имени
        /// </summary>
        public static int Index { get; private set; }
        ~Department()
        {
            Index--;
        }
        /// <summary>
        /// Имя работника.
        /// Если ввести пустую строку присвоит стандартное имя
        /// </summary>
        public string Name
        {
            get { return Name; }
            set
            {
                if (value != string.Empty)
                {
                    Name = value;
                }
                else
                {
                    Name = "Simple Department Name " + Index;
                }
            }
        }
        /// <summary>
        /// Коллекция сотрудников департамента
        /// </summary>
        public ObservableCollection<Employee> Employees { get; private set; }
        public Department()
        {
            Index++;
            Employees = new ObservableCollection<Employee>();
        }
        /// <summary>
        /// Создает департамент и заполняет его случайными сотрудниками
        /// </summary>
        public Department GetRandomDepartment()
        {
            Department tmpDep = new Department();
            tmpDep.Name = "Simple Department Name " + Index;
            Index++;
            for (int i = 0; i < Util.GetRandom(5, 20); i++)
            {
                Employees.Add(Employee.GetRandomEmployee());
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
    }
}
