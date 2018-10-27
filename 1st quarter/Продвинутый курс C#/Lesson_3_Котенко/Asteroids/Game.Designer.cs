namespace Asteroids
{
    partial class Game
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Menu = new System.Windows.Forms.Button();
            this.HealthLbl = new System.Windows.Forms.Label();
            this.ScoreLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Menu
            // 
            this.Menu.BackColor = System.Drawing.Color.Black;
            this.Menu.FlatAppearance.BorderSize = 0;
            this.Menu.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.Menu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Menu.Font = new System.Drawing.Font("Joystix Monospace", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Menu.ForeColor = System.Drawing.Color.White;
            this.Menu.Location = new System.Drawing.Point(529, 296);
            this.Menu.Name = "Menu";
            this.Menu.Size = new System.Drawing.Size(201, 66);
            this.Menu.TabIndex = 1;
            this.Menu.Text = "Menu";
            this.Menu.UseVisualStyleBackColor = false;
            this.Menu.Click += new System.EventHandler(this.Menu_Click);
            // 
            // HealthLbl
            // 
            this.HealthLbl.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.HealthLbl.Location = new System.Drawing.Point(13, 13);
            this.HealthLbl.Name = "HealthLbl";
            this.HealthLbl.Size = new System.Drawing.Size(190, 31);
            this.HealthLbl.TabIndex = 2;
            this.HealthLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.HealthLbl.Click += new System.EventHandler(this.HealthLbl_Click);
            // 
            // ScoreLbl
            // 
            this.ScoreLbl.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.ScoreLbl.Location = new System.Drawing.Point(13, 44);
            this.ScoreLbl.Name = "ScoreLbl";
            this.ScoreLbl.Size = new System.Drawing.Size(190, 31);
            this.ScoreLbl.TabIndex = 3;
            this.ScoreLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.ScoreLbl);
            this.Controls.Add(this.HealthLbl);
            this.Controls.Add(this.Menu);
            this.Name = "Game";
            this.Text = "Game";
            this.Load += new System.EventHandler(this.Game_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button Menu;
        private System.Windows.Forms.Label HealthLbl;
        private System.Windows.Forms.Label ScoreLbl;
    }
}