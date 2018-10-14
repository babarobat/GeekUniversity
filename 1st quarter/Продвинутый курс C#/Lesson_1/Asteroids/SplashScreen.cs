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
        public SplashScreen()
        {
            InitializeComponent();
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

    }
}
