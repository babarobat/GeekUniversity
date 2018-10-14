using System.Drawing;

namespace Asteroids
{
    /// <summary>
    /// Описывает обьект типа звезда
    /// </summary>
    class Star:BaseObject
    {
        /// <summary>
        /// Создает новый экземпляр класса star
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="dir"></param>
        /// <param name="size"></param>
        public Star(Point pos, Point dir, Size size):base(pos, dir, size) { }
        /// <summary>
        /// Оотрисовка звезды
        /// </summary>
        public override void Draw()
        {
            var firstLinePoint1 = _pos;
            var firstLinePoint2 = new PointF(_pos.X + _size.Width, _pos.Y + _size.Height);
            GameGraphics.Buffer.Graphics.DrawLine(Pens.White, firstLinePoint1, firstLinePoint2);

            var secondLinePoint1 = new PointF(_pos.X + _size.Width, _pos.Y);
            var secondLinePoint2 = new PointF(_pos.X, _pos.Y + _size.Height);
            GameGraphics.Buffer.Graphics.DrawLine(Pens.White, secondLinePoint1, secondLinePoint2);   
        }
        /// <summary>
        /// Обновление позиции звезды
        /// </summary>
        public override void Update()
        {
            _pos.X = _pos.X - _dir.X;
            if (_pos.X < 0) _pos.X = GameGraphics.Width + _size.Width;
        }
    }
}
