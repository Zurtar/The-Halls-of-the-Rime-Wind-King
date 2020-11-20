using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game_Summative
{
	class Bot
	{
		//Will be updated every tick in GameScreen.cs
		public static List<int> possibleMoveDirections = new List<int>();

		public static List<Enemy> enemies = new List<Enemy>();

		//Move list
		List<Move> moves = new List<Move>();

		//Current position
		int[] position = new int[2];

		//Random object for our bots choices
		static Random r = new Random();

		public static void tickMove()
		{
			//Generates our movement direction based on possible moves
			int moveDirection = r.Next(possibleMoveDirections.Min(), possibleMoveDirections.Max());

			switch (moveDirection) {
				case 1:
			MainMenu.gs.GameScreen_PreviewKeyDown(null, new PreviewKeyDownEventArgs(Keys.W));
					break;
				case 2:
					MainMenu.gs.GameScreen_PreviewKeyDown(null, new PreviewKeyDownEventArgs(Keys.D));
					break;
				case 3:
					MainMenu.gs.GameScreen_PreviewKeyDown(null, new PreviewKeyDownEventArgs(Keys.S));
					break;
				case 0:
					MainMenu.gs.GameScreen_PreviewKeyDown(null, new PreviewKeyDownEventArgs(Keys.A));
					break;
			}
			
		}
	}


	//Class for our move object
	class Move {
		Move parent;
		List<Enemy> boardState;
		int direction, x, y;

		public Move(Move parent_, List<Enemy> boardState_, int direction_, int x_, int y_) {
			parent = parent_;
			boardState = boardState_;
			direction = direction_;
			x = x_;
			y = y_;
		}

	}
}


//hard as hell
/*
 
 if we reach a position that we have been to before and the "board state" is the same as the previous instance we were there - node/branch is invalid 

if there are no valid moves node/branch is invalid

if player death - node is invalid

have a map with the keys being board states and the values being all previous positions that we had that board state at
	if our position is equal to that of a postion that we get when we use our boardstate key node is invalid






What might work instead is just knowing our previous move and then recording each fail as: at this postion AND this board state x move was invalid 

that way when we get to that position and board state we say hey this move was invalid lets try this one if that one fails we go ok we have no valid moves so we go up a level to the parent move and say at this postion and this board state this child move is invalid

repeat until we get a solution 
 
 */