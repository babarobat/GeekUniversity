using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_5_Kotenko
{
    public interface IView
    {
        ObservableCollection<Department> Company { get; set; }
        ObservableCollection<Employee> Department { get; set; }
        Employee Employee { get; set; } 
    }
}
