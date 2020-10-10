﻿using System;
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
            InitializeComponent();

            int score, eagle = 100, birdie = 110, par = 125, bogey = 140;

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
            gs.Location = new Point(Form1.gameScreenPositionX, Form1.gameScreenPositionY);
            f.Controls.Add(gs);
            gs.Focus();
        }
    }
}