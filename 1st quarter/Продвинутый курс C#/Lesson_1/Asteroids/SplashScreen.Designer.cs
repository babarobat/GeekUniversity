namespace Asteroids
{
    partial class SplashScreen
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
            this.components = new System.ComponentModel.Container();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.NewGameBtn = new System.Windows.Forms.Button();
            this.RecordsBtn = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.button1 = new System.Windows.Forms.Button();
            this.GameNameLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.AuthorLbl = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // imageList2
            // 
            this.imageList2.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList2.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // NewGameBtn
            // 
            this.NewGameBtn.BackColor = System.Drawing.Color.Black;
            this.NewGameBtn.FlatAppearance.BorderColor = System.Drawing.Color.Honeydew;
            this.NewGameBtn.FlatAppearance.BorderSize = 0;
            this.NewGameBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.NewGameBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.NewGameBtn.Font = new System.Drawing.Font("Joystix Monospace", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewGameBtn.Location = new System.Drawing.Point(564, 274);
            this.NewGameBtn.Name = "NewGameBtn";
            this.NewGameBtn.Size = new System.Drawing.Size(150, 50);
            this.NewGameBtn.TabIndex = 0;
            this.NewGameBtn.Text = "New game";
            this.NewGameBtn.UseVisualStyleBackColor = false;
            this.NewGameBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // RecordsBtn
            // 
            this.RecordsBtn.BackColor = System.Drawing.Color.Black;
            this.RecordsBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.RecordsBtn.FlatAppearance.BorderSize = 0;
            this.RecordsBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.RecordsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RecordsBtn.Font = new System.Drawing.Font("Joystix Monospace", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RecordsBtn.Location = new System.Drawing.Point(564, 330);
            this.RecordsBtn.Name = "RecordsBtn";
            this.RecordsBtn.Size = new System.Drawing.Size(150, 50);
            this.RecordsBtn.TabIndex = 1;
            this.RecordsBtn.Text = "Records";
            this.RecordsBtn.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Black;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Joystix Monospace", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(564, 386);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(150, 50);
            this.button1.TabIndex = 3;
            this.button1.Text = "Quit";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // GameNameLabel
            // 
            this.GameNameLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.GameNameLabel.BackColor = System.Drawing.Color.Transparent;
            this.GameNameLabel.Font = new System.Drawing.Font("Back to 1982", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GameNameLabel.Location = new System.Drawing.Point(359, 103);
            this.GameNameLabel.Name = "GameNameLabel";
            this.GameNameLabel.Size = new System.Drawing.Size(588, 92);
            this.GameNameLabel.TabIndex = 4;
            this.GameNameLabel.Text = "Asteroids";
            this.GameNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.GameNameLabel.Click += new System.EventHandler(this.GameNameLabel_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.AuthorLbl);
            this.panel1.Controls.Add(this.NewGameBtn);
            this.panel1.Controls.Add(this.GameNameLabel);
            this.panel1.Controls.Add(this.RecordsBtn);
            this.panel1.Controls.Add(this.button1);
            this.panel1.ForeColor = System.Drawing.Color.Snow;
            this.panel1.Location = new System.Drawing.Point(-2, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1268, 689);
            this.panel1.TabIndex = 5;
            // 
            // AuthorLbl
            // 
            this.AuthorLbl.Font = new System.Drawing.Font("Joystix Monospace", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AuthorLbl.Location = new System.Drawing.Point(362, 632);
            this.AuthorLbl.Name = "AuthorLbl";
            this.AuthorLbl.Size = new System.Drawing.Size(570, 40);
            this.AuthorLbl.TabIndex = 5;
            this.AuthorLbl.Text = "Denis Kotenko. GeekBrains. 2018";
            this.AuthorLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.AuthorLbl.Click += new System.EventHandler(this.AuthorLbl_Click);
            // 
            // SplashScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.panel1);
            this.Name = "SplashScreen";
            this.Text = "SplashScreencs";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ImageList imageList2;
        private System.Windows.Forms.Button NewGameBtn;
        private System.Windows.Forms.Button RecordsBtn;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label GameNameLabel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label AuthorLbl;
    }
}