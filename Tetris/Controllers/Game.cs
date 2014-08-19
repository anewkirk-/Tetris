using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Tetris.Models;
using Tetris.Models.TetriminoBag;

namespace Tetris.Controllers
{
    public class Game
    {
        public int CurrentScore { get; set; }
        private Random rand = new Random();
        public GameMode Mode { get; set; }
        public TetrisBoard GameBoard { get; set; }
        private Tetrimino CurrentTetrimino { get; set; }
        private Timer _gameTimer = new Timer();

        public Game()
        {
            //default to a 1 second interval
            _gameTimer.Interval = 1000;
            _gameTimer.Elapsed += Tick;
        }

        public List<Tetrimino> tBag = new List<Tetrimino>
        {
            new i_Tetrimino(),
            new j_Tetrimino(),
            new l_Tetrimino(),
            new o_Tetrimino(),
            new s_Tetrimino(),
            new t_Tetrimino(),
            new z_Tetrimino()
        };

        /// <summary>
        /// This method contains the actual game logic, and will be called on each tick of the _gameTimer.
        /// </summary>
        public void Tick(object sender, ElapsedEventArgs e)
        {

            //Check if current tetrimino has fallen as far as it can and collided with blocks or the bottom of the board
            bool topOut = false;
            bool collision = false;
            foreach (Point p in CurrentTetrimino.Blocks)
            {
                if (p.Y == 19)
                {
                    collision = true;
                }
                foreach (Tetrimino t in GameBoard)
                {
                    foreach (Point p2 in t.Blocks)
                    {
                        if (p.X == p2.X && p.Y == p2.Y - 1)
                        {
                            collision = true;
                        }
                    }
                }
            }
            //////////////////////////////
            //If so, check for "top out"//
            //////////////////////////////

            //if no top out, drop a new tetrimino
            if (!topOut)
            {
                if (collision)
                {
                    AddRandomTetrimino();
                }
                //if no collision, have current tetrimino drop another row down
                else
                {
                    CurrentTetrimino.Fall();
                }

                //check for lines filled and clear them
                List<int> rowNumbersCleared = new List<int>();
                for (int i = 0; i < 20; i++)
                {
                    List<Point> blocksInRow = new List<Point>();
                    foreach (Tetrimino t in GameBoard)
                    {
                        foreach (Point p in t.Blocks)
                        {
                            if (p.Y == i)
                            {
                                blocksInRow.Add(p);
                            }
                        }
                    }
                    if (blocksInRow.Count == 10)
                    {
                        rowNumbersCleared.Add(i);
                    }
                }
                foreach (int i in rowNumbersCleared)
                {
                    ClearRow(i);
                }
                //add points for cleared lines
                switch (rowNumbersCleared.Count)
                {
                    default:
                        break;
                }
            }
            //in the case of a "top out", the game is over
            else
            {
                //submit score, end game
            }
        }

        //Removes all blocks that have a given Y value
        private void ClearRow(int y)
        {
            throw new NotImplementedException();
        }

        //Get a random Tetrimino from the Tetrimino Bag and add it to the TetriminoOnGameBoard list
        public void AddRandomTetrimino()
        {
            int index = rand.Next(tBag.Count);
            Tetrimino randT = tBag[index];
            CurrentTetrimino = randT;
            GameBoard.Add(CurrentTetrimino);
        }
            
     
        //Create a row of points leaving one space
        public List<Point> RowOfBlocksMinusOne()
        {
            List<Point> Blocks = new List<Point>();
            int randomY = rand.Next(0, 10);
            
            for (int i = 0; i <= 9; i++)
            {
                if (i != randomY)
                {
                    Point p = new Point();
                    p.Y = 19;
                    p.X = i;
                    Blocks.Add(p);
                }
            }
            return Blocks;
        }

        //Move all rows of Tetromino up one
        public void MoveRowsUp()
        {
            //For every Tetromino on Gameboard
              //(x, y -= 1)
        }

        //Add a row of Tetrimino's with an empty space in the middle when a "Tetris" has occured on the other player's screen
        public void AddRowSansOne()
        {
            MoveRowsUp();
            RowOfBlocksMinusOne();
        }

        public void MoveLeft()
        {
            bool canMove = false;
            for (int i = 0; i < 4; i++)
            {
                if (CurrentTetrimino.Blocks[i].X == -1)
                {
                    canMove = false;
                    break;
                }
                else
                {
                    canMove = true;
                }
            }

            if (canMove)
            {
                for (int i = 0; i < 4; i++)
                {
                    CurrentTetrimino.Blocks[i].X--;
                }
            }
        }

        public void MoveRight()
        {
            bool canMove = false;
            for (int i = 0; i < 4; i++)
            {
                if (CurrentTetrimino.Blocks[i].X == 20)
                {
                    canMove = false;
                    break;
                }
                else
                {
                    canMove = true;
                }
            }

            if (canMove)
            {
                for (int i = 0; i < 4; i++)
                {
                    CurrentTetrimino.Blocks[i].X++;
                }
            }
        }

        public void StartHardDrop()
        {
            CurrentTetrimino.Fall();
        }

        //public void StopHardDrop()
        //{
        //    throw new NotImplementedException();
        //}

        public void RotateCurrent()
        {
            CurrentTetrimino.RotateRight();
        }
    }
}
