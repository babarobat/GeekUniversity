using System;
using System.IO;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids
{
    /// <summary>
    /// Определяет логику и параметры аптечки
    /// </summary>
    class HealthPack : BaseObject, ICollision
    {
        /// <summary>
        /// Колличество хп,востстанавливаемого аптечкой
        /// </summary>
        public int Damage { get; private set; } = -1;
        /// <summary>
        /// Здоровье аптечки
        /// </summary>
        public int Health { get; private set; } = 1;
        /// <summary>
        /// Ссылка на коллайдер 
        /// </summary>
        public RectangleF Collider => new RectangleF(_pos, _size);
        /// <summary>
        /// Размер коллайдера
        /// </summary>
        private SizeF _colliderSize;
        /// <summary>
        /// Позиция коллайдера
        /// </summary>
        private PointF _colliderPos;
        /// <summary>
        /// Направление движения по умолчанию по оси X
        /// </summary>
        private const int _defaultDirectionX = -1;
        /// <summary>
        /// Направление движения по умолчанию по оси Y
        /// </summary>
        private const int _defaultDirectionY = 0;
        /// <summary>
        /// Ссылка на изображение
        /// </summary>
        private Image _healthPackImg;

        /// <summary>
        /// Публичный конструктор атечки
        /// </summary>
        /// <param name="fileName"></param>
        public HealthPack(string fileName)
        {
            _dir = new PointF(_defaultDirectionX, _defaultDirectionY);
            var healthImgPath = Path.GetFullPath(fileName);
            _healthPackImg = Image.FromFile(healthImgPath);
            _size = _healthPackImg.Size;
            //SetColliderSizeAndPos(1);
            GoToSpawnPoint();
            SceneObjects.HealthPacks.Add(this);

        }
        /// <summary>
        /// Отрисовка кадра
        /// </summary>
        public override void Draw()
        {
            GameGraphics.Buffer.Graphics.DrawImage(_healthPackImg,
                                                     _pos.X, _pos.Y,
                                                     _size.Width, _size.Height);
        }
        /// <summary>
        /// Обновление кадра
        /// </summary>
        public override void Update()
        {
            _pos.X += _dir.X * Speed / GameGraphics.TargetFPS;
            

        }
        #region Реализация интерфейса ICollision
        public void GetDamage(int damage)
        {
            Health -= damage;
            if (Health <= 0)
            {
                GoToSpawnPoint();
            }
        }
        /// <summary>
        /// Логика нанесения урона
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="damage"></param>
        public void SetDamage(ICollision obj, int damage)
        {
            
        }
        /// <summary>
        /// Произошло столкновение с обьектом obj?
        /// </summary>
        /// <param name="obj">обьект столкновения</param>
        /// <returns></returns>
        public bool Collision(ICollision obj)
        {
            return obj.Collider.IntersectsWith(this.Collider);
        }
        #endregion
        #region Приватные методы
        /// <summary>
        /// Переносит аптечку в новую стартовую точку
        /// </summary>
        private void GoToSpawnPoint()
        {
            _pos = GetRandomPos(GameGraphics.Width, GameGraphics.Width * 4, 0, GameGraphics.Height);
            Speed = Util.GetRandom(200, 400);
        }
        /// <summary>
        /// ворзвращает случайную точку для спауна
        /// </summary>
        /// <param name="minRndX"></param>
        /// <param name="maxRndX"></param>
        /// <param name="minRndY"></param>
        /// <param name="maxRndY"></param>
        /// <returns></returns>
        private Point GetRandomPos(int minRndX, int maxRndX, int minRndY, int maxRndY)
        {
            var rndPosX = Util.GetRandom(minRndX, maxRndX);
            var rndPosY = Util.GetRandom(minRndY, maxRndY);
            return new Point(rndPosX, rndPosY);
        }
        /// <summary>
        /// Определяет размер и позицию коллайдера относительно исходного размера изображения обьекта
        /// </summary>
        /// <param name="sizeMultiplier">коээфициент, на который умножается размер изображения</param>
        private void SetColliderSizeAndPos(float sizeMultiplier)
        {
            _colliderSize.Width = _size.Width * sizeMultiplier;
            _colliderSize.Height = _size.Height * sizeMultiplier;
            _colliderPos.X = _pos.X + (_size.Width - _colliderSize.Width) / 2;
            _colliderPos.Y = _pos.Y + (_size.Height - _colliderSize.Width) / 2;

        }
        
        #endregion

    }
}
