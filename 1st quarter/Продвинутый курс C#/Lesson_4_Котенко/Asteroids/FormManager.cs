using System.IO;
using System.Drawing.Text;
using System.Windows.Forms;
namespace Asteroids
{
    /// <summary>
    /// Отвечает за взаимодействие форм
    /// </summary>
    static class FormManager
    {
        /// <summary>
        /// Ссылка на шрифт для кнопок
        /// </summary>
        private static PrivateFontCollection _buttonsFont;
        /// <summary>
        /// Ссылка на шрифт для названия игры
        /// </summary>
        private static PrivateFontCollection _gameNameFont;
        /// <summary>
        /// Ширина формы
        /// </summary>
        private const int _screenWidth = 1280;
        /// <summary>
        /// Высота формы
        /// </summary>
        private const int _screenHeight = 720;
        /// <summary>
        /// Ссылка на форму с онсновной частью игры
        /// </summary>
        public static Game GameForm { get; private set; }
        /// <summary>
        /// Ссылка на форму с меню
        /// </summary>
        public static SplashScreen SplashScreen { get; private set; }
        /// <summary>
        /// Сейчас пауза?
        /// </summary>
        public static bool IsPaused ;
        /// <summary>
        /// Показывает форму с заставкой
        /// </summary>
        public static void RunSplashScreen()
        {
            SplashScreen = new SplashScreen()
            {
                Width = _screenWidth,
                Height = _screenHeight
            };
            _buttonsFont = new PrivateFontCollection();
            _gameNameFont = new PrivateFontCollection();
            _buttonsFont.AddFontFile(Path.GetFullPath("Resources/joystix monospace.ttf"));
            _gameNameFont.AddFontFile(Path.GetFullPath("Resources/BACKTO1982.ttf"));
            System.Drawing.Font buttonsFont = new  System.Drawing.Font(_buttonsFont.Families[0], 14f);
            SplashScreen.NewGame.Font = buttonsFont;
            SplashScreen.Records.Font = buttonsFont;
            SplashScreen.Exit.Font = buttonsFont;
            SplashScreen.About.Font = new System.Drawing.Font(_buttonsFont.Families[0], 8f);
            SplashScreen.GameName.Font = new System.Drawing.Font(_gameNameFont.Families[0], 30f);
            if (GameForm != null)
            {
                GameForm.Close();
            }            
            SplashScreen.Show();
        }
        /// <summary>
        /// Показывает форму игрой
        /// </summary>
        public static void RunGameForm()
        {
            GameForm = new Game()
            {
                Width = _screenWidth,
                Height = _screenHeight
            };

            GameGraphics.Init(GameForm);
            GameGraphics.DrawGraphics();
            StartNewGame();


            SplashScreen.Hide();
            
            GameForm.Show();
        }
        /// <summary>
        /// Скрывает или показывает меню паузы
        /// </summary>
        public static void HideAndShowPauseMenu()
        {
            if (SceneObjects.Player.CurrentHealth !=0)
            {
                if (IsPaused)
                {
                    GameForm.MenuButton.Hide();
                    GameForm.RestartButton.Hide();
                }
                if (!IsPaused)
                {
                    GameForm.MenuButton.Show();
                    GameForm.RestartButton.Show();
                }
                IsPaused = !IsPaused;
            }
            
        }
        public static void ShowDieMenu()
        {
            GameForm.MenuButton.Show();
            GameForm.RestartButton.Show();
            GameForm.YouLooseLbl.Show();
            IsPaused = true;
        }
        public static  void StartNewGame()
        {
            IsPaused = false;
            GameForm.ScoreLabel.Font = new System.Drawing.Font(_buttonsFont.Families[0], 11f);
            GameForm.HealthLabel.Font = new System.Drawing.Font(_buttonsFont.Families[0], 11f);
            GameForm.MenuButton.Font = new System.Drawing.Font(_buttonsFont.Families[0], 14f);
            GameForm.MenuButton.Hide();
            GameForm.RestartButton.Font = new System.Drawing.Font(_buttonsFont.Families[0], 14f);
            GameForm.RestartButton.Hide();
            GameForm.YouLooseLbl.Font = new System.Drawing.Font(_gameNameFont.Families[0], 30f);
            GameForm.YouLooseLbl.Hide();
            GameForm.HealthLabel.Text = "Health: " + SceneObjects.Player.CurrentHealth.ToString();
            GameForm.ScoreLabel.Text = "Score: " + SceneObjects.Player.CurrentScore.ToString();
        }
    }
}
