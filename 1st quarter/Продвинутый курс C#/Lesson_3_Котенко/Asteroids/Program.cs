using System.Windows.Forms;
using System;

namespace Asteroids
{
    class Program
    {
        static void Main(string[] args)
        {
            FormManager.RunSplashScreen();
            Application.Run(FormManager.SplashScreen);
        }
    }
}
