using System;
using System.Linq;
using System.Collections.Generic;
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
        public GameMode Mode { get; set; }
        public TetrisBoard GameBoard { get; set; }
        private Timer GameTimer { get; set; }
        private int TimeElapsed { get; set; }
        private int LinesCleared { get; set; }
        private Random rand = new Random();
        private Tetrimino CurrentTetrimino { get; set; }
        private ScoreManager _sm = new ScoreManager();
        private int _timedModeTimeLimit = 120;
        private int _marathonModeLineLimit = 50;
        private int _linesBeforeSpeedUp = 10;
        private bool _isToppedOut = false;

        public Game()
        {
            //default to a 1 second interval
            GameTimer = new Timer();
            GameTimer.Interval = 1000;
            GameTimer.Elapsed += Tick;
        }

        public Game(GameMode mode)
        {
            //default to a 1 second interval
            GameTimer = new Timer();
            GameTimer.Interval = 1000;
            GameTimer.Elapsed += Tick;
            this.Mode = mode;
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
        /// This method contains the actual game logic, and will be called on each tick of the GameTimer.
        /// </summary>
        public void Tick(object sender, ElapsedEventArgs e)
        {        

            //Check for end game
            bool endGame = EndConditionsMet();

            //End game if any end conditions met
            if (endGame || _isToppedOut)
            {
                //End game
                GameTimer.Enabled = false;
                //Submit score
                ////Here, the window will have to switch views
                ////to the AddHighScore overlay
            }

            //Keep track of how long the game has been running
            TimeElapsed += (int)GameTimer.Interval;
            
            if (Mode == GameMode.Classic || Mode == GameMode.Timed)
            {
                //Check LinesCleared to see if the timer interval needs to be
                //decreased
                if (LinesCleared > 0 && LinesCleared % _linesBeforeSpeedUp == 0)
                {
                    //Makes the drop interval half a second shorter,
                    //This will probably need to be adjusted
                    GameTimer.Interval -= 500;
                }
            }

            //Check for collision on currently falling tetrimino
            bool collision = false;

            foreach (Points p in CurrentTetrimino.Blocks)
            {
                if (!CanFall(p))
                {
                    collision = true;
                }
            }

            //If there is a collision,
            if (collision)
            {
                //Check for rows cleared
                List<int> rowsCleared = CheckRowsCleared();
                //for all rows cleared
                foreach (int i in rowsCleared)
                {
                    //remove blocks, add points
                    ClearRow(i);
                }
                //drop new tetrimino
                AddRandomTetrimino();
            }
            //If no collision
            else
            {
                //Drop current tetrimino down one block
                CurrentTetrimino.Fall();
            }
        }

        private List<int> CheckRowsCleared()
        {

            List<int> rowsCleared = new List<int>();

            IEnumerable<Points> allPoints =
                from t in GameBoard
                from pt in t.Blocks
                select pt;

            for (int i = 0; i < 20; i++)
            {
                IEnumerable<Points> rowsPoints =
                    from b in allPoints
                    where b.Y == i
                    select b;
                if (rowsPoints.Count() == 10)
                {
                    rowsCleared.Add(i);
                }
            }
            return rowsCleared;
        }

        private bool EndConditionsMet()
        {
            bool endGame = false;
            //Check all end conditions
            switch (Mode)
            {
                case GameMode.Timed:
                    //Check TimeElapsed to see if the time limit has been reached
                    if (TimeElapsed >= _timedModeTimeLimit)
                    {
                        endGame = true;
                    }
                    break;
                case GameMode.Marathon:
                    //Check LinesCleared to see if limit has been reached
                    if (LinesCleared >= _marathonModeLineLimit)
                    {
                        endGame = true;
                    }
                    break;
                default:
                    break;
            }
            return endGame;
        }

        private bool CanFall(Points p)
        {
            IEnumerable<Points> bl = (IEnumerable<Points>)
                from t in GameBoard
                from pt in t.Blocks
                where pt.Y > p.Y
                select pt;

            foreach(Points ps in bl)
            {
                if (ps.X == p.X && ps.Y == p.Y + 1)
                {
                    return false;
                }
            }
            if (p.Y >= 19)
            {
                return false;
            }
            return true;
        }

        //Removes all blocks that have a given Y value
        private void ClearRow(int y)
        {
            foreach (Tetrimino t in GameBoard)
            {
                foreach (Points p in t.Blocks)
                {
                    if (p.Y == y)
                    {
                        t.Blocks.Remove(p);
                    }
                }
            }
        }

        //Get a random Tetrimino from the Tetrimino Bag and add it to the TetriminoOnGameBoard list
        public void AddRandomTetrimino()
        {
            int index = rand.Next(tBag.Count);
            Tetrimino randT = tBag[index];
            CurrentTetrimino = randT;
            GameBoard.Add(CurrentTetrimino);
            foreach (Tetrimino t in GameBoard)
            {
                foreach (Points p in t.Blocks)
                {
                    foreach (Points newPoint in CurrentTetrimino.Blocks)
                    {
                        if (newPoint.X == p.X && newPoint.Y == p.Y)
                        {
                            _isToppedOut = true;
                        }
                    }
                }
            }
        }
            
     
        //Create a row of points leaving one space
        public List<Points> RowOfBlocksMinusOne()
        {
            List<Points> Blocks = new List<Points>();
            int randomY = rand.Next(0, 10);
            
            for (int i = 0; i <= 9; i++)
            {
                if (i != randomY)
                {
                    Points p = new Points();
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
            foreach (Tetrimino t in GameBoard)
            {
                if (t != CurrentTetrimino)
                {
                    foreach (Points p in t.Blocks)
                    {
                        p.Y = p.Y - 1;
                    }
                }
            }
        }

        //Add a row of Tetrimino's with an empty space in the middle when a "Tetris" has occured on the other player's screen
        public void AddRowSansOne()
        {
            MoveRowsUp();
            RowOfBlocksMinusOne();
        }

        public void MoveLeft()
        {
            int index = 0;
            if ((CurrentTetrimino.Blocks[0].X <= CurrentTetrimino.Blocks[1].X) &&
                (CurrentTetrimino.Blocks[0].X <= CurrentTetrimino.Blocks[2].X) &&
                (CurrentTetrimino.Blocks[0].X <= CurrentTetrimino.Blocks[3].X))
            {
                index = 0;
            }
            else if ((CurrentTetrimino.Blocks[1].X <= CurrentTetrimino.Blocks[0].X) &&
                (CurrentTetrimino.Blocks[1].X <= CurrentTetrimino.Blocks[2].X) &&
                (CurrentTetrimino.Blocks[1].X <= CurrentTetrimino.Blocks[3].X))
            {
                index = 1;
            }
            else if ((CurrentTetrimino.Blocks[2].X <= CurrentTetrimino.Blocks[1].X) &&
                (CurrentTetrimino.Blocks[2].X <= CurrentTetrimino.Blocks[0].X) &&
                (CurrentTetrimino.Blocks[2].X <= CurrentTetrimino.Blocks[3].X))
            {
                index = 2;
            }
            else if ((CurrentTetrimino.Blocks[3].X <= CurrentTetrimino.Blocks[1].X) &&
                (CurrentTetrimino.Blocks[3].X <= CurrentTetrimino.Blocks[2].X) &&
                (CurrentTetrimino.Blocks[3].X <= CurrentTetrimino.Blocks[0].X))
            {
                index = 3;
            }

            bool canMove = false;
            for (int i = 0; i < 4; i++)
            {
                if (CurrentTetrimino.Blocks[i].X == 0)
                {
                    canMove = false;
                    break;
                }
                else
                {
                    foreach (var t in GameBoard)
                    {
                        for (int j = 0; j < 4; j++)
                        {
                            if (t.Blocks[j].X == CurrentTetrimino.Blocks[index].X - 1)
                            {
                                canMove = false;
                                break;
                            }
                        }
                    }
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
            int index = 0;
            if ((CurrentTetrimino.Blocks[0].X >= CurrentTetrimino.Blocks[1].X) &&
                (CurrentTetrimino.Blocks[0].X >= CurrentTetrimino.Blocks[2].X) &&
                (CurrentTetrimino.Blocks[0].X >= CurrentTetrimino.Blocks[3].X))
            {
                index = 0;
            }
            if ((CurrentTetrimino.Blocks[1].X >= CurrentTetrimino.Blocks[0].X) &&
                (CurrentTetrimino.Blocks[1].X >= CurrentTetrimino.Blocks[2].X) &&
                (CurrentTetrimino.Blocks[1].X >= CurrentTetrimino.Blocks[3].X))
            {
                index = 1;
            }
            if ((CurrentTetrimino.Blocks[2].X >= CurrentTetrimino.Blocks[1].X) &&
                (CurrentTetrimino.Blocks[2].X >= CurrentTetrimino.Blocks[0].X) &&
                (CurrentTetrimino.Blocks[2].X >= CurrentTetrimino.Blocks[3].X))
            {
                index = 2;
            }
            if ((CurrentTetrimino.Blocks[3].X >= CurrentTetrimino.Blocks[1].X) &&
                (CurrentTetrimino.Blocks[3].X >= CurrentTetrimino.Blocks[2].X) &&
                (CurrentTetrimino.Blocks[3].X >= CurrentTetrimino.Blocks[0].X))
            {
                index = 3;
            }

            bool canMove = false;
            for (int i = 0; i < 4; i++)
            {
                if (CurrentTetrimino.Blocks[i].X == 9)
                {
                    canMove = false;
                    break;
                }
                else
                {
                    foreach (var t in GameBoard)
                    {
                        for (int j = 0; j < 4; j++)
                        {
                            if (t.Blocks[j].X == CurrentTetrimino.Blocks[index].X + 1)
                            {
                                canMove = false;
                                break;
                            }
                        }
                    }
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
