using System.IO;
using System;
using System.Drawing;

namespace Asteroids
{
      /// <summary>
      /// Логика и свойства ракеты
      /// </summary>
    class Rocket : BaseObject, ICollision
    {

        /// <summary>
        /// Урон ракеты
        /// </summary>
        public int Damage { get; private set; }
        /// <summary>
        /// Ссылка на коллайдер ракеты
        /// </summary>
        public RectangleF Collider => new RectangleF(_pos, _size);
        /// <summary>
        /// Размер коллайдера ракеты
        /// </summary>
        private SizeF _colliderSize;
        /// <summary>
        /// Позиция коллайдера
        /// </summary>
        private PointF _colliderPos;
        /// <summary>
        /// Направление движения по оси X по умолчанию
        /// </summary>
        private const int _defaultDirectionX = 1;
        /// <summary>
        /// Направление движения по оси Y по умолчанию
        /// </summary>
        private const int _defaultDirectionY = 0;
        /// <summary>
        /// Ссылка на изображение астероида
        /// </summary>
        private Image _rocketImg;
        /// <summary>
        /// Скорость по умолчанию
        /// </summary>
        private const int _startSpeed = 500;
        /// <summary>
        /// Начальный урон ракеты
        /// </summary>
        private const int _startDamage = 1;
        
        /// <summary>
        /// Создает экземпляр ракеты.
        /// по умолчанию направление движения слева направо,
        /// скорость равна _startSpeed,
        /// урон равен _startDamage
        /// </summary>
        /// <param name="fileName"></param>
        public Rocket(string fileName, PointF pos)
        {
            _dir = new PointF(_defaultDirectionX, _defaultDirectionY);
            var rocketImgPath = Path.GetFullPath(fileName);
            _rocketImg = Image.FromFile(rocketImgPath);
            _pos = pos;
            _size = _rocketImg.Size;
            Speed = _startSpeed;
            Damage = _startDamage;
           
            
            SceneObjects.Rockets.Add(this);

        }
        /// <summary>
        /// Рисует обьект
        /// </summary>
        public override void Draw()
        {
            GameGraphics.Buffer.Graphics.DrawImage(_rocketImg,
                                                    _pos.X, _pos.Y,
                                                    _size.Width, _size.Height);
        }
        /// <summary>
        /// Обновение позиции ракеты
        /// </summary>
        public override void Update()
        {
            _pos.X += _dir.X* Speed / GameGraphics.TargetFPS;
            //SetColliderSizeAndPos(0.8f);
            foreach (ICollision asteroid  in SceneObjects.Asteroids)
            {
                if (Collision(asteroid))
                {
                    SceneObjects.Player.CurrentScore++;
                    FormManager.GameForm.SetScore(SceneObjects.Player.CurrentScore.ToString());

                }
            }
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
        
        #region рeалbзация интерфейса ICollision

        /// <summary>
        /// нанести урон
        /// </summary>
        /// <param name="obj">обьект, получающий урон</param>
        /// <param name="damage">колличество урона</param>
        public void SetDamage(ICollision obj, int damage)
        {
            obj.GetDamage(damage);
        }
        /// <summary>
        /// Получить урон
        /// </summary>
        /// <param name="damage">колличество урона</param>
        public void GetDamage(int damage)
        {
            //GameGraphics.Objects.Remove(this);
            //SceneObjects.Rockets.Remove(this);
        }
        /// <summary>
        /// Произошло ли столкновение с обьектом?
        /// </summary>
        /// <param name="obj">обьект</param>
        /// <returns></returns>
        public bool Collision(ICollision obj)
        {
            return obj.Collider.IntersectsWith(this.Collider);
        }
        #endregion
        
    }
}
