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
    public partial class PauseMenu : UserControl
    {
        public PauseMenu()
        {
            InitializeComponent();
        }
         // Code for exiting game
        private void ExitButton_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        // Code for resuming gameplay
        private void ResumeButton_Click(object sender, EventArgs e)
        {
            Form f = this.FindForm();
            f.Controls.Remove(this);
            Cursor.Hide();
        }

        // Code for resetting the level
        private void ResetButton_Click(object sender, EventArgs e)
        {
            Form f = this.FindForm();
            f.Controls.Remove(this);
            Form1.pauseReset = true;
            Cursor.Hide();
        }

        // Code for returning to the main menu
        private void MainmenuButton_Click(object sender, EventArgs e)
        {
            Form1.pauseMenu = true;
            Form f = this.FindForm();
            f.Controls.Remove(this);
        }
    }
}
