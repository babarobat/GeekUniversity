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
    public class Ship : BaseObject, ICollision
    {
        public int Damage => 100;
        public int Health { get; private set; }
        public RectangleF Rect => new RectangleF(_pos, _size);
        
        private Image _shipImg;
        private bool isMoving;
        public Ship(string fileName)
        {
            Speed = 500;
            Health = 10;
            _pos = new PointF(100, 360);
            var shipImgPath = Path.GetFullPath(fileName);
            _shipImg = Image.FromFile(shipImgPath);
            _size = _shipImg.Size;
            
            SceneObjects.Player = this;

        }
        public override void Draw()
        {
            GameGraphics.Buffer.Graphics.DrawImage(_shipImg,
                                                    _pos.X, _pos.Y,
                                                    _size.Width, _size.Height);
        }
        public override void Update()
        {
            if (isMoving)
            {
                _pos.Y += Speed*_dir.Y / GameGraphics.TargetFPS;
            }
            
        }
        public bool Collision(ICollision obj)
        {
            return obj.Rect.IntersectsWith(this.Rect);
        }
        public void GetDamage(int damage)
        {
            Health -= damage;
            if (Health<=0)
            {
                _pos.X = 10;
                _pos.Y = 10;
            }
        }

        public void SetDamage(ICollision obj, int damage)
        {
            obj.GetDamage(damage);
        }

        public void Move(KeyEventArgs e, bool canMoove)
        {
            
            isMoving = canMoove;
            if (canMoove)
            {
                if (e.KeyCode == Keys.Up)
                {
                    _dir.Y = -1;
                }
                if (e.KeyCode == Keys.Down)
                {
                    _dir.Y = 1;
                }
            }
            else
            {
                _dir.Y = 0;
            }
            
            
        }
        
    }
}
