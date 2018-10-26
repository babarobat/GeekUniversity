using System;
using System.Drawing;
using System.Windows.Forms;

namespace Asteroids
{
   
    /// <summary>
    /// Форма с главным меню
    /// </summary>
    public partial class SplashScreen : Form
    {
        /// <summary>
        /// Ссылка на кнопку NewGame
        /// </summary>
        public Button NewGame { get; private set; }
        /// <summary>
        /// Ссылка на кнопку Records
        /// </summary>
        public Button Records { get; private set; }
        /// <summary>
        /// Ссылка на кнопку Exit
        /// </summary>
        public Button Exit { get; private set; }
        /// <summary>
        /// Ссылка на лейбл GameName
        /// </summary>
        public Label GameName { get; private set; }
        /// <summary>
        /// Ссылка на лейбл About
        /// </summary>
        public Label About { get; private set; }

        public SplashScreen()
        {
            InitializeComponent();
            NewGame = NewGameBtn;
            Records = RecordsBtn;
            Exit = QuitBtn;
            About = AuthorLbl;
            GameName = GameNameLabel;
            GameNameLabel.BackColor = Color.Transparent;
        }
        /// <summary>
        /// События нажатия на кнопку New Game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            FormManager.RunGameForm();
        }
        /// <summary>
        /// Событие нажатия на кнопку Exit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void GameNameLabel_Click(object sender, EventArgs e) { }
        private void AboutBtn_Click(object sender, EventArgs e) { }
        private void AuthorLbl_Click(object sender, EventArgs e) { }
        private void panel1_Paint(object sender, PaintEventArgs e) { }
        private void RecordsBtn_Click(object sender, EventArgs e) { }

    }
}
