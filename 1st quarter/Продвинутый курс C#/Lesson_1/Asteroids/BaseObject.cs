using System.Drawing;

namespace Asteroids
{
    /// <summary>
    /// Базовый класс для обьектов в игре
    /// </summary>
    abstract class BaseObject
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
        /// <summary>
        /// Рисует обьект обьект на сцене
        /// </summary>
        public abstract void Draw();
        
        /// <summary>
        /// Обновляет положение обьекта на сцене
        /// </summary>
        public abstract void Update();
        
    }
}
