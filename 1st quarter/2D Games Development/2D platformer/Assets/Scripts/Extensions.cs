using UnityEngine;

namespace Game
{
    /// <summary>
    /// Содердит вспомогательные статические методы
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Возвращает случайное целое число использая UNity.Random.Range за исключением числа except
        /// </summary>
        /// <param name="min">минимальное число</param>
        /// <param name="max">максимальное число</param>
        /// <param name="except">исключить</param>
        /// <returns></returns>
        public static int GetRandomExcept(int min, int max, int except)
        {
            var r = Random.Range(min, max);
            return r == except? GetRandomExcept( min,  max,  except): r;
        }
    }
}
