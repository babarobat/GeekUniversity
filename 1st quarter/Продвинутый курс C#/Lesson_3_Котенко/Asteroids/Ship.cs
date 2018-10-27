using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids
{
    /// <summary>
    /// Логика и параметры космического корабля, которым управляет игрок
    /// </summary>
    public class Ship : BaseObject, ICollision
    {
        /// <summary>
        /// Урон, который наносит игрок при столкновении с обьектами.
        /// Установлено большое значение для того что бы уничтожать аптечки и астероиды
        /// </summary>
        public int Damage => 100;
        /// <summary>
        /// Стартовое здоровье
        /// </summary>
        public int StartHealth = 10;
        /// <summary>
        /// Стартовый урон
        /// </summary>
        public int StartScore = 0;
        /// <summary>
        /// Текущее здоровье
        /// </summary>
        public int CurrentHealth { get;  set; }
        /// <summary>
        /// Текущий урон
        /// </summary>
        public int CurrentScore { get; set; }

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
        /// Ссылка на изображение корабля
        /// </summary>
        private Image _shipImg;
        /// <summary>
        /// Можно стрелять?
        /// </summary>
        private bool _canFire = true;
        /// <summary>
        /// Публичный конструктор.
        /// Устанавливет начальные параметры на старте игры.
        /// Прошу прощение за хардкод
        /// </summary>
        /// <param name="fileName"></param>
        public Ship(string fileName)
        {
            Send += JournalWriter.Write;
            Speed = 500;
            CurrentHealth = StartHealth;
            CurrentScore = StartScore;
            _pos = new PointF(100, 360);
            var shipImgPath = Path.GetFullPath(fileName);
            _shipImg = Image.FromFile(shipImgPath);
            _size = _shipImg.Size;
            
            
            SceneObjects.Player = this;
        }
        /// <summary>
        /// Отрисовка кадра
        /// </summary>
        public override void Draw()
        {
            GameGraphics.Buffer.Graphics.DrawImage(_shipImg,
                                                    _pos.X, _pos.Y,
                                                    _size.Width, _size.Height);
        }
        /// <summary>
        /// Логика управления.
        /// Получет данные во время срабатывания события keyDown на игровой форме нажатии на кнопки управления 
        /// </summary>
        /// <param name="e"></param>
        public void Move(KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Up)
            {
                _dir.Y = -1;
            }
            if (e.KeyCode == Keys.Down)
            {
                _dir.Y = 1;
            }
            if (e.KeyCode == Keys.ControlKey)
            {
                Fire();
                SendAction(this, "fire Rocket");
            }
        }
        /// <summary>
        /// останавливает управление игроком.
        /// Срабатывает при событии KeyUp игровой формы
        /// </summary>
        /// <param name="e"></param>
        public void StopMove(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                _dir.Y = 0;
            }

            if (e.KeyCode == Keys.ControlKey)
            {
                _canFire = true;
            }

        }
        /// <summary>
        /// Обновление кадра
        /// </summary>
        public override void Update()
        {
            _pos.Y += Speed * _dir.Y / GameGraphics.TargetFPS;
            //SetColliderSizeAndPos(0.8f);
            foreach (ICollision item in SceneObjects.Asteroids)
            {
                if (Collision(item))
                {
                    SendAction(this, "collide whith Asteroid");
                }
            }
            foreach (ICollision item in SceneObjects.HealthPacks)
            {
                if (Collision(item))
                {
                    SendAction(this, "take HealthPack");
                    this.GetDamage(item.Damage);
                    item.GetDamage(Damage);
                }
            }
        }
        #region Реализация интерфейса ICollision
        /// <summary>
        /// Произошло столкновение?
        /// </summary>
        /// <param name="obj">Обьект с которым проверяется наличие столкновения</param>
        /// <returns></returns>
        public bool Collision(ICollision obj)
        {
            return obj.Collider.IntersectsWith(this.Collider);
        }
        /// <summary>
        /// получить урон
        /// </summary>
        /// <param name="damage"></param>
        public void GetDamage(int damage)
        {
            CurrentHealth -= damage;
            if (CurrentHealth <= 0)
            {
                CurrentHealth = StartHealth;
                _pos.X = 10;
                _pos.Y = 10;
            }
            FormManager.GameForm.SetHealth(CurrentHealth.ToString());
        }
        /// <summary>
        /// Нанести урон
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="damage"></param>
        public void SetDamage(ICollision obj, int damage)
        {
            obj.GetDamage(damage);
        }

        #endregion
        #region Приватные методы
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
        
        /// <summary>
        /// Логика стрельбы
        /// </summary>
        private void Fire()
        {
            if (_canFire)
            {
                var tmpRocket = new Rocket(ResourcesLoader.GetImage(TypeOf.rocket)[0], GetFirePosition());
                GameGraphics.Objects.Add(tmpRocket);
            }
        }
        /// <summary>
        /// возращает позицию для появления ракеты
        /// </summary>
        /// <returns></returns>
        private PointF GetFirePosition()
        {
            return new PointF(_pos.X + _size.Width / 2, _pos.Y + _size.Height / 2 - 10);
        }
        #endregion
        
        
    }
}
