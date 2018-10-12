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
            SplashScreen sc = new SplashScreen()
            {
                Width = Screen.PrimaryScreen.Bounds.Width,
                Height = Screen.PrimaryScreen.Bounds.Height
            };

            GameGraphics.Init(sc);
            GameGraphics.DrawGraphics();
            sc.Show();

            Application.Run(sc);

            //GameGraphics.Init(GameForm);
            //GameGraphics.DrawGraphics();
            //GameForm.Show();

            //Application.Run(GameForm);

        }
    }
}
