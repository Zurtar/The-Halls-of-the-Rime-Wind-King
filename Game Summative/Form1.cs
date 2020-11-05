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
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;

        }

        public static int screenWidth = Screen.PrimaryScreen.WorkingArea.Width;
        public static int screenHeight = Screen.PrimaryScreen.WorkingArea.Height;

        public static string characterSprite;

        public static int moves;

        private void Form1_Load(object sender, EventArgs e)
        {
            // Character Sprite easter egg
            characterSprite = "Cobalt";

            // Initializing the main menu
            MainMenu mm = new MainMenu();
            this.Controls.Add(mm);
            mm.Location = new Point((screenWidth - mm.Width) / 2, (screenHeight - mm.Height) / 2);
        }
    }
}
