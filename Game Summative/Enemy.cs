using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Summative
{
    class Enemy
    {
        // Enemies have a position on the grid (X + Y)

        public int xPos, yPos; //Grid Coordinate
        public float x, y; // Screen Coordinate
        public float enemySize;
        public int type; // Determines the sprite and animation for an enemy
        public Enemy(int _xPos, int _yPos, float _enemySize, float _x, float _y, int _type)
        {
            xPos= _xPos;
            yPos = _yPos;
            enemySize = _enemySize;
            x = _x;
            y = _y;
            type = _type;
        }

        public void pushed(int newX, int newY, float screenX, float screenY)
        {

        }
    }
}
