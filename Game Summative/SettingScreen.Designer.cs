namespace Game_Summative
{
    partial class SettingScreen
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingScreen));
            this.moveLabel = new System.Windows.Forms.Label();
            this.pauseLabel = new System.Windows.Forms.Label();
            this.resetLabel = new System.Windows.Forms.Label();
            this.controlsLabel = new System.Windows.Forms.Label();
            this.mainMenuButton = new System.Windows.Forms.Button();
            this.keyboardButton = new System.Windows.Forms.Button();
            this.resetPicBox = new System.Windows.Forms.PictureBox();
            this.rightPicBox = new System.Windows.Forms.PictureBox();
            this.upPicBox = new System.Windows.Forms.PictureBox();
            this.leftPicBox = new System.Windows.Forms.PictureBox();
            this.pausePicBox = new System.Windows.Forms.PictureBox();
            this.downPicBox = new System.Windows.Forms.PictureBox();
            this.animationTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.resetPicBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rightPicBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.upPicBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.leftPicBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pausePicBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.downPicBox)).BeginInit();
            this.SuspendLayout();
            // 
            // moveLabel
            // 
            this.moveLabel.Font = new System.Drawing.Font("OCR A Extended", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.moveLabel.ForeColor = System.Drawing.Color.White;
            this.moveLabel.Location = new System.Drawing.Point(36, 337);
            this.moveLabel.Name = "moveLabel";
            this.moveLabel.Size = new System.Drawing.Size(308, 40);
            this.moveLabel.TabIndex = 5;
            this.moveLabel.Text = "Movement Keys";
            this.moveLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pauseLabel
            // 
            this.pauseLabel.Font = new System.Drawing.Font("OCR A Extended", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pauseLabel.ForeColor = System.Drawing.Color.White;
            this.pauseLabel.Location = new System.Drawing.Point(373, 249);
            this.pauseLabel.Name = "pauseLabel";
            this.pauseLabel.Size = new System.Drawing.Size(124, 42);
            this.pauseLabel.TabIndex = 6;
            this.pauseLabel.Text = "Pause";
            // 
            // resetLabel
            // 
            this.resetLabel.AutoSize = true;
            this.resetLabel.Font = new System.Drawing.Font("OCR A Extended", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resetLabel.ForeColor = System.Drawing.Color.White;
            this.resetLabel.Location = new System.Drawing.Point(373, 388);
            this.resetLabel.Name = "resetLabel";
            this.resetLabel.Size = new System.Drawing.Size(115, 35);
            this.resetLabel.TabIndex = 7;
            this.resetLabel.Text = "Reset";
            // 
            // controlsLabel
            // 
            this.controlsLabel.AutoSize = true;
            this.controlsLabel.Font = new System.Drawing.Font("OCR A Extended", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.controlsLabel.ForeColor = System.Drawing.Color.White;
            this.controlsLabel.Location = new System.Drawing.Point(305, 17);
            this.controlsLabel.Name = "controlsLabel";
            this.controlsLabel.Size = new System.Drawing.Size(315, 63);
            this.controlsLabel.TabIndex = 9;
            this.controlsLabel.Text = "Controls";
            // 
            // mainMenuButton
            // 
            this.mainMenuButton.Location = new System.Drawing.Point(440, 91);
            this.mainMenuButton.Name = "mainMenuButton";
            this.mainMenuButton.Size = new System.Drawing.Size(159, 23);
            this.mainMenuButton.TabIndex = 10;
            this.mainMenuButton.Text = "Main Menu";
            this.mainMenuButton.UseVisualStyleBackColor = true;
            this.mainMenuButton.Click += new System.EventHandler(this.MainMenuButton_Click);
            // 
            // keyboardButton
            // 
            this.keyboardButton.Location = new System.Drawing.Point(440, 137);
            this.keyboardButton.Name = "keyboardButton";
            this.keyboardButton.Size = new System.Drawing.Size(159, 23);
            this.keyboardButton.TabIndex = 11;
            this.keyboardButton.Text = "Keyboard Controls";
            this.keyboardButton.UseVisualStyleBackColor = true;
            this.keyboardButton.Click += new System.EventHandler(this.KeyboardButton_Click);
            // 
            // resetPicBox
            // 
            this.resetPicBox.Image = global::Game_Summative.Properties.Resources.joystick;
            this.resetPicBox.Location = new System.Drawing.Point(503, 361);
            this.resetPicBox.Name = "resetPicBox";
            this.resetPicBox.Size = new System.Drawing.Size(96, 96);
            this.resetPicBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.resetPicBox.TabIndex = 8;
            this.resetPicBox.TabStop = false;
            // 
            // rightPicBox
            // 
            this.rightPicBox.Image = ((System.Drawing.Image)(resources.GetObject("rightPicBox.Image")));
            this.rightPicBox.Location = new System.Drawing.Point(249, 120);
            this.rightPicBox.Name = "rightPicBox";
            this.rightPicBox.Size = new System.Drawing.Size(96, 96);
            this.rightPicBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.rightPicBox.TabIndex = 4;
            this.rightPicBox.TabStop = false;
            this.rightPicBox.Click += new System.EventHandler(this.RightPicBox_Click);
            // 
            // upPicBox
            // 
            this.upPicBox.Image = ((System.Drawing.Image)(resources.GetObject("upPicBox.Image")));
            this.upPicBox.Location = new System.Drawing.Point(143, 17);
            this.upPicBox.Name = "upPicBox";
            this.upPicBox.Size = new System.Drawing.Size(96, 96);
            this.upPicBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.upPicBox.TabIndex = 3;
            this.upPicBox.TabStop = false;
            this.upPicBox.Click += new System.EventHandler(this.UpPicBox_Click);
            // 
            // leftPicBox
            // 
            this.leftPicBox.Image = ((System.Drawing.Image)(resources.GetObject("leftPicBox.Image")));
            this.leftPicBox.Location = new System.Drawing.Point(42, 120);
            this.leftPicBox.Name = "leftPicBox";
            this.leftPicBox.Size = new System.Drawing.Size(96, 96);
            this.leftPicBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.leftPicBox.TabIndex = 2;
            this.leftPicBox.TabStop = false;
            this.leftPicBox.Click += new System.EventHandler(this.LeftPicBox_Click);
            // 
            // pausePicBox
            // 
            this.pausePicBox.Image = ((System.Drawing.Image)(resources.GetObject("pausePicBox.Image")));
            this.pausePicBox.Location = new System.Drawing.Point(503, 223);
            this.pausePicBox.Name = "pausePicBox";
            this.pausePicBox.Size = new System.Drawing.Size(96, 96);
            this.pausePicBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pausePicBox.TabIndex = 0;
            this.pausePicBox.TabStop = false;
            this.pausePicBox.Click += new System.EventHandler(this.PausePicBox_Click);
            // 
            // downPicBox
            // 
            this.downPicBox.Image = ((System.Drawing.Image)(resources.GetObject("downPicBox.Image")));
            this.downPicBox.Location = new System.Drawing.Point(143, 223);
            this.downPicBox.Name = "downPicBox";
            this.downPicBox.Size = new System.Drawing.Size(96, 96);
            this.downPicBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.downPicBox.TabIndex = 1;
            this.downPicBox.TabStop = false;
            this.downPicBox.Click += new System.EventHandler(this.DownPicBox_Click);
            // 
            // animationTimer
            // 
            this.animationTimer.Interval = 20;
            this.animationTimer.Tick += new System.EventHandler(this.AnimationTimer_Tick);
            // 
            // SettingScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.keyboardButton);
            this.Controls.Add(this.mainMenuButton);
            this.Controls.Add(this.controlsLabel);
            this.Controls.Add(this.resetPicBox);
            this.Controls.Add(this.resetLabel);
            this.Controls.Add(this.pauseLabel);
            this.Controls.Add(this.moveLabel);
            this.Controls.Add(this.rightPicBox);
            this.Controls.Add(this.upPicBox);
            this.Controls.Add(this.leftPicBox);
            this.Controls.Add(this.pausePicBox);
            this.Controls.Add(this.downPicBox);
            this.Name = "SettingScreen";
            this.Size = new System.Drawing.Size(644, 473);
            ((System.ComponentModel.ISupportInitialize)(this.resetPicBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rightPicBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.upPicBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.leftPicBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pausePicBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.downPicBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox downPicBox;
        private System.Windows.Forms.PictureBox leftPicBox;
        private System.Windows.Forms.PictureBox upPicBox;
        private System.Windows.Forms.PictureBox rightPicBox;
        private System.Windows.Forms.Label moveLabel;
        private System.Windows.Forms.Label pauseLabel;
        private System.Windows.Forms.Label resetLabel;
        private System.Windows.Forms.PictureBox pausePicBox;
        private System.Windows.Forms.PictureBox resetPicBox;
        private System.Windows.Forms.Label controlsLabel;
        private System.Windows.Forms.Button mainMenuButton;
        private System.Windows.Forms.Button keyboardButton;
        private System.Windows.Forms.Timer animationTimer;
    }
}
