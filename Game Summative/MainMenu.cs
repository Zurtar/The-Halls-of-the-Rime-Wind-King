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
    public partial class MainMenu : UserControl
    {
        public static GameScreen gs;

        public MainMenu()
        {
            InitializeComponent();
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            // Loading the main Game Screen
            Form f = this.FindForm();
            f.Controls.Remove(this);
             gs = new GameScreen();
            Form1.pauseReset = false;
            Form1.pauseMenu = false;

            gs.Size = new Size(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);
            int screenX = (Form1.screenWidth - gs.Width) / 2;
            int screenY = (Form1.screenHeight - gs.Height) / 2;
            gs.Location = new Point(screenX, screenY);
            //gs.Size = new Size(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);
            f.Controls.Add(gs);
            gs.Focus();
        }

        // Opening the settings menu
        private void SettingsButton_Click(object sender, EventArgs e)
        {
            Form f = this.FindForm();
            f.Controls.Remove(this);
            SettingScreen ss = new SettingScreen();
            ss.Location = new Point((Form1.screenWidth - ss.Width) / 2, (Form1.screenHeight - ss.Height) / 2);
            f.Controls.Add(ss);
            ss.Focus();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }
    }
}
