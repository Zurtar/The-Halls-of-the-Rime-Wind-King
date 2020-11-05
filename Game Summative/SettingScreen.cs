using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game_Summative
{
    public partial class SettingScreen : UserControl
    {

        int upDown = 0, leftDown = 0, downDown = 0, rightDown = 0, pauseDown = 0;

        bool keyMode = false;
        public SettingScreen()
        {
            InitializeComponent();
            animationTimer.Enabled = true;
        }

        private void MainMenuButton_Click(object sender, EventArgs e)
        {
            Form f = this.FindForm();
            f.Controls.Remove(this);
            MainMenu mm = new MainMenu();
            mm.Location = new Point((Form1.screenWidth - mm.Width) / 2, (Form1.screenHeight - mm.Height) / 2);
            f.Controls.Add(mm);
            mm.Focus();
        }

        private void KeyboardButton_Click(object sender, EventArgs e)
        {
            if (keyMode == false)
            {
                keyMode = true;

                keyboardButton.Text = "Arcade Controls";

                upPicBox.Image = Properties.Resources.wKeyUp;
                rightPicBox.Image = Properties.Resources.dKeyUp;
                downPicBox.Image = Properties.Resources.sKeyUp;
                leftPicBox.Image = Properties.Resources.aKeyUp;
                pausePicBox.Image = Properties.Resources.escKeyUp;
                resetPicBox.Image = Properties.Resources.rKeyUp;
            }
            else if (keyMode == true)
            {
                keyMode = false;

                keyboardButton.Text = "Keyboard Controls";

                upPicBox.Image = Properties.Resources.yellowButtonUp;
                rightPicBox.Image = Properties.Resources.redButtonUp;
                downPicBox.Image = Properties.Resources.greenButtonUp;
                leftPicBox.Image = Properties.Resources.blueButtonUp;
                pausePicBox.Image = Properties.Resources.blackButtonUp;
                resetPicBox.Image = Properties.Resources.joystick;
            }
        }

        private void UpPicBox_Click(object sender, EventArgs e)
        {
            Form1.characterSprite = "Gold";

            if (keyMode == false)
            {
                upPicBox.Image = Properties.Resources.yellowButtonDown;
            }
            else if (keyMode == true)
            {
                upPicBox.Image = Properties.Resources.wKeyDown;
            }

            upDown = 10;
        }

        private void RightPicBox_Click(object sender, EventArgs e)
        {
            Form1.characterSprite = "CherryCola";

            if (keyMode == false)
            {
                rightPicBox.Image = Properties.Resources.redButtonDown;
            }
            else if (keyMode == true)
            {
                rightPicBox.Image = Properties.Resources.dKeyDown;
            }

            rightDown = 10;
        }

        private void DownPicBox_Click(object sender, EventArgs e)
        {
            Form1.characterSprite = "Hunter";

            if (keyMode == false)
            {
                downPicBox.Image = Properties.Resources.greenButtonDown;
            }
            else if (keyMode == true)
            {
                downPicBox.Image = Properties.Resources.sKeyDown;
            }

            downDown = 10;
        }

        private void LeftPicBox_Click(object sender, EventArgs e)
        {
            Form1.characterSprite = "ShiningArmour";

            if (keyMode == false)
            {
                leftPicBox.Image = Properties.Resources.blueButtonDown;
            }
            else if (keyMode == true)
            {
                leftPicBox.Image = Properties.Resources.aKeyDown;
            }

            leftDown = 10;
        }

        private void PausePicBox_Click(object sender, EventArgs e)
        {
            Form1.characterSprite = "Plasma";

            if (keyMode == false)
            {
                pausePicBox.Image = Properties.Resources.blackButtonDown;
            }
            else if (keyMode == true)
            {
                pausePicBox.Image = Properties.Resources.escKeyDown;
            }

            pauseDown = 10;
        }

        private void AnimationTimer_Tick(object sender, EventArgs e)
        {
            // Animation checks tick down
            if (upDown > 0)
            {
                upDown--;
            }
            if (rightDown > 0)
            {
                rightDown--;
            }
            if (downDown > 0)
            {
                downDown--;
            }
            if (leftDown > 0)
            {
                leftDown--;
            }
            if (pauseDown > 0)
            {
                pauseDown--;
            }

            // Change animation modes for arcade mode
            if (upDown == 0 && keyMode == false)
            {
                upPicBox.Image = Properties.Resources.yellowButtonUp;
            }
            if (rightDown == 0 && keyMode == false)
            {
                rightPicBox.Image = Properties.Resources.redButtonUp;
            }
            if (downDown == 0 && keyMode == false)
            {
                downPicBox.Image = Properties.Resources.greenButtonUp;
            }
            if (leftDown == 0 && keyMode == false)
            {
                leftPicBox.Image = Properties.Resources.blueButtonUp;
            }
            if (pauseDown == 0 && keyMode == false)
            {
                pausePicBox.Image = Properties.Resources.blackButtonUp;
            }

            // Change animation modes for keyboard mode
            if (upDown == 0 && keyMode == true)
            {
                upPicBox.Image = Properties.Resources.wKeyUp;
            }
            if (rightDown == 0 && keyMode == true)
            {
                rightPicBox.Image = Properties.Resources.dKeyUp;
            }
            if (downDown == 0 && keyMode == true)
            {
                downPicBox.Image = Properties.Resources.sKeyUp;
            }
            if (leftDown == 0 && keyMode == true)
            {
                leftPicBox.Image = Properties.Resources.aKeyUp;
            }
            if (pauseDown == 0 && keyMode == true)
            {
                pausePicBox.Image = Properties.Resources.escKeyUp;
            }

        }
    }
}
