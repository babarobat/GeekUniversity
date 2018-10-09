using System.Drawing;

namespace Asteroids
{
    class Star:BaseObject
    {
        public Star(Point pos, Point dir, Size size):base(pos, dir, size) { }

        public override void Draw()
        {
            var firstLinePoint1 = _pos;
            var firstLinePoint2 = new Point(_pos.X + _size.Width, _pos.Y + _size.Height);
            GameGraphics.Buffer.Graphics.DrawLine(Pens.White, firstLinePoint1, firstLinePoint2);

            var secondLinePoint1 = new Point(_pos.X + _size.Width, _pos.Y);
            var secondLinePoint2 = new Point(_pos.X, _pos.Y + _size.Height);
            GameGraphics.Buffer.Graphics.DrawLine(Pens.White, secondLinePoint1, secondLinePoint2);
        }

        public override void Update()
        {
            _pos.X = _pos.X - _dir.X;
            if (_pos.X < 0) _pos.X = GameGraphics.Width + _size.Width;
        }
    }
}
