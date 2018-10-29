using System.Windows.Forms;

namespace Asteroids
{
    class Program
    {
        static void Main(string[] args)
        {
            FormManager.RunSplashScreen();
            Application.Run(FormManager.SplashScreenForm);
        }
    }
}
