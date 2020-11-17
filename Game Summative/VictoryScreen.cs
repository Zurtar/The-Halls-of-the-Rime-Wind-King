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
    public partial class VictoryScreen : UserControl
    {
        public VictoryScreen()
        {
            Cursor.Show();

            InitializeComponent();

            // Least possible moves is 700 (I think)
            int score, eagle = 750, birdie = 1000, par = 1500, bogey = 3000;

            score = Form1.moves;

            if(score > bogey) // Double Bogey
            {
                parOutput.Text = "Double Bogey :(";
                scoreOutput.Text = "You made " + score + " moves!";
                int improvement = score - bogey;
                motivationOutput.Text = "Make " + improvement + " less moves for bogey!";

            }
            else if (score > par) // Bogey
            {
                parOutput.Text = "Bogey";
                scoreOutput.Text = "You made " + score + " moves!";
                int improvement = score - par;
                motivationOutput.Text = "Make " + improvement + " less moves for par!";
            }
            else if (score > birdie) // Par
            {
                parOutput.Text = "Par";
                scoreOutput.Text = "You made " + score + " moves!";
                int improvement = score - birdie;
                motivationOutput.Text = "Make " + improvement + " less moves for a birdie!";
            }
            else if (score > eagle) // Birdie
            {
                parOutput.Text = "Birdie!";
                scoreOutput.Text = "You made " + score + " moves!";
                int improvement = score - eagle;
                motivationOutput.Text = "Make " + improvement + " less moves for an eagle!";
            }
            else // Eagle
            {
                parOutput.Text = "E a g l e";
                scoreOutput.Text = "You made " + score + " moves!";
                motivationOutput.Text = "Poggers";
            }

        }

        private void ReplayButton_Click(object sender, EventArgs e)
        {
            // Loading the main Game Screen
            Form f = this.FindForm();
            f.Controls.Remove(this);
            GameScreen gs = new GameScreen();

            gs.Size = new Size(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);
            int screenX = (Form1.screenWidth - gs.Width) / 2;
            int screenY = (Form1.screenHeight - gs.Height) / 2;
            gs.Location = new Point(screenX, screenY);
            //gs.Size = new Size(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);
            f.Controls.Add(gs);
            gs.Focus();
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
    }
}
