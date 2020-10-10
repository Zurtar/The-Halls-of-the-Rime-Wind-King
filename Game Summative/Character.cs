using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Summative
{
    class Character
    {
        public int posX, posY; // posX and posY refer to the character's position on the grid (anywhere from 1,1 to 7,7)
        public float x, y, characterSize; // x and y refer to the characters actual position on the screen.
 
        public Character(int _posX, int _PosY, float _characterSize, float _x, float _y)
        {
            posX = _posX;
            posY = _PosY;
            characterSize = _characterSize;
            x = _x;
            y = _y;
        }

        // The character has a position on the grid, (X + Y)
        // Check for movement in the 4 directions

        // When moving to a new position., ask the Grid what the content of the next position is.

        // If theres no content, move to that position and repeat.
        // If the content is a wall or grid border, then stop movement.
        // If the content is an enemy, push the enemy to the next box and stop movement.
        // If the content is a trap, stop movement and die.

        public void moveChar(float newRealX, float newRealY, int newX, int newY)
        {
            posX = newX;
            posY = newY;

            y = newRealY;
            x = newRealX;
        }
        

    }
}
