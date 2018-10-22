using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;

namespace Asteroids
{
    class Rocket : BaseObject
    {
        /// <summary>
        /// Урон ракеты
        /// </summary>
        public int Damage { get; private set; }
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
        private Image _asteroidImg;

        private const int _startSpeed = 500;

        public Rocket(string fileName)
        {
            _dir = new PointF(_defaultDirectionX, _defaultDirectionY);
            var rocketImgPath = Path.GetFullPath(fileName);
            _asteroidImg = Image.FromFile(rocketImgPath);
            Speed = _startSpeed;
        }
        public override void Draw()
        {
            GameGraphics.Buffer.Graphics.DrawImage(_asteroidImg,
                                                    _pos.X, _pos.Y,
                                                    _size.Width, _size.Height);
        }

        public override void Update()
        {
            _pos.X = _dir.X* Speed / GameGraphics.TargetFPS;
            if (true)
            {

            }
        }
    }
}
