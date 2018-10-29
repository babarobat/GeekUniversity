using System.Drawing;
using System;

namespace Asteroids
{
    /// <summary>
    /// Базовый класс для обьектов в игре
    /// </summary>
    public abstract class BaseObject
    {
        /// <summary>
        /// Делегат для отображения события в журнале
        /// </summary>
        public  Action<BaseObject, string> Send;
        /// <summary>
        /// Скорость движения. Измеряется в пикселях в секунду.
        /// </summary>
        public float Speed { get; protected set; }
        /// <summary>
        /// Положение обьекта на сцене в координатах X,Y в пикселях
        /// </summary>
        protected PointF _pos;
        /// <summary>
        /// Напрваление движения и скорость обьекта на сцене в координатах X,Y в пикселях.
        /// (В каком месте окажется обьект при следующем Timer_tick)
        /// </summary>
        protected PointF _dir;
        /// <summary>
        /// Размер обьекта на сцене в велечинах Width и Height в пикселях
        /// </summary>
        protected SizeF _size;
        
        /// <summary>
        /// Создает экземпляр класса BaseObject 
        /// </summary>
        /// <param name="pos">Положение обьекта на сцене в координатах X,Y в пикселях</param>
        /// <param name="dir">Напрваление движения обьекта на сцене в координатах X,Y в пикселях</param>
        /// <param name="size">Размер обьекта на сцене в велечинах Width и Height в пикселях</param>
        protected BaseObject(PointF pos, PointF dir, SizeF size)
        {

            _pos = pos;
            _dir = dir;
            _size = size;
        }
        protected BaseObject()
        {
        }
        /// <summary>
        /// Рисует обьект обьект на сцене
        /// </summary>
        public abstract void Draw();
        
        /// <summary>
        /// Обновляет положение обьекта на сцене
        /// </summary>
        public abstract void Update();
        /// <summary>
        /// Сетод отображения информации в журнале
        /// </summary>
        /// <param name="sender">Обьект типа BaseObject </param>
        /// <param name="info">информация о событии</param>
        protected virtual void SendAction(BaseObject sender, string info)
        {
            Send?.Invoke(sender, info);
        }

    }
}
