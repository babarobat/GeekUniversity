using System.IO;
using System.Drawing;

namespace Asteroids
{
    /// <summary>
    /// Логика и параметры обьекта типа Asteroid
    /// </summary>
    class Asteroid : BaseObject,ICollision
    {  
        /// <summary>
        /// Урон астероида
        /// </summary>
        public int Damage { get; private set; }
        /// <summary>
        /// Здоровье астероида
        /// </summary>
        public int Health { get; private set; }
        /// <summary>
        /// Ссылка на коллайдер. Размер определяется _colliderSize
        /// </summary>
        public RectangleF Collider => new RectangleF(_pos, _colliderSize);
        /// <summary>
        /// Размер коллайдера
        /// </summary>
        private SizeF _colliderSize;

        /// <summary>
        /// Направление движения по оси X по умолчанию
        /// </summary>
        private const int _defaultDirectionX = -1;
        /// <summary>
        /// Направление движения по оси Y по умолчанию
        /// </summary>
        private const int _defaultDirectionY = 0;
        /// <summary>
        /// Исходный размер изображения астероида
        /// </summary>
        private SizeF _startSize;
        /// <summary>
        /// Ссылка на изображение астероида
        /// </summary>
        private Image _asteroidImg;
        /// <summary>
        /// Создает обьект Asteroid и распологает его в случайном месте справа от экрана.
        /// Задает случайную скорость движения в пикселях в секунду в зависимости от размер
        /// - чем больше астероид - тем меньше скорость
        /// По умолчанию направление движения - справа налево. _dirX = -1, _dirY =0;
        /// </summary>
        /// <param name="speed">скорость</param>
        /// <param name="fileName">имя файла</param>
        public Asteroid(string fileName)
        {
            Send += JournalWriter.Write;
            _dir = new PointF(_defaultDirectionX, _defaultDirectionY);
            var asteroidImgPath = Path.GetFullPath(fileName);
            _asteroidImg = Image.FromFile(asteroidImgPath);
            _startSize = _asteroidImg.Size;
            InitAsteroidParams();
            SetColliderSize(0.8f);
            SceneObjects.Asteroids.Add(this);
            
        }
        /// <summary>
        /// Отрисовка обьекта
        /// </summary>
        public override void Draw()
        {
            GameGraphics.Buffer.Graphics.DrawImage(_asteroidImg,
                                                    _pos.X, _pos.Y,
                                                    _size.Width, _size.Height);  
        }
        /// <summary>
        /// Обновление позиции обьекта
        /// </summary>
        public override void Update()
        {
            _pos.X += _dir.X*Speed/ GameGraphics.TargetFPS;
            foreach (ICollision rocket  in SceneObjects.Rockets)
            {
                if (Collision(rocket))
                {
                    SendAction(rocket as BaseObject, "hit Asteroid");
                    rocket.GetDamage(Damage);
                    this.GetDamage(rocket.Damage);
                }
            }
            if (Collision(SceneObjects.Player))
            {
                SendAction(this, "hit Player");
                SceneObjects.Player.GetDamage(Damage);
                this.GetDamage(SceneObjects.Player.Damage);
            }
            
            if (_pos.X < 0-_size.Width)
            {
                InitAsteroidParams();
            }
        }
        /// <summary>
        /// Определяет размер коллайдера относительно исходного размера изображения обьекта
        /// </summary>
        /// <param name="sizeMultiplier">коээфициент, на который умножается размер изображения</param>
        private void SetColliderSize(float sizeMultiplier)
        {
            _colliderSize.Width = _size.Width * sizeMultiplier;
            _colliderSize.Height = _size.Height * sizeMultiplier;
        }
        #region приватные методы
        /// <summary>
        /// Возвращает случайно расположенную точку 
        /// </summary>
        /// <param name="minRndX">Минимальное случайное значение по X</param>
        /// <param name="maxRndX">Максимальное случайное значение по Х</param>
        /// <param name="minRndY">Минимальное случайное значение по У</param>
        /// <param name="maxRndY">Максимальное случайное значение по У</param>
        /// <returns></returns>
        private Point GetRandomPos(int minRndX, int maxRndX, int minRndY, int maxRndY)
        {
            var rndPosX =Util.GetRandom( minRndX, maxRndX);
            var rndPosY = Util.GetRandom(minRndY, maxRndY);
            return new Point(rndPosX, rndPosY);
        }
        /// <summary>
        /// Возвращает случайный размер в пределах от половины заданного до двукратно увеличенного
        /// </summary>
        /// <param name="fromSize">исходнй размер</param>
        /// <returns></returns>
        private SizeF GetRandomSize(SizeF fromSize)
        {
            float rndSizeValue =(float)Util.GetRandom(5, 20) / 10;
            
            return new SizeF(fromSize.Width * rndSizeValue, fromSize.Height * rndSizeValue);
        }
        public string GetInfo()
        {
            return "_pos = "+_pos.X.ToString()+"," + _pos.Y.ToString() + ";" +
                   " _size = "+_size.Width.ToString()+","+_size.Height.ToString();
        }
        /// <summary>
        /// Инициализация положения, размера, скорости, урона и жизней астеродиа
        /// </summary>
        private void InitAsteroidParams()
        {
            _size = GetRandomSize(_startSize);
            _pos = GetRandomPos(GameGraphics.Width, GameGraphics.Width*2,
                                    0, GameGraphics.Height - (int)_size.Height);
            Speed = 12000 / _size.Width;
            CalculateHealth();
        }
        /// <summary>
        /// Расчитывает здоровье и урон астеройда в зависимости от его размера
        /// </summary>
        private void CalculateHealth()
        {
            if (_size.Width <= 150)
            {
                Health = 1;
                Damage = 1;
                return;
            }
            if (_size.Width <= 250 && _size.Width > 150)
            {
                Health = 2;
                Damage = 2;
                return;
            }
            if (_size.Width <= 350 && _size.Width > 250)
            {
                Health = 3;
                Damage = 3;
                return;
            }
            if (_size.Width <= 450 && _size.Width > 350)
            {
                Health = 4;
                Damage = 4;
                return;
            }
            if (_size.Width <= 550 && _size.Width > 450)
            {
                Health = 5;
                Damage = 5;
                return;
            }
            if (_size.Width <= 650 && _size.Width > 550)
            {
                Health = 6;
                Damage = 6;
                return;
            }
            if (_size.Width > 650)
            {
                Health = 7;
                Damage = 7;
                return;
            }
        }


        #endregion
        #region Реализация интерфейса ICollision

        /// <summary>
        /// Произошло ли столкновение с обьектом?
        /// </summary>
        /// <param name="obj">обьект</param>
        /// <returns></returns>
        public bool Collision(ICollision obj)
        {
            return obj.Collider.IntersectsWith(this.Collider);
        }
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
            this.Health -= damage;
            if (Health<1)
            {
                InitAsteroidParams();
            }
        }
        #endregion
    }
}

