using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_5_Kotenko
{
    class Model
    {
        public Company Company { get; private set; }

        public void SaveData()
        {

        }
        public void LoadData()
        {
            Company = Company.GetRandomCompany();
        }
        
    }
}
