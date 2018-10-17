using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    /// <summary>
    /// Определяют логику работы с векторами
    /// </summary>
    class Vector
    {
        /// <summary>
        /// X координата вектора
        /// </summary>
        public double X { get; set; }
        /// <summary>
        /// Y координата вектора
        /// </summary>
        public double Y { get; set; }
        /// <summary>
        /// По умолчанию x=y=0
        /// </summary>
        public Vector()
        {
            X = Y = 0;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="x">X координата вектора</param>
        /// <param name="y">Y координата вектора</param>
        public Vector(double x, double y)
        {
            X = x;
            Y = y;
        }
        public static explicit operator Vector(double x)
        {
            return new Vector(x, x);
        }
        public static implicit operator double(Vector x)
        {
            return x.X;
        }
        public override string ToString()
        {
            return $"X={X} Y={Y}";
        }

        public static Vector operator + (Vector v1, Vector v2)
        {
            return  new Vector
            {
                X = v1.X + v2.X,
                Y = v1.Y + v2.Y
            };
            
        }
        public static Vector operator - (Vector v1, Vector v2)
        {
            return new Vector
            {
                X = v1.X - v2.X,
                Y = v1.Y - v2.Y
            };
        }

    }
}
