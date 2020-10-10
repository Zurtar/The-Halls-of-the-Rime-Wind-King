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
        public MainMenu()
        {
            InitializeComponent();
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            // Loading the main Game Screen
            Form f = this.FindForm();
            f.Controls.Remove(this);
            GameScreen gs = new GameScreen();
            Form1.gameScreenPositionX = (this.Width - gs.Width) / 2;
            Form1.gameScreenPositionY = (this.Height - gs.Height) / 2;
            gs.Location = new Point(Form1.gameScreenPositionX, Form1.gameScreenPositionY);
            f.Controls.Add(gs);
            gs.Focus();
        }

    }
}
