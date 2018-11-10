using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_7_kotenko
{
    public static class DataCreater
    {
        static string[] _names = new string[] { "John", "Joe", "Steve",
                                                "Simon", "Bob", "Jack",
                                                "Jimm", "Fred", "Homer",
                                                "Rick", "Morty", "Tomm",
                                                "Jerry", "Donald", "Barak" };
        static string[] _sNames = new string[] { "Stivenson", "Siemens", "Bork",
                                                "Brown", "Black", "White",
                                                "Armani", "Gooch", "Corner",
                                                "Cooper", "Washington", "Karr", "Bobenson" };
        static string[] _deps = new string[] { "Production", "Marketing", "Law", "Innovation",
                                                "IT", "Finance", };

        public static void CreateData(int empCount,string path,string empTableName,string depTableName)
        {
            
            for (int i = 0; i < empCount; i++)
            {
                var name = _names[Util.GetRandom(0, _names.Length)] + " " + _sNames[Util.GetRandom(0, _sNames.Length)];
                var dep = _deps[Util.GetRandom(0, _deps.Length)];
                var age = Util.GetRandom(18, 55);
                var sel = Util.GetRandom(5, 35) * 100;
                var emp = new Employee(name, dep, age, sel);
                DataManager.SaveEmployee(path, empTableName, emp);
            }
            foreach (var dep in _deps)
            {
                var tmpDep = new Department(dep);
                DataManager.SaveDep(path, depTableName, tmpDep);
            }
        }
    }
}
