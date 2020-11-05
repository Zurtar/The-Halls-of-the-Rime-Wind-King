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

        // Image Initialization
        /*
        Image characterSprite1 = Properties.Resources.Cobalt1;
        Image characterSprite2 = Properties.Resources.Cobalt2;
        Image characterSprite3 = Properties.Resources.Cobalt1;
        Image characterSprite4 = Properties.Resources.Cobalt2;
        Image characterSprite5 = Properties.Resources.Cobalt1;
        Image characterSprite6 = Properties.Resources.Cobalt2;
        Image characterSprite7 = Properties.Resources.Cobalt1;
        Image characterSprite8 = Properties.Resources.Cobalt2;
        Image characterSprite9 = Properties.Resources.Cobalt1;
        Image characterSprite10 = Properties.Resources.Cobalt2;
        Image characterSprite11 = Properties.Resources.Cobalt1;
        Image characterSprite12 = Properties.Resources.Cobalt2;
        */

        String characterType;
        Image characterSprite1;
        Image characterSprite2;
        
        Image enemyOne1 = Properties.Resources.Shambles_Sprite1;
        Image enemyOne2 = Properties.Resources.Shambles_Sprite2;
        Image enemyTwo1 = Properties.Resources.Skulk_Sprite1;
        Image enemyTwo2 = Properties.Resources.Skulk_Sprite2;
        Image enemyThree1 = Properties.Resources.Puppeteer_Sprite1;
        Image enemyThree2 = Properties.Resources.Puppeteer_Sprite2;
        Image enemyFour1 = Properties.Resources.Screecher_Sprite1;
        Image enemyFour2 = Properties.Resources.Screecher_Sprite2;
        Image enemyFive1 = Properties.Resources.Mimic_Sprite1;
        Image enemyFive2 = Properties.Resources.Mimic_Sprite2;
        Image trapSprite = Properties.Resources.Trap_Sprite;
        Image wallSprite = Properties.Resources.Wall_Sprite;

        // Idle animation toggle
        int idleMode = 1;

        // Enemy type randomizer
        Random randGen = new Random();

        // Sound Setup
        SoundPlayer buttonSound = new SoundPlayer(Properties.Resources.ButtonPress);

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
            }

            // Detection for menu buttons down
        }

        private void GameScreen_KeyUp(object sender, KeyEventArgs e)
        {
            // Detection for Joystick or buttons down
            switch (e.KeyCode)
            {
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
            }
            // Detection for menu buttons up
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
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
                }
                else if (grid[gridIndex].walled == true)
                {
                    movingUp = false;
                }
                else if (grid[gridIndex].trapped == true)
                {
                    movingUp = false;
                    dead = true;
                    buttonSound.Play();
                    buttonSound.Play();
                    buttonSound.Play();
                    loadLevel(currentLevel);
                    dead = false;
                    reloaded = true;
                }
                else if (grid[gridIndex].guarded == true)
                {
                    movingUp = false;

                    // Enemy Action lists

                    //search the list of enemies for an enemy at that grid position and then run the code for moving that enemy.

                    int enemyIndex = enemy.FindIndex(x => (x.xPos == knight.posX) && (x.yPos == knight.posY - 1)); // Finding Enemy Position
                    int enemyX = enemy[enemyIndex].xPos; // Tracking X Position
                    int enemyY = enemy[enemyIndex].yPos; // Tracking Y Position

                    if (grid[gridIndex].yPos != 1) // checking if enemy is at the side of the map
                    {
                        // Finding the grid space that the enemy is pushed into
                        gridIndex = grid.FindIndex(x => (x.xPos == enemy[enemyIndex].xPos) && (x.yPos == enemy[enemyIndex].yPos - 1));

                        // If the grid behind the enemy is walled or contains another enemy, It dosen't move.
                        if (grid[gridIndex].walled == true || grid[gridIndex].guarded == true)
                        {

                        }
                        // If the grid is trapped behind the enemy it dies
                        else if (grid[gridIndex].trapped == true)
                        {
                            enemy.RemoveAt(enemyIndex);
                            gridIndex = grid.FindIndex(x => (x.xPos == enemyX) && (x.yPos == enemyY));
                            grid[gridIndex].guarded = false;
                            buttonSound.Play();
                        }
                        else
                        { // Otherwise they are pushed into the space behind them

                            enemy[enemyIndex].yPos = enemy[enemyIndex].yPos - 1;
                            enemy[enemyIndex].x = grid[gridIndex].charScreenX;
                            enemy[enemyIndex].y = grid[gridIndex].charScreenY;

                            grid[gridIndex].guarded = true;
                            gridIndex = grid.FindIndex(x => (x.xPos == enemyX) && (x.yPos == enemyY));
                            grid[gridIndex].guarded = false;
                        }

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
                }
                else if (grid[gridIndex].walled == true)
                {
                    movingRight = false;
                }
                else if (grid[gridIndex].trapped == true)
                {
                    movingRight = false;
                    dead = true;
                    buttonSound.Play();
                    buttonSound.Play();
                    buttonSound.Play();
                    loadLevel(currentLevel);
                    dead = false;
                    reloaded = true;
                }
                else if (grid[gridIndex].guarded == true)
                {
                    movingRight = false;

                    // Enemy Action lists

                    //search the list of enemies for an enemy at that grid position and then run the code for moving that enemy.

                    int enemyIndex = enemy.FindIndex(x => (x.xPos == knight.posX + 1) && (x.yPos == knight.posY)); // Finding Enemy Position
                    int enemyX = enemy[enemyIndex].xPos; // Tracking X Position
                    int enemyY = enemy[enemyIndex].yPos; // Tracking Y Position

                    if (grid[gridIndex].xPos != 7) // checking if enemy is at the side of the map
                    {
                        // Finding the grid space that the enemy is pushed into
                        gridIndex = grid.FindIndex(x => (x.xPos == enemy[enemyIndex].xPos + 1) && (x.yPos == enemy[enemyIndex].yPos));

                        // If the grid behind the enemy is walled or contains another enemy, It dosen't move.
                        if (grid[gridIndex].walled == true || grid[gridIndex].guarded == true)
                        {

                        }
                        // If the grid is trapped behind the enemy it dies
                        else if (grid[gridIndex].trapped == true)
                        {
                            enemy.RemoveAt(enemyIndex);
                            gridIndex = grid.FindIndex(x => (x.xPos == enemyX) && (x.yPos == enemyY));
                            grid[gridIndex].guarded = false;
                            buttonSound.Play();
                        }
                        else
                        { // Otherwise they are pushed into the space behind them

                            enemy[enemyIndex].xPos = enemy[enemyIndex].xPos + 1;
                            enemy[enemyIndex].x = grid[gridIndex].charScreenX;
                            enemy[enemyIndex].y = grid[gridIndex].charScreenY;

                            grid[gridIndex].guarded = true;
                            gridIndex = grid.FindIndex(x => (x.xPos == enemyX) && (x.yPos == enemyY));
                            grid[gridIndex].guarded = false;
                        }

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
                }
                else if (grid[gridIndex].walled == true)
                {
                    movingDown = false;
                }
                else if (grid[gridIndex].trapped == true)
                {
                    movingDown = false;
                    dead = true;
                    buttonSound.Play();
                    buttonSound.Play();
                    buttonSound.Play();
                    loadLevel(currentLevel);
                    dead = false;
                    reloaded = true;
                }
                else if (grid[gridIndex].guarded == true)
                {
                    movingDown = false;

                    // Enemy Action lists

                    //search the list of enemies for an enemy at that grid position and then run the code for moving that enemy.

                    int enemyIndex = enemy.FindIndex(x => (x.xPos == knight.posX) && (x.yPos == knight.posY + 1)); // Finding Enemy Position
                    int enemyX = enemy[enemyIndex].xPos; // Tracking X Position
                    int enemyY = enemy[enemyIndex].yPos; // Tracking Y Position

                    if (grid[gridIndex].yPos != 7) // checking if enemy is at the side of the map
                    {
                        // Finding the grid space that the enemy is pushed into
                        gridIndex = grid.FindIndex(x => (x.xPos == enemy[enemyIndex].xPos) && (x.yPos == enemy[enemyIndex].yPos + 1));

                        // If the grid behind the enemy is walled or contains another enemy, It dosen't move.
                        if (grid[gridIndex].walled == true || grid[gridIndex].guarded == true)
                        {

                        }
                        // If the grid is trapped behind the enemy it dies
                        else if (grid[gridIndex].trapped == true)
                        {
                            enemy.RemoveAt(enemyIndex);
                            gridIndex = grid.FindIndex(x => (x.xPos == enemyX) && (x.yPos == enemyY));
                            grid[gridIndex].guarded = false;
                            buttonSound.Play();
                        }
                        else
                        { // Otherwise they are pushed into the space behind them

                            enemy[enemyIndex].yPos = enemy[enemyIndex].yPos + 1;
                            enemy[enemyIndex].x = grid[gridIndex].charScreenX;
                            enemy[enemyIndex].y = grid[gridIndex].charScreenY;

                            grid[gridIndex].guarded = true;
                            gridIndex = grid.FindIndex(x => (x.xPos == enemyX) && (x.yPos == enemyY));
                            grid[gridIndex].guarded = false;
                        }

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
                }
                else if (grid[gridIndex].walled == true)
                {
                    movingLeft = false;
                }
                else if (grid[gridIndex].trapped == true)
                {
                    movingLeft = false;
                    dead = true;
                    buttonSound.Play();
                    buttonSound.Play();
                    buttonSound.Play();
                    loadLevel(currentLevel);
                    dead = false;
                    reloaded = true;
                }
                else if (grid[gridIndex].guarded == true)
                {
                    movingLeft = false;

                    // Enemy Action lists

                    //search the list of enemies for an enemy at that grid position and then run the code for moving that enemy.

                    int enemyIndex = enemy.FindIndex(x => (x.xPos == knight.posX - 1) && (x.yPos == knight.posY)); // Finding Enemy Position
                    int enemyX = enemy[enemyIndex].xPos; // Tracking X Position
                    int enemyY = enemy[enemyIndex].yPos; // Tracking Y Position

                    if (grid[gridIndex].xPos != 1) // checking if enemy is at the side of the map
                    {
                        // Finding the grid space that the enemy is pushed into
                        gridIndex = grid.FindIndex(x => (x.xPos == enemy[enemyIndex].xPos - 1) && (x.yPos == enemy[enemyIndex].yPos));

                        // If the grid behind the enemy is walled or contains another enemy, It dosen't move.
                        if (grid[gridIndex].walled == true || grid[gridIndex].guarded == true)
                        {

                        }
                        // If the grid is trapped behind the enemy it dies
                        else if (grid[gridIndex].trapped == true)
                        {
                            enemy.RemoveAt(enemyIndex);
                            gridIndex = grid.FindIndex(x => (x.xPos == enemyX) && (x.yPos == enemyY));
                            grid[gridIndex].guarded = false;
                            buttonSound.Play();
                        }
                        else
                        { // Otherwise they are pushed into the space behind them

                            enemy[enemyIndex].xPos = enemy[enemyIndex].xPos - 1;
                            enemy[enemyIndex].x = grid[gridIndex].charScreenX;
                            enemy[enemyIndex].y = grid[gridIndex].charScreenY;

                            grid[gridIndex].guarded = true;
                            gridIndex = grid.FindIndex(x => (x.xPos == enemyX) && (x.yPos == enemyY));
                            grid[gridIndex].guarded = false;
                        }

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
                buttonSound.Play();
                loadLevel(currentLevel);
                dead = false;
                reloaded = true;
                levelMoves = 0;
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
    }
}