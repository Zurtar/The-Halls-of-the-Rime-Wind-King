using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game_Summative
{
    public partial class Form1 : Form
    {

        //static global float gameScreenPosition;

        public Form1()
        {
            InitializeComponent();
        }

         public static int gameScreenPositionX;
         public static int gameScreenPositionY;

         public static int moves;

        private void Form1_Load(object sender, EventArgs e)
        {
            // Initializing the main menu
            MainMenu mm = new MainMenu();
            this.Controls.Add(mm);
            mm.Location = new Point((this.Width - mm.Width) / 2, (this.Height - mm.Height) / 2);
        }
    }
}
