using System;
using System.Collections.Generic;

namespace Asteroids
{
    /// <summary>
    /// класс для сериализации игровых данных(счета)
    /// </summary>
    [Serializable]
    public class Scores
    {
        /// <summary>
        /// словарь, содержашщий значения даты и счета сооттветственно
        /// </summary>
        public Dictionary<DateTime, int> scores;
        /// <summary>
        /// конструктор по умолчанию
        /// </summary>
        /// <param name="score"></param>
        public Scores(int score)
        {

            scores = new Dictionary<DateTime, int>();
        }

    }
}
