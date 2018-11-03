using System;
using System.Collections.ObjectModel;

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
        /// <summary>
        /// При уничтожении экземпляра отнимает значение индекса
        /// </summary>
        ~Department()
        {
            Index--;
        }
        /// <summary>
        /// Имя сотрудника.
        /// </summary>
        private string _name;
        /// <summary>
        /// Имя сотрудника. Не может быть пустой строкой
        /// </summary>
        public string Name
        {
            get => _name;
            set
            {
                if (value != string.Empty)
                {
                    _name = value;
                }
            }
        }
        /// <summary>
        /// Можно ли удалить департамент?
        /// </summary>
        public bool Deletable { get; private set; }
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
            Deletable = true;
            
        }
        /// <summary>
        /// Создает департамент с заданным именем и возможностью/невозможностью удаления
        /// </summary>
        /// <param name="name">Имя департамента</param>
        /// <param name="isDeletable"></param>
        public Department(string name, bool isDeletable)
        {
            Index++;
            Employees = new ObservableCollection<Employee>();
            Name = name;
            Deletable = isDeletable;
            
        }

        /// <summary>
        /// Возвращает департамент, заполненный случайными сотрудниками. Для ДЗ
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
       /// <param name="employees">коллекция работников</param>
        public Department(string name, ObservableCollection<Employee> employees)
        {
            Index++;
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
        /// <summary>
        /// Добавляет указанного сотрудника в коллекцию сотрудников данного департамента
        /// </summary>
        /// <param name="employee">сотрудник для добавляения</param>
        public void AddEmployee(Employee employee)
        {
            if (employee!=null)
            {
                Employees.Add(employee);
            } 
        }
        /// <summary>
        /// Создает нового сотрудника с заданным именем и добавляет его в коллекцию сотрудников данного департамента
        /// </summary>
        /// <param name="name"></param>
        public void AddEmployee(string name)
        {
            Employee tmpEmployee = new Employee()
            {
                Name = name
            };
            Employees.Add(tmpEmployee);
        }
       
    }
}
