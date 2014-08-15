using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        
        //This method contains all the logic that happens in one discrete unit of time during a Tetris game
        public void Tick()
        {
            throw new NotImplementedException();
        }

        //Create a row of points leaving one space
        public void RowOfBlocksMinusOne()
        {
            List<Point> Blocks = new List<Point>();
            int randomY = rand.Next(0, 10);

            for (int i = 0; i <= 9; i++)
            {
                if (i != randomY)
                {
                    Point p = new Point();
                    p.X = 19;
                    p.Y = randomY;
                    Blocks.Add(p);
                }
            }
        }

        //Move all rows of Tetromino up one
        public void MoveRowsUp()
        {

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

        //public void StopMoveLeft()
        //{
        //    throw new NotImplementedException();
        //}

        //public void StopMoveRight()
        //{
        //    throw new NotImplementedException();
        //}

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
