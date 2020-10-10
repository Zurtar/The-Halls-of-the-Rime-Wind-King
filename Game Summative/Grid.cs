using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Summative
{
    class Grid
    {
        // Grid contains a 7x7 of cells with coordinates for each (X + Y)
        // Position 1,1 is in the top left corner, 7,1 is in the top right, 1,7 is in the bottom left corner, and 7,7 is the bottom right corner.

        // Grid contains the size of cells, and the distance between cells.

        public int xPos, yPos; // xPos and yPos refer to the grid position (1,1 is top left corner)
        public float screenX, screenY; // screenX and screenY refer to the screens x and y
        public float charScreenX, charScreenY; // Determines the character's postion on the screen per grid.
        public float squareSize;
        public bool trapped;
        public bool walled;
        public bool guarded;

        public Grid(int _xPos, int _yPos, float _screenX, float _screenY, float _charScreenX, float _charScreenY, float _squareSize, bool _trapped, bool _walled, bool _guarded)
        {
            xPos = _xPos;
            yPos = _yPos;
            screenX = _screenX;
            screenY = _screenY;
            charScreenX = _charScreenX;
            charScreenY = _charScreenY;
            squareSize = _squareSize;
            trapped = _trapped;
            walled = _walled;
            guarded = _guarded;
        }

        // When position recieved, check the content of that position, then send the requested position to the enemy or character

        // When position recieved, return the screen position of those co-ordinates
    }
}
