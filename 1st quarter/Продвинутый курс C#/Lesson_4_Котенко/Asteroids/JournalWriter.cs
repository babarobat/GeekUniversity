using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids
{
    /// <summary>
    /// Логика ведения записей в журнал
    /// </summary>
    public static  class  JournalWriter
    {
        /// <summary>
        /// Записывает в консоль событие
        /// </summary>
        /// <param name="sender">Виновник события</param>
        /// <param name="actionInfo">описание события</param>
        public static void Write(BaseObject sender, string actionInfo)
        {
            Console.WriteLine(DateTime.Now + " - " + sender.GetType() + " " + actionInfo);

        }
        public static void WriteScore(int score)
        {
            var filePath = Path.GetFullPath("Resources/HighScores.txt");
            string newScore = DateTime.Now + " - сбито " + score + " кораблей /n";
            File.AppendAllText(filePath, newScore);
        }
        public static void ReadHighScores()
        {

        }

    }
}
