using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids
{
    /// <summary>
    /// Статическое расширения для получения случайных значений
    /// </summary>
    public static class Util
    {
        /// <summary>
        /// ссылка на Random
        /// </summary>
        private static Random rnd;

        static Util()
        {
            rnd = new Random();
        }
        /// <summary>
        /// возвращает случайно число в заданном пределе
        /// </summary>
        /// <param name="min">минимальное значение</param>
        /// <param name="max">максимальное значение</param>
        /// <returns></returns>
        public static int GetRandom(int min, int max)
        {
            return rnd.Next(min, max);
        }
    }
    
}
