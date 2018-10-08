using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Asteroids
{
    class Program
    {
        static void Main(string[] args)
        {
            Form GameForm = new Form()
            {
                Width = Screen.PrimaryScreen.Bounds.Width,
                Height = Screen.PrimaryScreen.Bounds.Height
            };
            GameGraphics.Init(GameForm);
            GameGraphics.DrawGraphics();
            GameForm.Show();
            Application.Run(GameForm);

        }
    }
}
