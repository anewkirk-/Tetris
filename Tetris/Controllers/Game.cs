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
        private Random rand = new Random();
        public GameMode Mode { get; set; }
        public TetrisBoard GameBoard { get; set; }
        private Tetrimino CurrentTetrimino { get; set; }
        private Timer _gameTimer = new Timer();

        public Game()
        {
            //default to 1 second intervals. This will be modified later.
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

        public void Tick(object sender, ElapsedEventArgs e)
        {
            //Check if current tetrimino has fallen as far as it can and collided with blocks or the bottom of the board below it
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
            //If so, drop a new tetrimino
            if (collision)
            {
                AddRandomTetrimino();
            }
            else
            {
                CurrentTetrimino.Fall();
            }
            //if not, have it drop another row down

            //check for lines filled and clear them
            for (int i = 0; i < 20; i++)
            {
                bool rowFilled = false;

            }
            //add points for cleared lines


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
                    p.X = 19;
                    p.Y = i;
                    Blocks.Add(p);
                }
            }
            return Blocks;
        }

        //Move all rows of Tetromino up one
        public void MoveRowsUp()
        {
            //For every Tetromino on Gameboard
              //(X-1, y0)
        }

        //Add a row of Tetrimino's with an empty space in the middle when a "Tetris" has occured on the other player's screen
        public void AddRowSansOne()
        {
            MoveRowsUp();
            RowOfBlocksMinusOne();
        }

        public void StartMoveLeft()
        {
            for (int i = 0; i < 4; i++)
            {
                CurrentTetrimino.Blocks[i].Y--;
            }
        }

        public void StartMoveRight()
        {
            for (int i = 0; i < 4; i++)
            {
                CurrentTetrimino.Blocks[i].Y++;
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
