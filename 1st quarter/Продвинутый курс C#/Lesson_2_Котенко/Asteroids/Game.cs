using System;
using System.Windows.Forms;

namespace Asteroids
{
    /// <summary>
    /// Форма с основной частью игры
    /// </summary>
    public partial class Game : Form
    {
        /// <summary>
        /// Ссылка на кнопку, открывающую SplashScreen форму
        /// </summary>
        public Button MenuButton { get; private set; }
        
        public Game()
        {
            InitializeComponent();
            MenuButton = Menu;
        }

        private void Game_Load(object sender, EventArgs e) { }
        void Game_KeyPress(object sender, KeyPressEventArgs e) { }
        /// <summary>
        /// Событие нажатия на кнопку
        /// </summary>
        /// <param name="e">кнопки</param>
        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                FormManager.HideAndShowPauseMenu();
            } 
        }
        /// <summary>
        /// Событие нажатия на кнопку, возвращающую в основное меню
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Menu_Click(object sender, EventArgs e)
        {
            FormManager.RunSplashScreen();
        }
    }
}
