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
        /// <summary>
        /// ссылка на кнопку Restart
        /// </summary>
        public Button RestartButton { get; private set; }
        /// <summary>
        /// ссылка на лейбл с показателем жизней
        /// </summary>
        public Label HealthLabel { get; private set; }
        /// <summary>
        /// ссылка на лейбл со счетом сбитых астероидов
        /// </summary>
        public Label ScoreLabel { get; private set; }
       /// <summary>
       /// ссылка на лейбл с сообщением о поражении
       /// </summary>
        public Label YouLooseLbl { get; private set; }

        /// <summary>
        /// конструктор окна game
        /// </summary>
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
        /// <summary>
        /// События отпускания кнопки
        /// </summary>
        /// <param name="e"></param>
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
        /// <summary>
        /// обнавляет текст колличества сбитых астероидов
        /// </summary>
        /// <param name="score"></param>
        public void SetScore(string score)
        {
            ScoreLabel.Text = "Score: "+score;
        }
        /// <summary>
        /// обнавляет текст жизней персонажа 
        /// </summary>
        /// <param name="health"></param>
        public void SetHealth(string health)
        {
            HealthLbl.Text = "Health: " + health;
        }
        /// <summary>
        /// Логика нажатия на кнопку рестарт
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RestartBtn_Click(object sender, EventArgs e)
        {
            GameGraphics.LoadNewGame();
            FormManager.StartNewGame();
            FormManager.GameForm.Focus();

        }
        /// <summary>
        /// логика закрытия формы
        /// </summary>
        /// <param name="e"></param>
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            GameGraphics.Timer.Stop();
            if (SceneObjects.Player.CurrentScore != 0)
            {
                ScoresManager.HighScores.scores.Add(DateTime.Now, SceneObjects.Player.CurrentScore);
                ScoresManager.SaveScores();
            }
            
        }
    }
}
