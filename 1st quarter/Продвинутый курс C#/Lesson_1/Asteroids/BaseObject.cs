using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Asteroids
{
    /// <summary>
    /// Базовый класс для обьектов в игре
    /// </summary>
    class BaseObject
    {
        /// <summary>
        /// Положение обьекта на сцене в координатах X,Y в пикселях
        /// </summary>
        protected Point _pos;
        /// <summary>
        /// Напрваление движения обьекта на сцене в координатах X,Y в пикселях
        /// </summary>
        protected Point _dir;
        /// <summary>
        /// Размер обьекта на сцене в велечинах Width и Height в пикселях
        /// </summary>
        protected Size _size;
        /// <summary>
        /// Создает экземпляр класса BaseObject 
        /// </summary>
        /// <param name="pos">Положение обьекта на сцене в координатах X,Y в пикселях</param>
        /// <param name="dir">Напрваление движения обьекта на сцене в координатах X,Y в пикселях</param>
        /// <param name="size">Размер обьекта на сцене в велечинах Width и Height в пикселях</param>
        public BaseObject(Point pos, Point dir, Size size)
        {
            _pos = pos;
            _dir = dir;
            _size = size;
        }

        public void Draw()
        {
            GameGraphics.Buffer.Graphics.DrawEllipse(Pens.White, _pos.X, _pos.Y, _size.Width, _size.Height);
        }

        public void Update()
        {
            _pos.X += _dir.X;
            _pos.Y += _dir.Y;

            if (_pos.X < 0) _dir.X = -_dir.X;
            if (_pos.X > GameGraphics.Width) _dir.X = -_dir.X;
            if (_pos.Y < 0) _dir.Y = -_dir.Y;
            if (_pos.Y > GameGraphics.Height) _dir.Y = -_dir.Y;
        }
    }
}
