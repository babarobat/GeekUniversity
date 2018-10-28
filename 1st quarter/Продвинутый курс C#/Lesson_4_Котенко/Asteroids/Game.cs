using System;
using System.Windows.Forms;

namespace Asteroids
{
    /// <summary>
    /// Форма с основной частью игры
    /// </summary>
    public partial class Game : Form
    {
        ~Game()
        {
            GameGraphics.Timer.Stop();
        }
        /// <summary>
        /// Ссылка на кнопку, открывающую SplashScreen форму
        /// </summary>
        public Button MenuButton { get; private set; }
        public Button RestartButton { get; private set; }
        public Label HealthLabel { get; private set; }
        public Label ScoreLabel { get; private set; }
        public Label YouLooseLbl { get; private set; }


        public Game()
        {
            InitializeComponent();
            MenuButton = Menu;
            HealthLabel = HealthLbl;
            ScoreLabel = ScoreLbl;
            RestartButton = RestartBtn;
            YouLooseLbl = LooseLbl;
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
            SceneObjects.Player.Move(e);
        }
        protected override void OnKeyUp(KeyEventArgs e)
        {
            SceneObjects.Player.StopMove(e);
        }

        /// <summary>
        /// Событие нажатия на кнопку, возвращающую в основное меню
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Menu_Click(object sender, EventArgs e)
        {
            FormManager.RunSplashScreen();
            SceneObjects.Player.CurrentHealth = SceneObjects.Player.StartHealth;
            SceneObjects.Player.CurrentScore = SceneObjects.Player.StartScore;

        }

        private void HealthLbl_Click(object sender, EventArgs e) { }

        public void SetScore(string score)
        {
            ScoreLabel.Text = "Score: "+score;
        }
        public void SetHealth(string health)
        {
            HealthLbl.Text = "Health: " + health;
        }

        private void RestartBtn_Click(object sender, EventArgs e)
        {
            GameGraphics.LoadNewGame();
            FormManager.StartNewGame();
            FormManager.GameForm.Focus();

        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            GameGraphics.Timer.Stop();
            Application.Exit();
        }
    }
}
