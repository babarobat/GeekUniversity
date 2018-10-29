using System.IO;
using System.Drawing.Text;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using System;
using System.Linq;

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
        public static SplashScreen SplashScreenForm { get; private set; }
        /// <summary>
        /// Сейчас пауза?
        /// </summary>
        public static bool IsPaused ;
        /// <summary>
        /// Показывает форму с заставкой
        /// </summary>
        public static void RunSplashScreen()
        {
            SplashScreenForm = new SplashScreen()
            {
                Width = _screenWidth,
                Height = _screenHeight
            };
            _buttonsFont = new PrivateFontCollection();
            _gameNameFont = new PrivateFontCollection();
            _buttonsFont.AddFontFile(Path.GetFullPath("Resources/joystix monospace.ttf"));
            _gameNameFont.AddFontFile(Path.GetFullPath("Resources/BACKTO1982.ttf"));
            System.Drawing.Font buttonsFont = new  System.Drawing.Font(_buttonsFont.Families[0], 14f);
            SplashScreenForm.ScoresText.Font = new System.Drawing.Font(_buttonsFont.Families[0], 8f); ;
            SplashScreenForm.NewGame.Font = buttonsFont;
            SplashScreenForm.Records.Font = buttonsFont;
            SplashScreenForm.CloseScoresBtn.Font = buttonsFont;
            SplashScreenForm.Exit.Font = buttonsFont;
            SplashScreenForm.About.Font = new System.Drawing.Font(_buttonsFont.Families[0], 8f);
            SplashScreenForm.GameName.Font = new System.Drawing.Font(_gameNameFont.Families[0], 30f);

            

            HideScores();


            if (GameForm != null)
            {
                GameForm.Close();
            }            
            SplashScreenForm.Show();
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


            SplashScreenForm.Hide();
            
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
        /// <summary>
        /// Отображает и скрывает меню паузы во время игры
        /// </summary>
        public static void ShowDieMenu()
        {
            GameForm.MenuButton.Show();
            GameForm.RestartButton.Show();
            GameForm.YouLooseLbl.Show();
            IsPaused = true;
        }
        /// <summary>
        /// Инициализация обьектов пользовательского интерфейса
        /// </summary>
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
        /// <summary>
        /// Отображает панель с рекордами
        /// </summary>
        public static void ShowScores()
        {
            SplashScreenForm.ScoresText.Show();
            //ScoresManager.HighScores.scores.

            var d = ScoresManager.HighScores.scores.OrderBy(e => e.Value).Reverse();
            foreach (KeyValuePair<DateTime,int> item in d)
            {
                SplashScreenForm.ScoresText.Text += item.Key.ToString()
                                                    + " player destroyed  " 
                                                    + item.Value.ToString() 
                                                    + " asteroids" 
                                                    + Environment.NewLine;
                Console.WriteLine(item.Value);
            }
            SplashScreenForm.CloseScoresBtn.Show();
        }
        /// <summary>
        /// скрывает панель с рекордами
        /// </summary>
        public static void HideScores()
        {
            SplashScreenForm.ScoresText.Hide();
            SplashScreenForm.CloseScoresBtn.Hide();
        }
    }
}
