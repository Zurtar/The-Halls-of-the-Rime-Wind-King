namespace Game_Summative
{
    partial class PauseMenu
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.resumeButton = new System.Windows.Forms.Button();
            this.resetButton = new System.Windows.Forms.Button();
            this.mainmenuButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.pauseLabel = new System.Windows.Forms.Label();
            this.helpLabel = new System.Windows.Forms.Label();
            this.background = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // resumeButton
            // 
            this.resumeButton.Font = new System.Drawing.Font("OCR A Extended", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resumeButton.Location = new System.Drawing.Point(120, 108);
            this.resumeButton.Name = "resumeButton";
            this.resumeButton.Size = new System.Drawing.Size(138, 23);
            this.resumeButton.TabIndex = 0;
            this.resumeButton.Text = "Resume";
            this.resumeButton.UseVisualStyleBackColor = true;
            this.resumeButton.Click += new System.EventHandler(this.ResumeButton_Click);
            // 
            // resetButton
            // 
            this.resetButton.Font = new System.Drawing.Font("OCR A Extended", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resetButton.Location = new System.Drawing.Point(31, 157);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(138, 23);
            this.resetButton.TabIndex = 1;
            this.resetButton.Text = "Reset";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.ResetButton_Click);
            // 
            // mainmenuButton
            // 
            this.mainmenuButton.Font = new System.Drawing.Font("OCR A Extended", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainmenuButton.Location = new System.Drawing.Point(120, 205);
            this.mainmenuButton.Name = "mainmenuButton";
            this.mainmenuButton.Size = new System.Drawing.Size(138, 23);
            this.mainmenuButton.TabIndex = 2;
            this.mainmenuButton.Text = "Main Menu";
            this.mainmenuButton.UseVisualStyleBackColor = true;
            this.mainmenuButton.Click += new System.EventHandler(this.MainmenuButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.Font = new System.Drawing.Font("OCR A Extended", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitButton.Location = new System.Drawing.Point(205, 157);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(138, 23);
            this.exitButton.TabIndex = 3;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // pauseLabel
            // 
            this.pauseLabel.AutoSize = true;
            this.pauseLabel.Font = new System.Drawing.Font("OCR A Extended", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pauseLabel.Location = new System.Drawing.Point(15, 22);
            this.pauseLabel.Name = "pauseLabel";
            this.pauseLabel.Size = new System.Drawing.Size(339, 40);
            this.pauseLabel.TabIndex = 4;
            this.pauseLabel.Text = "Game Paused ||";
            // 
            // helpLabel
            // 
            this.helpLabel.AutoSize = true;
            this.helpLabel.Font = new System.Drawing.Font("OCR A Extended", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpLabel.Location = new System.Drawing.Point(37, 62);
            this.helpLabel.Name = "helpLabel";
            this.helpLabel.Size = new System.Drawing.Size(295, 15);
            this.helpLabel.TabIndex = 5;
            this.helpLabel.Text = "Navigate with arrow keys or joystick";
            // 
            // background
            // 
            this.background.BackColor = System.Drawing.Color.Black;
            this.background.Location = new System.Drawing.Point(19, 98);
            this.background.Name = "background";
            this.background.Size = new System.Drawing.Size(335, 140);
            this.background.TabIndex = 6;
            this.background.Text = "label1";
            // 
            // PauseMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.helpLabel);
            this.Controls.Add(this.pauseLabel);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.mainmenuButton);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.resumeButton);
            this.Controls.Add(this.background);
            this.Name = "PauseMenu";
            this.Size = new System.Drawing.Size(370, 247);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button resumeButton;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.Button mainmenuButton;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Label pauseLabel;
        private System.Windows.Forms.Label helpLabel;
        private System.Windows.Forms.Label background;
    }
}
