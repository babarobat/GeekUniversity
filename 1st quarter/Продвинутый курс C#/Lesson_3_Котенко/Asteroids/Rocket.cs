using System.IO;
using System.Drawing;

namespace Asteroids
{
    class Rocket : BaseObject, ICollision
    {

        /// <summary>
        /// Урон ракеты
        /// </summary>
        public int Damage { get; private set; }
        /// <summary>
        /// Ссылка на RectangleF ракеты
        /// </summary>
        public RectangleF Rect => new RectangleF(_pos, _size);

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
        private const int _startDamage = 1;
        /// <summary>
        /// Создает экземпляр ракеты.
        /// по умолчанию направление движения слева направо,
        /// скорость равна _startSpeed,
        /// урон равен _startDamage
        /// </summary>
        /// <param name="fileName"></param>
        public Rocket(string fileName)
        {
            _dir = new PointF(_defaultDirectionX, _defaultDirectionY);
            var rocketImgPath = Path.GetFullPath(fileName);
            _rocketImg = Image.FromFile(rocketImgPath);
            
            _size = _rocketImg.Size;
            Speed = _startSpeed;
            Damage = _startDamage;
            GoToStartPos();
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
            
            if (_pos.X>GameGraphics.Width)
            {
                GoToStartPos();                
            }
        }
        /// <summary>
        /// Возвращает ракету в стартовую точку. ДЗ
        /// </summary>
        public void GoToStartPos()
        {
            _pos.X = 50;
            _pos.Y = 350;
        }
        #region ркаллтзация интерфейса ICollision

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
            GoToStartPos();
        }
        /// <summary>
        /// Произошло ли столкновение с обьектом?
        /// </summary>
        /// <param name="obj">обьект</param>
        /// <returns></returns>
        public bool Collision(ICollision obj)
        {
            return obj.Rect.IntersectsWith(this.Rect);
        }
        #endregion
    }
}
