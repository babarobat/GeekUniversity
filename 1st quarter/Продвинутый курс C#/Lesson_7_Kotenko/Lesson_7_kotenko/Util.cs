using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_7_kotenko
{
    public static class Util
    {
        static Random rnd = new Random();

        public static int GetRandom(int min, int max)
        {
            return rnd.Next(min, max);
        }
    }
}
