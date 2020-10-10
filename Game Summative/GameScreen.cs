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
        bool upDown, leftDown, downDown, rightDown, spaceDown;

        // boolean to prevent accidental movement by requiring a new keypress before initializing movement
        bool keyPress = false;

        // Set up the black and white brushes for colouring the grid in.
        SolidBrush gridLineBrush = new SolidBrush(Color.White);
        SolidBrush gridSpaceBrush = new SolidBrush(Color.Black);
        SolidBrush characterBrush = new SolidBrush(Color.Blue);
        SolidBrush trapBrush = new SolidBrush(Color.Red);
        SolidBrush enemyBrush = new SolidBrush(Color.Green);
        SolidBrush wallBrush = new SolidBrush(Color.Gray);

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
            for (int n = 1; n < 8; n++)
            {
                for (int i = 1; i < 8; i++)
                {
                    float screenX = (((i - 1) * (squareSize + lineSize)) + lineSize + ((this.Width - gridSize) / 2));
                    float screenY = (((n - 1) * (squareSize + lineSize)) + lineSize + ((this.Height - gridSize) / 2));
                    float charScreenX = screenX + ((squareSize - charSize) / 2);
                    float charScreenY = screenY + ((squareSize - charSize) / 2);
                    Grid newGrid = new Grid(i, n, screenX, screenY, charScreenX, charScreenY, squareSize, false, false, false);
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

            // Enabling the timer function upon initialization
            timer1.Enabled = true;

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

                case Keys.V:
                    upDown = true;
                    reloaded = false;
                    break;
                case Keys.C:
                    leftDown = true;
                    reloaded = false;
                    break;
                case Keys.Z:
                    downDown = true;
                    reloaded = false;
                    break;
                case Keys.X:
                    rightDown = true;
                    reloaded = false;
                    break;

                case Keys.Space:
                    spaceDown = true;
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

                case Keys.V:
                    upDown = false;
                    keyPress = false;
                    break;
                case Keys.C:
                    leftDown = false;
                    keyPress = false;
                    break;
                case Keys.Z:
                    downDown = false;
                    keyPress = false;
                    break;
                case Keys.X:
                    rightDown = false;
                    keyPress = false;
                    break;

                case Keys.Space:
                    spaceDown = false;
                    keyPress = false;
                    break;
            }
            // Detection for menu buttons up
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
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
                if (currentLevel == 5) // 1+ the number of levels to loop level gameplay
                {
                    // Loading the victory screen
                    Form f = this.FindForm();
                    f.Controls.Remove(this);
                    VictoryScreen vs = new VictoryScreen();
                    vs.Location = new Point((this.Width - vs.Width) / 2, (this.Height - vs.Height) / 2);
                    f.Controls.Add(vs);
                    vs.Focus();
                }

                loadLevel(currentLevel);

            }

            if (spaceDown == true && keyPress == false && reloaded == false)
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
                if (g.trapped == true)
                {
                    e.Graphics.FillRectangle(trapBrush, g.screenX, g.screenY, g.squareSize, g.squareSize);
                }
                else if (g.walled == true)
                {
                    e.Graphics.FillRectangle(wallBrush, g.screenX, g.screenY, g.squareSize, g.squareSize);
                }
                else
                {
                    e.Graphics.FillRectangle(gridSpaceBrush, g.screenX, g.screenY, g.squareSize, g.squareSize);
                }
            }

            foreach (Enemy n in enemy)
            {
                e.Graphics.FillRectangle(enemyBrush, n.x, n.y, n.enemySize, n.enemySize);
            }

            // Colouring the player character
            e.Graphics.FillRectangle(characterBrush, knightBox);

        }

        private void loadLevel(int level)
        {
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


            if (level == 1)
            {

                // Player Spawn Code
                gridIndex = grid.FindIndex(x => (x.xPos == 3) && (x.yPos == 2));

                knight.posX = 3;
                knight.posY = 2;
                knight.x = grid[gridIndex].charScreenX;
                knight.y = grid[gridIndex].charScreenY;

                // Enemy Code Layout
                gridIndex = grid.FindIndex(x => (x.xPos == 5) && (x.yPos == 2));
                float enemyXPos = grid[gridIndex].charScreenX;
                float enemyYPos = grid[gridIndex].charScreenY;
                Enemy newEnemy = new Enemy(5, 2, charSize, enemyXPos, enemyYPos);
                enemy.Add(newEnemy);
                grid[gridIndex].guarded = true;

                gridIndex = grid.FindIndex(x => (x.xPos == 4) && (x.yPos == 6));
                enemyXPos = grid[gridIndex].charScreenX;
                enemyYPos = grid[gridIndex].charScreenY;
                newEnemy = new Enemy(4, 6, charSize, enemyXPos, enemyYPos);
                enemy.Add(newEnemy);
                grid[gridIndex].guarded = true;

                gridIndex = grid.FindIndex(x => (x.xPos == 2) && (x.yPos == 3));
                enemyXPos = grid[gridIndex].charScreenX;
                enemyYPos = grid[gridIndex].charScreenY;
                newEnemy = new Enemy(2, 3, charSize, enemyXPos, enemyYPos);
                enemy.Add(newEnemy);
                grid[gridIndex].guarded = true;

                // Wall Code Layout
                gridIndex = grid.FindIndex(x => (x.xPos == 1) && (x.yPos == 4));
                grid[gridIndex].walled = true;
                gridIndex = grid.FindIndex(x => (x.xPos == 2) && (x.yPos == 4));
                grid[gridIndex].walled = true;
                gridIndex = grid.FindIndex(x => (x.xPos == 6) && (x.yPos == 5));
                grid[gridIndex].walled = true;
                gridIndex = grid.FindIndex(x => (x.xPos == 1) && (x.yPos == 7));
                grid[gridIndex].walled = true;
                gridIndex = grid.FindIndex(x => (x.xPos == 2) && (x.yPos == 7));
                grid[gridIndex].walled = true;
                gridIndex = grid.FindIndex(x => (x.xPos == 3) && (x.yPos == 7));
                grid[gridIndex].walled = true;

                // Trap Code Layout
                gridIndex = grid.FindIndex(x => (x.xPos == 4) && (x.yPos == 7));
                grid[gridIndex].trapped = true;
                gridIndex = grid.FindIndex(x => (x.xPos == 6) && (x.yPos == 1));
                grid[gridIndex].trapped = true;
                gridIndex = grid.FindIndex(x => (x.xPos == 7) && (x.yPos == 2));
                grid[gridIndex].trapped = true;
                gridIndex = grid.FindIndex(x => (x.xPos == 1) && (x.yPos == 3));
                grid[gridIndex].trapped = true;

            }
            else if (level == 2)
            {
                // Player Spawn Code
                gridIndex = grid.FindIndex(x => (x.xPos == 2) && (x.yPos == 6));

                knight.posX = 2;
                knight.posY = 6;
                knight.x = grid[gridIndex].charScreenX;
                knight.y = grid[gridIndex].charScreenY;

                // Enemy Code Layout
                gridIndex = grid.FindIndex(x => (x.xPos == 1) && (x.yPos == 3));
                float enemyXPos = grid[gridIndex].charScreenX;
                float enemyYPos = grid[gridIndex].charScreenY;
                Enemy newEnemy = new Enemy(1, 3, charSize, enemyXPos, enemyYPos);
                enemy.Add(newEnemy);
                grid[gridIndex].guarded = true;

                gridIndex = grid.FindIndex(x => (x.xPos == 4) && (x.yPos == 4));
                enemyXPos = grid[gridIndex].charScreenX;
                enemyYPos = grid[gridIndex].charScreenY;
                newEnemy = new Enemy(4, 4, charSize, enemyXPos, enemyYPos);
                enemy.Add(newEnemy);
                grid[gridIndex].guarded = true;

                gridIndex = grid.FindIndex(x => (x.xPos == 6) && (x.yPos == 6));
                enemyXPos = grid[gridIndex].charScreenX;
                enemyYPos = grid[gridIndex].charScreenY;
                newEnemy = new Enemy(6, 6, charSize, enemyXPos, enemyYPos);
                enemy.Add(newEnemy);
                grid[gridIndex].guarded = true;

                // Wall Code Layout
                gridIndex = grid.FindIndex(x => (x.xPos == 7) && (x.yPos == 6));
                grid[gridIndex].walled = true;
                gridIndex = grid.FindIndex(x => (x.xPos == 7) && (x.yPos == 7));
                grid[gridIndex].walled = true;
                gridIndex = grid.FindIndex(x => (x.xPos == 3) && (x.yPos == 7));
                grid[gridIndex].walled = true;

                // Trap Code Layout
                gridIndex = grid.FindIndex(x => (x.xPos == 1) && (x.yPos == 1));
                grid[gridIndex].trapped = true;
                gridIndex = grid.FindIndex(x => (x.xPos == 2) && (x.yPos == 1));
                grid[gridIndex].trapped = true;
                gridIndex = grid.FindIndex(x => (x.xPos == 3) && (x.yPos == 1));
                grid[gridIndex].trapped = true;
                gridIndex = grid.FindIndex(x => (x.xPos == 4) && (x.yPos == 1));
                grid[gridIndex].trapped = true;
                gridIndex = grid.FindIndex(x => (x.xPos == 7) && (x.yPos == 1));
                grid[gridIndex].trapped = true;
                gridIndex = grid.FindIndex(x => (x.xPos == 7) && (x.yPos == 2));
                grid[gridIndex].trapped = true;
                gridIndex = grid.FindIndex(x => (x.xPos == 7) && (x.yPos == 3));
                grid[gridIndex].trapped = true;
                gridIndex = grid.FindIndex(x => (x.xPos == 7) && (x.yPos == 4));
                grid[gridIndex].trapped = true;
                gridIndex = grid.FindIndex(x => (x.xPos == 7) && (x.yPos == 5));
                grid[gridIndex].trapped = true;
            }
            else if (level == 3)
            {
                // Player Spawn Code
                gridIndex = grid.FindIndex(x => (x.xPos == 1) && (x.yPos == 3));

                knight.posX = 1;
                knight.posY = 3;
                knight.x = grid[gridIndex].charScreenX;
                knight.y = grid[gridIndex].charScreenY;

                // Enemy Code Layout
                gridIndex = grid.FindIndex(x => (x.xPos == 3) && (x.yPos == 3));
                float enemyXPos = grid[gridIndex].charScreenX;
                float enemyYPos = grid[gridIndex].charScreenY;
                Enemy newEnemy = new Enemy(3, 3, charSize, enemyXPos, enemyYPos);
                enemy.Add(newEnemy);
                grid[gridIndex].guarded = true;

                gridIndex = grid.FindIndex(x => (x.xPos == 5) && (x.yPos == 3));
                enemyXPos = grid[gridIndex].charScreenX;
                enemyYPos = grid[gridIndex].charScreenY;
                newEnemy = new Enemy(5, 3, charSize, enemyXPos, enemyYPos);
                enemy.Add(newEnemy);
                grid[gridIndex].guarded = true;

                gridIndex = grid.FindIndex(x => (x.xPos == 6) && (x.yPos == 3));
                enemyXPos = grid[gridIndex].charScreenX;
                enemyYPos = grid[gridIndex].charScreenY;
                newEnemy = new Enemy(6, 3, charSize, enemyXPos, enemyYPos);
                enemy.Add(newEnemy);
                grid[gridIndex].guarded = true;

                // Wall Code Layout
                gridIndex = grid.FindIndex(x => (x.xPos == 1) && (x.yPos == 1));
                grid[gridIndex].walled = true;
                gridIndex = grid.FindIndex(x => (x.xPos == 1) && (x.yPos == 2));
                grid[gridIndex].walled = true;
                gridIndex = grid.FindIndex(x => (x.xPos == 4) && (x.yPos == 1));
                grid[gridIndex].walled = true;
                gridIndex = grid.FindIndex(x => (x.xPos == 3) && (x.yPos == 6));
                grid[gridIndex].walled = true;
                gridIndex = grid.FindIndex(x => (x.xPos == 3) && (x.yPos == 7));
                grid[gridIndex].walled = true;
                gridIndex = grid.FindIndex(x => (x.xPos == 6) && (x.yPos == 7));
                grid[gridIndex].walled = true;

                // Trap Code Layout
                gridIndex = grid.FindIndex(x => (x.xPos == 5) && (x.yPos == 1));
                grid[gridIndex].trapped = true;
                gridIndex = grid.FindIndex(x => (x.xPos == 7) && (x.yPos == 7));
                grid[gridIndex].trapped = true;
                
            }
            else if (level == 4)
            {
                // Player Spawn Code
                gridIndex = grid.FindIndex(x => (x.xPos == 4) && (x.yPos == 7));

                knight.posX = 4;
                knight.posY = 7;
                knight.x = grid[gridIndex].charScreenX;
                knight.y = grid[gridIndex].charScreenY;

                // Enemy Code Layout
                gridIndex = grid.FindIndex(x => (x.xPos == 3) && (x.yPos == 3));
                float enemyXPos = grid[gridIndex].charScreenX;
                float enemyYPos = grid[gridIndex].charScreenY;
                Enemy newEnemy = new Enemy(3, 3, charSize, enemyXPos, enemyYPos);
                enemy.Add(newEnemy);
                grid[gridIndex].guarded = true;

                // Wall Code Layout
                gridIndex = grid.FindIndex(x => (x.xPos == 1) && (x.yPos == 1));
                grid[gridIndex].walled = true;
                gridIndex = grid.FindIndex(x => (x.xPos == 1) && (x.yPos == 2));
                grid[gridIndex].walled = true;
                gridIndex = grid.FindIndex(x => (x.xPos == 6) && (x.yPos == 3));
                grid[gridIndex].walled = true;
                gridIndex = grid.FindIndex(x => (x.xPos == 4) && (x.yPos == 2));
                grid[gridIndex].walled = true;
                gridIndex = grid.FindIndex(x => (x.xPos == 6) && (x.yPos == 6));
                grid[gridIndex].walled = true;
                gridIndex = grid.FindIndex(x => (x.xPos == 5) && (x.yPos == 6));
                grid[gridIndex].walled = true;
                gridIndex = grid.FindIndex(x => (x.xPos == 7) && (x.yPos == 6));
                grid[gridIndex].walled = true;
                gridIndex = grid.FindIndex(x => (x.xPos == 1) && (x.yPos == 7));
                grid[gridIndex].walled = true;
                gridIndex = grid.FindIndex(x => (x.xPos == 3) && (x.yPos == 4));
                grid[gridIndex].walled = true;
                gridIndex = grid.FindIndex(x => (x.xPos == 6) && (x.yPos == 1));
                grid[gridIndex].walled = true;
                gridIndex = grid.FindIndex(x => (x.xPos == 7) && (x.yPos == 1));
                grid[gridIndex].walled = true;

                // Trap Code Layout
                gridIndex = grid.FindIndex(x => (x.xPos == 7) && (x.yPos == 7));
                grid[gridIndex].trapped = true;

            }
            /*else if (level == "level number")
            {

            // Player Spawn Code
                gridIndex = grid.FindIndex(x => (x.xPos == 3) && (x.yPos == 2));

                knight.posX = 3;
                knight.posY = 2;
                knight.x = grid[gridIndex].charScreenX;
                knight.y = grid[gridIndex].charScreenY;

                // Enemy Code Layout
                gridIndex = grid.FindIndex(x => (x.xPos == 1) && (x.yPos == 1));
                float enemyXPos = grid[gridIndex].charScreenX;
                float enemyYPos = grid[gridIndex].charScreenY;
                Enemy newEnemy = new Enemy(1, 1, charSize, enemyXPos, enemyYPos);
                enemy.Add(newEnemy);
                grid[gridIndex].guarded = true;

                // Wall Code Layout
                gridIndex = grid.FindIndex(x => (x.xPos == 1) && (x.yPos == 2));
                grid[gridIndex].walled = true;
                
                // Trap Code Layout
                gridIndex = grid.FindIndex(x => (x.xPos == 1) && (x.yPos == 2));
                grid[gridIndex].trapped = true;
                
            }*/

        }


    }


}
