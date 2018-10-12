using System;
using System.IO;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids
{
    /// <summary>
    /// Задний фон.
    /// Загруженная картинка дублируется и движется слева направо со скоростью Speed.
    /// Когда картинка отдаляется от начала координат по оси X на величину одного экрана,
    /// данный экземпляр возвращается к своему начальному положению.
    /// </summary>
    class BackGround : BaseObject
    {
        /// <summary>
        /// Скорость движения. Измеряется в пикселях в секунду.
        /// </summary>
        public float Speed { get; set; }

        /// <summary>
        /// Направление движения по оси X по умолчанию
        /// </summary>
        private const int _defaultDirectionX = -1;
        /// <summary>
        /// Направление движения по оси Y по умолчанию
        /// </summary>
        private const int _defaultDirectionY = 0;
        /// <summary>
        /// Направление движения по оси X по умолчанию
        /// </summary>
        private const int _defaultpositionX = 0;
        /// <summary>
        /// Направление движения по оси Y по умолчанию
        /// </summary>
        private const int _defaultpositionY = 0;

        /// <summary>
        /// Первая часть заднего фона
        /// </summary>
        private Image _starsBgImg1;
        /// <summary>
        /// Вторая часть заднего фона
        /// </summary>
        private Image _starsBgImg2;

        /// <summary>
        /// Создает экземпляр класса BackGround. 
        /// направление движение по умолчанию _dir = -1,0;
        /// </summary>
        /// <param name="speed">скорость движения фона</param>
        /// <param name="fileName">путь, либо имя файла в папке Debug</param>
        public BackGround(float speed, string fileName )
        {
            Speed = speed;
            _pos = new PointF(_defaultpositionX, _defaultpositionY);
            _dir = new PointF(_defaultDirectionX, _defaultDirectionY);
            _size = new Size(GameGraphics.Width, GameGraphics.Height);
            var starsBgPath = Path.GetFullPath(fileName);
            _starsBgImg1 = Image.FromFile(starsBgPath);
            _starsBgImg2 = Image.FromFile(starsBgPath);
        }
        /// <summary>
        /// Отрисовка элемнта заднего фона
        /// </summary>
        public override void Draw()
        {
            var img1PosPoint = _pos;
            var img2PosPoint = new PointF(_pos.X + GameGraphics.Width, _pos.Y);
            GameGraphics.Buffer.Graphics.DrawImage(_starsBgImg1, img1PosPoint);
            GameGraphics.Buffer.Graphics.DrawImage(_starsBgImg2, img2PosPoint);
        }
        /// <summary>
        /// Изменение позиции
        /// </summary>
        public override void Update()
        {
            _pos.X += _dir.X * Speed / GameGraphics.TargetFPS;
            if (Math.Abs( _pos.X) > GameGraphics.Width)
            {
                _pos.X = 0;
            }            
        }
        
        
    }
}
