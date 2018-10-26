using System.Drawing;

namespace Asteroids
{
    /// <summary>
    /// Определяет поведине обьектов при столкновении
    /// </summary>
    public interface ICollision
    {
        /// <summary>
        /// Урон
        /// </summary>
        int Damage { get; }
        /// <summary>
        /// Ссылка на RectangleF обекта
        /// </summary>
        RectangleF Rect { get; }
        /// <summary>
        /// Произошло столкновение обьектов?
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        bool Collision(ICollision obj);
        /// <summary>
        /// Логика нанесеия урона
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="damage"></param>
        void SetDamage(ICollision obj, int damage);
        /// <summary>
        /// Логика получения урона
        /// </summary>
        /// <param name="damage"></param>
        void GetDamage(int damage);
        
    }
}
