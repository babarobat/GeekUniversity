using System.Collections.ObjectModel;

namespace Lesson_5_Kotenko
{
    /// <summary>
    /// Отвечает за отображаемые поля
    /// </summary>
    public interface IView
    {
        /// <summary>
        /// Список департаментов
        /// </summary>
        ObservableCollection<Department> Company { get; set; }
        /// <summary>
        /// выбранныей департамент со списком сотрудников
        /// </summary>
        ObservableCollection<Employee> Department { get; set; }
        /// <summary>
        /// выбранныей сотрудник
        /// </summary>
        Employee Employee { get; set; } 
    }
}
