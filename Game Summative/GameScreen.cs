using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace Game_Summative
{
    public partial class GameScreen : UserControl
    {
        #region initialization

        // Creating the character and corresponding rectangle, and starting position of the character.
        Character knight;
        RectangleF knightBox;
        int startX = 3, startY = 2;
        int currentLevel = 1;

        // Initialize the movement key booleans.
        bool upDown, leftDown, downDown, rightDown, resetdown, pauseDown;

        // boolean to prevent accidental movement by requiring a new keypress before initializing movement
        bool keyPress = false;

        // Set up the black and white brushes for colouring the grid in.
        SolidBrush gridLineBrush = new SolidBrush(Color.Black);
        SolidBrush gridSpaceBrush = new SolidBrush(Color.MidnightBlue);

        // Character sprite initialization
        String characterType;
        Image characterSprite1;
        Image characterSprite2;

        // Obstacle sprite initialization
        Image enemyOne1 = Properties.Resources.Shambles_Sprite1; // Shambles 
        Image enemyOne2 = Properties.Resources.Shambles_Sprite2;
        Image enemyTwo1 = Properties.Resources.Skulk_Sprite1; // Skulk
        Image enemyTwo2 = Properties.Resources.Skulk_Sprite2;
        Image enemyThree1 = Properties.Resources.Puppeteer_Sprite1; // Puppeteer
        Image enemyThree2 = Properties.Resources.Puppeteer_Sprite2;
        Image enemyFour1 = Properties.Resources.Screecher_Sprite1; // Screecher
        Image enemyFour2 = Properties.Resources.Screecher_Sprite2;
        Image enemyFive1 = Properties.Resources.Mimic_Sprite1; // Mimic
        Image enemyFive2 = Properties.Resources.Mimic_Sprite2;
        Image trapSprite = Properties.Resources.Trap_Sprite; // Trap
        Image wallSprite = Properties.Resources.Wall_Sprite; // Wall

        // Idle animation toggle
        int idleMode = 1;

        // Enemy type randomizer
        Random randGen = new Random();

        // Sound Setup
        SoundPlayer buttonSound = new SoundPlayer(Properties.Resources.ButtonPress);
        SoundPlayer collisionSound = new SoundPlayer(Properties.Resources.CollisionBap);
        SoundPlayer deathSound = new SoundPlayer(Properties.Resources.DeathSound);

        // Grid Setup
        float gridSize, squareSize, lineSize, charSize;

        // List of every grid space
        List<Grid> grid = new List<Grid>();
        int gridIndex;

        // List of every enemy
        List<Enemy> enemy = new List<Enemy>();

        // Setup for the movement locks
        bool movingUp, movingRight, movingDown, movingLeft;


        bool reloaded = false;
        // Detect when the player runs into traps
        bool dead = false;

        // Score and move integers
        int levelMoves;

        #endregion

        public GameScreen()
        {
            InitializeComponent();
            // Hiding Cursor
            Cursor.Hide();

            //Resetting the move count
            Form1.moves = 0;

            // setting the size of the grid, grid squares, and the lines.
            gridSize = (float)(this.Height * .9);
            squareSize = (gridSize / 8);
            lineSize = (squareSize / 8);
            charSize = squareSize * (float)0.75;

            // Calculate the position of each gridspace and create a list containing every grid space and it's position on the screen.
            for (int y = 1; y < 8; y++)
            {
                for (int x = 1; x < 8; x++)
                {
                    float screenX = (((x - 1) * (squareSize + lineSize)) + lineSize + ((Form1.screenWidth - gridSize) / 2));
                    float screenY = (((y - 1) * (squareSize + lineSize)) + lineSize + ((Form1.screenHeight - gridSize) / 2));
                    float charScreenX = screenX + ((squareSize - charSize) / 2);
                    float charScreenY = screenY + ((squareSize - charSize) / 2);
                    Grid newGrid = new Grid(x, y, screenX, screenY, charScreenX, charScreenY, squareSize, false, false, false);
                    grid.Add(newGrid);
                }
            }

            // Finding which grid correlates to the starting position
            gridIndex = grid.FindIndex(x => (x.xPos == startX) && (x.yPos == startY));

            // Placing the character's position on the grid
            float charXPos = grid[gridIndex].charScreenX;
            float charYPos = grid[gridIndex].charScreenY;

            // Creating new player character class.
            knight = new Character(startX, startY, charSize, charXPos, charYPos);

            // Setting the knightBox rectangle size and co ordinates to the knight character class.
            knightBox.X = knight.x;
            knightBox.Y = knight.y;
            knightBox.Width = knight.characterSize;
            knightBox.Height = knight.characterSize;

            // Character sprite initialization
            characterType = "Resources/" + Form1.characterSprite + "1.png";
            characterSprite1 = Image.FromFile(characterType);
            characterType = "Resources/" + Form1.characterSprite + "2.png";
            characterSprite2 = Image.FromFile(characterType);

            // Enabling the timer function upon initialization
            mainTimer.Enabled = true;

            loadLevel(currentLevel);
        }

        private void GameScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            // Detection for Joystick or buttons down
            switch (e.KeyCode)
            {
                // Keyboard movement
                case Keys.W:
                    upDown = true;
                    reloaded = false;
                    break;
                case Keys.A:
                    leftDown = true;
                    reloaded = false;
                    break;
                case Keys.S:
                    downDown = true;
                    reloaded = false;
                    break;
                case Keys.D:
                    rightDown = true;
                    reloaded = false;
                    break;

                // Arcade movement
                case Keys.B:
                    upDown = true;
                    reloaded = false;
                    break;
                case Keys.N:
                    leftDown = true;
                    reloaded = false;
                    break;
                case Keys.M:
                    downDown = true;
                    reloaded = false;
                    break;
                case Keys.Space:
                    rightDown = true;
                    reloaded = false;
                    break;

                // Reset
                case Keys.R:
                    resetdown = true;
                    break;
                case Keys.Up:
                    resetdown = true;
                    break;
                case Keys.Right:
                    resetdown = true;
                    break;
                case Keys.Down:
                    resetdown = true;
                    break;
                case Keys.Left:
                    resetdown = true;
                    break;

                // Pause
                case Keys.Escape:
                    pauseDown = true;
                    break;
            }

            // Detection for menu buttons down
        }

        private void GameScreen_KeyUp(object sender, KeyEventArgs e)
        {
            // Detection for Joystick or buttons down
            switch (e.KeyCode)
            {
                // Keyboard movement
                case Keys.W:
                    upDown = false;
                    keyPress = false;
                    break;
                case Keys.A:
                    leftDown = false;
                    keyPress = false;
                    break;
                case Keys.S:
                    downDown = false;
                    keyPress = false;
                    break;
                case Keys.D:
                    rightDown = false;
                    keyPress = false;
                    break;

                // Arcade movement
                case Keys.B:
                    upDown = false;
                    keyPress = false;
                    break;
                case Keys.N:
                    leftDown = false;
                    keyPress = false;
                    break;
                case Keys.M:
                    downDown = false;
                    keyPress = false;
                    break;
                case Keys.Space:
                    rightDown = false;
                    keyPress = false;
                    break;

                // Reset
                case Keys.R:
                    resetdown = false;
                    keyPress = false;
                    break;
                case Keys.Up:
                    resetdown = false;
                    break;
                case Keys.Right:
                    resetdown = false;
                    break;
                case Keys.Down:
                    resetdown = false;
                    break;
                case Keys.Left:
                    resetdown = false;
                    break;

                // Pause
                case Keys.Escape:
                    pauseDown = true;
                    break;
            }
            // Detection for menu buttons up
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            // Pause menu reset function
            if (Form1.pauseReset == true)
            {
                levelReset();
                Form1.pauseReset = false;
            }
            // Pause menu main menu function
            if (Form1.pauseMenu == true)
            {
                Form1.pauseMenu = false;

                Form f = this.FindForm();
                f.Controls.Remove(this);
                MainMenu mm = new MainMenu();
                mm.Location = new Point((Form1.screenWidth - mm.Width) / 2, (Form1.screenHeight - mm.Height) / 2);
                f.Controls.Add(mm);
                mm.Focus();
            }

            idleMode++;

            if (idleMode == 15)
            {
                idleMode = -15;
            }

            // Updating rectangle position.
            knightBox.X = knight.x;
            knightBox.Y = knight.y;

            if (movingUp == false && movingRight == false && movingDown == false && movingLeft == false && keyPress == false && dead == false)
            {
                // Tracking the number of moves for scoring

                // knight.x = knight.x + 1; // Test for movement fuctionality.
                if (upDown == true && knight.posY != 1) // Character upwards movement lock
                {
                    movingUp = true;
                    keyPress = true;
                    Form1.moves++;
                }
                if (rightDown == true && knight.posX != 7) // Character right movement lock
                {
                    movingRight = true;
                    keyPress = true;
                    Form1.moves++;
                }
                if (downDown == true && knight.posY != 7) // Character downwards movement lock
                {
                    movingDown = true;
                    keyPress = true;
                    Form1.moves++;
                }
                if (leftDown == true && knight.posX != 1) // Character left movement lock
                {
                    movingLeft = true;
                    keyPress = true;
                    Form1.moves++;
                }
            }

            #region Moving Up

            if (movingUp == true)
            {
                movingRight = false;
                movingDown = false;
                movingLeft = false;

                int gridIndex = grid.FindIndex(x => (x.xPos == knight.posX) && (x.yPos == knight.posY - 1));

                if (knight.posY == 1)
                {
                    movingUp = false;
                    collisionSound.Play();
                }
                else if (grid[gridIndex].walled == true)
                {
                    movingUp = false;
                    collisionSound.Play();
                }
                else if (grid[gridIndex].trapped == true)
                {
                    movingUp = false;
                    deathMethod();
                }
                else if (grid[gridIndex].guarded == true)
                {
                    movingUp = false;
                    collisionSound.Play();

                    if (knight.posY == 2)
                    {
                        collisionSound.Play();
                    }
                    else
                    {
                        // Enemy Action lists

                        //search the list of enemies for an enemy at that grid position and then run the code for moving that enemy.

                        int enemyIndex = enemy.FindIndex(x => (x.xPos == knight.posX) && (x.yPos == knight.posY - 1)); // Finding Enemy Position
                        int enemyX = enemy[enemyIndex].xPos; // Tracking X Position
                        int enemyY = enemy[enemyIndex].yPos; // Tracking Y Position
                        int gridOld = grid.FindIndex(x => (x.xPos == knight.posX) && (x.yPos == knight.posY - 1));
                        int gridNew = grid.FindIndex(x => (x.xPos == knight.posX) && (x.yPos == knight.posY - 2));

                        enemyCollide(enemyIndex, gridOld, gridNew);
                    }
                }
                else
                {
                    float newPosY = grid[gridIndex].charScreenY;
                    float newPosX = grid[gridIndex].charScreenX;
                    int newX = grid[gridIndex].xPos;
                    int newY = grid[gridIndex].yPos;

                    knight.moveChar(newPosX, newPosY, newX, newY);
                }
            }

            #endregion

            #region Moving Right

            if (movingRight == true)
            {

                movingUp = false;
                movingDown = false;
                movingLeft = false;

                int gridIndex = grid.FindIndex(x => (x.xPos == knight.posX + 1) && (x.yPos == knight.posY));

                if (knight.posX == 7)
                {
                    movingRight = false;
                    collisionSound.Play();
                }
                else if (grid[gridIndex].walled == true)
                {
                    movingRight = false;
                    collisionSound.Play();
                }
                else if (grid[gridIndex].trapped == true)
                {
                    movingRight = false;
                    deathMethod();
                }
                else if (grid[gridIndex].guarded == true)
                {
                    movingRight = false;

                    // Enemy Action lists

                    //search the list of enemies for an enemy at that grid position and then run the code for moving that enemy.
                    if (knight.posX == 6)
                    {
                        collisionSound.Play();
                    }
                    else
                    {
                        int enemyIndex = enemy.FindIndex(x => (x.xPos == knight.posX + 1) && (x.yPos == knight.posY)); // Finding Enemy Position
                        int enemyX = enemy[enemyIndex].xPos; // Tracking X Position
                        int enemyY = enemy[enemyIndex].yPos; // Tracking Y Position
                        int gridOld = grid.FindIndex(x => (x.xPos == knight.posX + 1) && (x.yPos == knight.posY));
                        int gridNew = grid.FindIndex(x => (x.xPos == knight.posX + 2) && (x.yPos == knight.posY));

                        enemyCollide(enemyIndex, gridOld, gridNew);
                    }
                }
                else
                {
                    float newPosY = grid[gridIndex].charScreenY;
                    float newPosX = grid[gridIndex].charScreenX;
                    int newX = grid[gridIndex].xPos;
                    int newY = grid[gridIndex].yPos;

                    knight.moveChar(newPosX, newPosY, newX, newY);

                }
            }

            #endregion

            #region Moving Down

            if (movingDown == true)
            {
                movingUp = false;
                movingRight = false;
                movingLeft = false;

                int gridIndex = grid.FindIndex(x => (x.xPos == knight.posX) && (x.yPos == knight.posY + 1));

                if (knight.posY == 7)
                {
                    movingDown = false;
                    collisionSound.Play();
                }
                else if (grid[gridIndex].walled == true)
                {
                    movingDown = false;
                    collisionSound.Play();
                }
                else if (grid[gridIndex].trapped == true)
                {
                    movingDown = false;
                    deathMethod();
                }
                else if (grid[gridIndex].guarded == true)
                {
                    movingDown = false;

                    // Enemy Action lists

                    //search the list of enemies for an enemy at that grid position and then run the code for moving that enemy.

                    if (knight.posY == 6)
                    {
                        collisionSound.Play();
                    }
                    else
                    {
                        int enemyIndex = enemy.FindIndex(x => (x.xPos == knight.posX) && (x.yPos == knight.posY + 1)); // Finding Enemy Position
                        int enemyX = enemy[enemyIndex].xPos; // Tracking X Position
                        int enemyY = enemy[enemyIndex].yPos; // Tracking Y Position
                        int gridOld = grid.FindIndex(x => (x.xPos == knight.posX) && (x.yPos == knight.posY + 1));
                        int gridNew = grid.FindIndex(x => (x.xPos == knight.posX) && (x.yPos == knight.posY + 2));

                        enemyCollide(enemyIndex, gridOld, gridNew);
                    }
                }
                else
                {
                    float newPosY = grid[gridIndex].charScreenY;
                    float newPosX = grid[gridIndex].charScreenX;
                    int newX = grid[gridIndex].xPos;
                    int newY = grid[gridIndex].yPos;

                    knight.moveChar(newPosX, newPosY, newX, newY);

                }
            }

            #endregion

            #region Moving Left

            if (movingLeft == true)
            {

                movingUp = false;
                movingRight = false;
                movingDown = false;

                int gridIndex = grid.FindIndex(x => (x.xPos == knight.posX - 1) && (x.yPos == knight.posY));

                if (knight.posX == 1)
                {
                    movingLeft = false;
                    collisionSound.Play();
                }
                else if (grid[gridIndex].walled == true)
                {
                    movingLeft = false;
                    collisionSound.Play();
                }
                else if (grid[gridIndex].trapped == true)
                {
                    movingLeft = false;
                    deathMethod();
                }
                else if (grid[gridIndex].guarded == true)
                {
                    movingLeft = false;

                    // Enemy Action lists

                    //search the list of enemies for an enemy at that grid position and then run the code for moving that enemy.

                    if (knight.posX == 2)
                    {
                        collisionSound.Play();
                    }
                    else
                    {
                        int enemyIndex = enemy.FindIndex(x => (x.xPos == knight.posX - 1) && (x.yPos == knight.posY)); // Finding Enemy Position
                        int enemyX = enemy[enemyIndex].xPos; // Tracking X Position
                        int enemyY = enemy[enemyIndex].yPos; // Tracking Y Position
                        int gridOld = grid.FindIndex(x => (x.xPos == knight.posX - 1) && (x.yPos == knight.posY));
                        int gridNew = grid.FindIndex(x => (x.xPos == knight.posX - 2) && (x.yPos == knight.posY));

                        enemyCollide(enemyIndex, gridOld, gridNew);
                    }
                }
                else
                {
                    float newPosY = grid[gridIndex].charScreenY;
                    float newPosX = grid[gridIndex].charScreenX;
                    int newX = grid[gridIndex].xPos;
                    int newY = grid[gridIndex].yPos;

                    knight.moveChar(newPosX, newPosY, newX, newY);

                }
            }

            #endregion

            // Checking for cleared level

            List<Grid> levelWinCheck = grid.FindAll(x => x.guarded == true);

            if (levelWinCheck.Count() == 0) // Level Loader
            {
                Form1.moves = Form1.moves + levelMoves;
                levelMoves = 0;
                currentLevel++;
                if (currentLevel == 20) // 1+ the number of levels to loop level gameplay
                {
                    // Loading the victory screen
                    Form f = this.FindForm();
                    f.Controls.Remove(this);
                    VictoryScreen vs = new VictoryScreen();
                    vs.Location = new Point((Form1.screenWidth - vs.Width) / 2, (Form1.screenHeight - vs.Height) / 2);

                    f.Controls.Add(vs);
                    vs.Focus();
                }

                loadLevel(currentLevel);

            }

            if (resetdown == true && keyPress == false && reloaded == false)
            {
                levelReset();
            }

            // Pause Menu
            if (pauseDown == true && keyPress == false && reloaded == false)
            {
                pauseDown = false;
                buttonSound.Play();
                reloaded = true;

                Form f = this.FindForm();
                //f.Controls.Remove(this);
                PauseMenu pm = new PauseMenu();
                int screenX = (Form1.screenWidth - pm.Width) / 2;
                int screenY = (Form1.screenHeight - pm.Height) / 2;
                pm.Location = new Point(screenX, screenY);
                f.Controls.Add(pm);
                pm.Focus();
                pm.BringToFront();

            }

            Refresh();
        }

        private void GameScreen_Paint(object sender, PaintEventArgs e)
        {
            // Setting the background grid background
            e.Graphics.FillRectangle(gridLineBrush, ((this.Width - gridSize) / 2), ((this.Height - gridSize) / 2), gridSize, gridSize);

            // Colouring each grid space
            foreach (Grid g in grid)
            {
                if (g.trapped == true) // Traps
                {
                    e.Graphics.FillRectangle(gridSpaceBrush, g.screenX, g.screenY, g.squareSize, g.squareSize);
                    e.Graphics.DrawImage(trapSprite, g.screenX, g.screenY, g.squareSize, g.squareSize);
                }
                else if (g.walled == true) // Walls
                {
                    e.Graphics.DrawImage(wallSprite, g.screenX, g.screenY, g.squareSize, g.squareSize);
                }
                else // Empty
                {
                    e.Graphics.FillRectangle(gridSpaceBrush, g.screenX, g.screenY, g.squareSize, g.squareSize);
                }
            }

            if (idleMode >= 1)
            {
                foreach (Enemy n in enemy) // Enemies
                {
                    if (n.type == 1)
                    {

                        e.Graphics.DrawImage(enemyOne1, n.x, n.y, n.enemySize, n.enemySize);
                    }
                    else if (n.type == 2)
                    {

                        e.Graphics.DrawImage(enemyTwo1, n.x, n.y, n.enemySize, n.enemySize);
                    }
                    else if (n.type == 3)
                    {

                        e.Graphics.DrawImage(enemyThree1, n.x, n.y, n.enemySize, n.enemySize);
                    }
                    else if (n.type == 4)
                    {

                        e.Graphics.DrawImage(enemyFour1, n.x, n.y, n.enemySize, n.enemySize);
                    }
                    else
                    {

                        e.Graphics.DrawImage(enemyFive1, n.x, n.y, n.enemySize, n.enemySize);
                    }
                }
            }
            else
            {
                foreach (Enemy n in enemy) // Enemies
                {
                    if (n.type == 1)
                    {

                        e.Graphics.DrawImage(enemyOne2, n.x, n.y, n.enemySize, n.enemySize);
                    }
                    else if (n.type == 2)
                    {

                        e.Graphics.DrawImage(enemyTwo2, n.x, n.y, n.enemySize, n.enemySize);
                    }
                    else if (n.type == 3)
                    {

                        e.Graphics.DrawImage(enemyThree2, n.x, n.y, n.enemySize, n.enemySize);
                    }
                    else if (n.type == 4)
                    {

                        e.Graphics.DrawImage(enemyFour2, n.x, n.y, n.enemySize, n.enemySize);
                    }
                    else
                    {

                        e.Graphics.DrawImage(enemyFive2, n.x, n.y, n.enemySize, n.enemySize);
                    }
                }
            }

            // Colouring the player character
            if (idleMode >= 1)
            {
                e.Graphics.DrawImage(characterSprite1, knightBox);
            }
            else
            {
                e.Graphics.DrawImage(characterSprite2, knightBox);
            }
        }

        public void levelReset()
        {
            buttonSound.Play();
            loadLevel(currentLevel);
            dead = false;
            reloaded = true;
            levelMoves = 0;
        }

        private void loadLevel(int level)
        {
            Bitmap myBitmap;
            // Level Reset Code
            foreach (Grid g in grid)
            {
                g.guarded = false;
                g.trapped = false;
                g.walled = false;
            }
            while (enemy.Count() != 0)
            {
                enemy.RemoveAt(0);
            }
            // Create a Bitmap object from an image file.

            string levelFile = "Resources/level" + level + ".png";

            try
            {
                myBitmap = new Bitmap(levelFile);
                for (int y = 1; y < 8; y++)
                {
                    for (int x = 1; x < 8; x++)
                    {
                        // Get the color of a pixel within myBitmap
                        Color pixelColour = myBitmap.GetPixel(x - 1, y - 1);

                        int red = pixelColour.R;
                        int green = pixelColour.G;
                        int blue = pixelColour.B;

                        if (red <= 20 && green <= 20 && blue <= 20) // Nothing Placement
                        {
                            // Empty Space
                        }
                        else if (red > green && red > blue) // Trap Placement
                        {
                            gridIndex = grid.FindIndex(g => (g.xPos == x) && (g.yPos == y));
                            grid[gridIndex].trapped = true;
                        }
                        else if (green > red && green > blue) // Enemy Placement
                        {

                            gridIndex = grid.FindIndex(g => (g.xPos == x) && (g.yPos == y));
                            float enemyXPos = grid[gridIndex].charScreenX;
                            float enemyYPos = grid[gridIndex].charScreenY;
                            Enemy newEnemy = new Enemy(x, y, charSize, enemyXPos, enemyYPos, randGen.Next(1, 6));
                            enemy.Add(newEnemy);
                            grid[gridIndex].guarded = true;
                        }
                        else if (blue > red && blue > green) // Character Placement
                        {
                            gridIndex = grid.FindIndex(g => (g.xPos == x) && (g.yPos == y));
                            knight.posX = x;
                            knight.posY = y;
                            knight.x = grid[gridIndex].charScreenX;
                            knight.y = grid[gridIndex].charScreenY;
                        }
                        else // Wall placement
                        {
                            gridIndex = grid.FindIndex(g => (g.xPos == x) && (g.yPos == y));
                            grid[gridIndex].walled = true;
                        }
                    } //End of X for statement
                } //End of y for statement
            }
            catch
            {
                // Boss fight room
            }

        }

        public void enemyCollide(int enemyPos, int oldPos, int newPos)
        {
            int enemyX = enemy[enemyPos].xPos; // Tracking X Position
            int enemyY = enemy[enemyPos].yPos; // Tracking Y Position

            // If the grid behind the enemy is walled or contains another enemy, It dosen't move.
            if (grid[newPos].walled == true || grid[newPos].guarded == true)
            {
                //collisionSound.Play();
            }
            // If the grid is trapped behind the enemy it dies
            else if (grid[newPos].trapped == true)
            {
                enemy.RemoveAt(enemyPos);
                newPos = grid.FindIndex(x => (x.xPos == enemyX) && (x.yPos == enemyY));
                grid[oldPos].guarded = false;
                buttonSound.Play();
            }
            else
            { // Otherwise they are pushed into the space behind them

                enemy[enemyPos].xPos = grid[newPos].xPos;
                enemy[enemyPos].yPos = grid[newPos].yPos;
                enemy[enemyPos].x = grid[newPos].charScreenX;
                enemy[enemyPos].y = grid[newPos].charScreenY;

                grid[newPos].guarded = true;
                grid[oldPos].guarded = false;
            }
        }

        public void deathMethod() // Player Death Method
        {
            dead = true;
            deathSound.Play();
            loadLevel(currentLevel);
            dead = false;
            reloaded = true;
        }
    }
}