namespace Asteroids
{
    /// <summary>
    /// Отвечает за взаимодействие форм
    /// </summary>
    static class FormManager
    {
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
            IsPaused = false;
            GameForm.MenuButton.Hide();
            GameGraphics.Init(GameForm);
            GameGraphics.DrawGraphics();
            SplashScreen.Hide();
            GameForm.Show();
        }
        /// <summary>
        /// Скрывает или показывает меню паузы
        /// </summary>
        public static void HideAndShowPauseMenu()
        {
            if (IsPaused)
            {
                GameForm.MenuButton.Hide();   
            }
            if (!IsPaused)
            {
                GameForm.MenuButton.Show();  
            }
            IsPaused = !IsPaused;
        }
    }
}
