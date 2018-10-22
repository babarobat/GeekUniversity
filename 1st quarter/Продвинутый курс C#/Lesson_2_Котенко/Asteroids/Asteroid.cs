using System.IO;
using System.Drawing;

namespace Asteroids
{
    /// <summary>
    /// Логика и параметры обьекта типа Asteroid
    /// </summary>
    class Asteroid : BaseObject
    {        
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
        /// Минимальная скорость астеройда при создании
        /// </summary>
        private const int _minStartSpeed = 250;
        /// <summary>
        /// максимальная скорость астероида при содании 
        /// </summary>
        private const int _maxStartSpeed = 500;
        /// <summary>
        /// Создает обьект Asteroid и распологает его в случайном месте справа от экрана.
        /// Задает случайную скорость движения в пикселях в секунду
        /// в пределах заданных констант _minStartSpeed = 250, _maxStartSpeed = 500.
        /// По умолчанию направление движения - справа налево. _dirX = -1, _dirY =0;
        /// </summary>
        /// <param name="speed">скорость</param>
        /// <param name="fileName">имя файла</param>
        public Asteroid(string fileName)
        {
            _dir = new PointF(_defaultDirectionX, _defaultDirectionY);
            var asteroidImgPath = Path.GetFullPath(fileName);
            _asteroidImg = Image.FromFile(asteroidImgPath);
            _startSize = _asteroidImg.Size;
            InitAsteroidParams(); 
        }
        /// <summary>
        /// Отрисовка обьекта
        /// </summary>
        public override void Draw()
        {
            var asteroidPos = _pos;
            var asteroidSize = _size;  
            GameGraphics.Buffer.Graphics.DrawImage(_asteroidImg,
                                                    asteroidPos.X, asteroidPos.Y,
                                                    asteroidSize.Width,asteroidSize.Height);  
        }
        /// <summary>
        /// Обновление позиции обьекта
        /// </summary>
        public override void Update()
        {
            _pos.X += _dir.X*Speed/ GameGraphics.TargetFPS;
            if (_pos.X < 0-_size.Width)
            {
                InitAsteroidParams();
            }
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
        /// Инициализация положения, размера и скорости астеродиа
        /// </summary>
        private void InitAsteroidParams()
        {
            _size = GetRandomSize(_startSize);
            _pos = GetRandomPos(GameGraphics.Width, GameGraphics.Width + (int)_size.Width,
                                    0, GameGraphics.Height - (int)_size.Height);
            Speed = 12000 / _size.Width;
            
        }
        #endregion

    }
}

