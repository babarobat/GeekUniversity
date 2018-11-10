using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_7_kotenko
{
    public class Employee
    {
        public string Name { get; set; }
        public string Dep { get; set; }
        public int Age { get; set; }
        public int Sel { get; set; }
        
        
        
        public Employee(string name, string dep, int age, int sel)
        {
            Name = name;
            Dep = dep;
            Age = age;
            Sel = sel;
        }
        
    }
}
