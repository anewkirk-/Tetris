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

        //This method contains all the logic that happens in one discrete unit of time during a Tetris game
        public void Tick()
        {
            throw new NotImplementedException();
        }

        //Get a random Tetrimino from the Tetrimino Bag
        public void RandomTetrimino()
        {
            int index = rand.Next(tBag.Count);
            Tetrimino randT = tBag[index];
            CurrentTetrimino = randT;
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
