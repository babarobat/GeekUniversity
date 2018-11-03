using System;

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
        /// Имя сотрудника
        /// </summary>
        private string _name;
        /// <summary>
        /// Возраст сотрудника
        /// </summary>
        private int _age;
        /// <summary>
        /// Зарплата сотрудника
        /// </summary>
        private int _sel;
        /// <summary>
        /// Имя сотрудника
        /// Не может быть пустой строкой
        /// </summary>
        public string Name
        {
            get => _name;
            set
            {
                if (value!=string.Empty)
                {
                    _name = value;
                } 
            }
            
        }        
        /// <summary>
        /// Возраст сотрудника. Не может быть меньше 0
        /// </summary>
        public int Age
        {
            get => _age;
            set
            {                
                if ( value >0)
                {
                    _age = value;
                }
            }
        }

        /// <summary>
        /// Зарплата сотрудника. Не может быть меньше 0
        /// </summary>
        public int Sel
        {
            get => _sel;
            set
            {
                if (value > 0)
                {
                    _sel = value;
                }
            }
        }
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
