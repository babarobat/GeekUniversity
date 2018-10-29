using System;
using System.IO;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids
{
    /// <summary>
    /// Логика загрузки и сохранения игровых данных(счета)
    /// </summary>
    public static  class  ScoresManager
    {
        /// <summary>
        /// ссылка на статистику highScores
        /// </summary>
        public static Scores HighScores;
        /// <summary>
        /// Записывает в консоль событие
        /// </summary>
        /// <param name="sender">Виновник события</param>
        /// <param name="actionInfo">описание события</param>
        static ScoresManager()
        {
            HighScores =  LoadScores();
            
        }
        /// <summary>
        /// события для отображения в консоль
        /// </summary>
        /// <param name="sender">виновник события</param>
        /// <param name="actionInfo">информация о событии</param>
        public static void Write(BaseObject sender, string actionInfo)
        {
            Console.WriteLine(DateTime.Now + " - " + sender.GetType() + " " + actionInfo);

        }
        /// <summary>
        /// логика сохраниения счета в текстовый файл
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="actionInfo"></param>
        public static void SaveScores()
        {
            IFormatter formatter = new BinaryFormatter();
            
            var filePath = Path.GetFullPath("Resources/HighScores.txt");
            Stream stream = new FileStream(filePath, FileMode.Create, FileAccess.Write);
            formatter.Serialize(stream, HighScores);
            stream.Close();
        }
        /// <summary>
        /// логика загрузки данных из файла
        /// </summary>
        /// <returns></returns>
        public static Scores LoadScores()
        {
            IFormatter formatter = new BinaryFormatter();
            var filePath = Path.GetFullPath("Resources/HighScores.txt");
            Stream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            return (Scores)formatter.Deserialize(stream);
        }

    }
}
