using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_5_Kotenko
{
    /// <summary>
    /// Содержит параметры и логику сотрудника
    /// </summary>
    public class Employee :IEquatable<Employee>
    {
        /// <summary>
        /// статический параметр для создания уникального имени
        /// </summary>
        public static int Index { get; private set; }
        ~Employee()
        {
            Index--;
        }
        /// <summary>
        /// Имя работника.
        /// Если ввести пустую строку присвоит стандартное имя
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// Возраст сотрудника. Не может быть меньше 0
        /// </summary>
        public int Age { get; set; }
        
        /// <summary>
        /// Зарплата сотрудника. Не может быть меньше 0
        /// </summary>
        public int Sel { get; set; }
        
        /// <summary>
        /// Конструктор без параметров
        /// </summary>
        public Employee()
        {
            Index++;
        }
        /// <summary>
        /// Возвращает сотрудника с рандомными параметрами
        /// </summary>
        public static Employee GetRandomEmployee()
        {
            return new Employee()
            {
                Name = "Simple Employee Name " + Index,
                Age = Util.GetRandom(20, 50),
                Sel = Util.GetRandom(40, 150) * 1000
            };
        }
        /// <summary>
        /// Создает сотрудника с заданными параметрами
        /// </summary>
        /// <param name="name">Имя</param>
        /// <param name="age">Возраст</param>
        /// <param name="sel">Зарплата</param>
        public Employee(string name, int age, int sel)
        {
            Name = name;
            Age = age;
            Sel = sel;
        }
        /// <summary>
        /// Сравнение двух сотрудников на равенство
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(Employee other)
        {
            return other.Name == Name && 
                   other.Age == Age &&
                   other.Sel == Sel;
        }
    }
}
