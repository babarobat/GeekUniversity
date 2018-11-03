using System.Collections.ObjectModel;

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
        /// Содержит работников, не принадлежащих к какому-либо департаменту.
        /// Поле Deletable этого департамента должно быть false; 
        /// </summary>
        public Department NoDepEmployees;
        
        /// <summary>
        /// Конструктор без параметров.
        /// </summary>
        public Company()
        {
            Departments = new ObservableCollection<Department>();
            NoDepEmployees = new Department("Сотрудники без департамента", false);
            Departments.Add(NoDepEmployees);
        }
        
        /// <summary>
        /// Возвращает случайно сгенерированную компанию.
        /// Для ДЗ
        /// </summary>
        /// <returns></returns>
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
