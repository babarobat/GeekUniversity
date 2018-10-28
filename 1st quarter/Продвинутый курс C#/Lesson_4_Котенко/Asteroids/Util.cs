using System;
using System.IO;
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
        /// <summary>
        /// Возвращает значение, не выходящее за заданные рамки
        /// </summary>
        /// <typeparam name="T">тип</typeparam>
        /// <param name="value">значение</param>
        /// <param name="max">максимальная граница</param>
        /// <param name="min">минимальная граница</param>
        /// <returns></returns>
        public static T Clamp<T>(T value, T max, T min)
            where T : IComparable<T>
        {
            T result = value;
            if (value.CompareTo(max) > 0)
                result = max;
            if (value.CompareTo(min) < 0)
                result = min;
            return result;
            
        }
    }
    
}
