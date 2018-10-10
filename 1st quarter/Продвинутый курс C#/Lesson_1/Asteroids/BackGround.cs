using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids
{
    class BackGround : BaseObject
    {

        public BackGround(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }

        public override void Draw()
        {
            var path = "Resources/SpaceBG2.jpeg";
            var img = Image.FromFile(path);
            GameGraphics.Buffer.Graphics.DrawImage(img,_pos );
        }

        public override void Update()
        {
            
        }
    }
}
