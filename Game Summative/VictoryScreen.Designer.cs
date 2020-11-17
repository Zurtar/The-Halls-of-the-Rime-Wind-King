namespace Game_Summative
{
    partial class VictoryScreen
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
            this.scoreOutput = new System.Windows.Forms.Label();
            this.motivationOutput = new System.Windows.Forms.Label();
            this.parOutput = new System.Windows.Forms.Label();
            this.replayButton = new System.Windows.Forms.Button();
            this.MainMenuButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // scoreOutput
            // 
            this.scoreOutput.BackColor = System.Drawing.Color.Black;
            this.scoreOutput.Font = new System.Drawing.Font("OCR A Extended", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scoreOutput.ForeColor = System.Drawing.Color.White;
            this.scoreOutput.Location = new System.Drawing.Point(0, 163);
            this.scoreOutput.Name = "scoreOutput";
            this.scoreOutput.Size = new System.Drawing.Size(547, 23);
            this.scoreOutput.TabIndex = 0;
            this.scoreOutput.Text = "You made # moves!";
            this.scoreOutput.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // motivationOutput
            // 
            this.motivationOutput.BackColor = System.Drawing.Color.Black;
            this.motivationOutput.Font = new System.Drawing.Font("OCR A Extended", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.motivationOutput.ForeColor = System.Drawing.Color.White;
            this.motivationOutput.Location = new System.Drawing.Point(0, 199);
            this.motivationOutput.Name = "motivationOutput";
            this.motivationOutput.Size = new System.Drawing.Size(547, 23);
            this.motivationOutput.TabIndex = 1;
            this.motivationOutput.Text = "Make ## less moves for bogey";
            this.motivationOutput.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // parOutput
            // 
            this.parOutput.BackColor = System.Drawing.Color.Black;
            this.parOutput.Font = new System.Drawing.Font("OCR A Extended", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.parOutput.ForeColor = System.Drawing.Color.White;
            this.parOutput.Location = new System.Drawing.Point(0, 50);
            this.parOutput.Name = "parOutput";
            this.parOutput.Size = new System.Drawing.Size(547, 86);
            this.parOutput.TabIndex = 2;
            this.parOutput.Text = "Double Bogey";
            this.parOutput.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // replayButton
            // 
            this.replayButton.Font = new System.Drawing.Font("OCR A Extended", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.replayButton.Location = new System.Drawing.Point(213, 237);
            this.replayButton.Name = "replayButton";
            this.replayButton.Size = new System.Drawing.Size(127, 35);
            this.replayButton.TabIndex = 3;
            this.replayButton.Text = "Try Again?";
            this.replayButton.UseVisualStyleBackColor = true;
            this.replayButton.Click += new System.EventHandler(this.ReplayButton_Click);
            // 
            // MainMenuButton
            // 
            this.MainMenuButton.Font = new System.Drawing.Font("OCR A Extended", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuButton.Location = new System.Drawing.Point(214, 278);
            this.MainMenuButton.Name = "MainMenuButton";
            this.MainMenuButton.Size = new System.Drawing.Size(126, 35);
            this.MainMenuButton.TabIndex = 4;
            this.MainMenuButton.Text = "Main Menu";
            this.MainMenuButton.UseVisualStyleBackColor = true;
            this.MainMenuButton.Click += new System.EventHandler(this.MainMenuButton_Click);
            // 
            // VictoryScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.Controls.Add(this.MainMenuButton);
            this.Controls.Add(this.replayButton);
            this.Controls.Add(this.parOutput);
            this.Controls.Add(this.motivationOutput);
            this.Controls.Add(this.scoreOutput);
            this.Name = "VictoryScreen";
            this.Size = new System.Drawing.Size(547, 402);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label scoreOutput;
        private System.Windows.Forms.Label motivationOutput;
        private System.Windows.Forms.Label parOutput;
        private System.Windows.Forms.Button replayButton;
        private System.Windows.Forms.Button MainMenuButton;
    }
}
