using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_5_Kotenko
{
    /// <summary>
    /// Отвечает за логику загрузки и сохранения данных
    /// </summary>
    class Model
    {

        /// <summary>
        /// контейнер данных
        /// </summary>
        public Company Company { get; private set; }
        /// <summary>
        /// сохраннение данных
        /// </summary>
        public void SaveData()
        {

        }
        /// <summary>
        /// загрузка данных
        /// </summary>
        public void LoadData()
        {
            Company = Company.GetRandomCompany();
        }
        
    }
}
