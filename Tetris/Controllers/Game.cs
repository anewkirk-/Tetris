using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Tetris.Models;
using Tetris.Models.TetriminoBag;
using Tetris.Views.GameScreens;

namespace Tetris.Controllers
{

    public delegate void GameEndHandler();

    public class Game
    {
        public event GameEndHandler GameEnd;
        public int CurrentScore { get; set; }
        public GameMode Mode { get; set; }
        public TetrisBoard GameBoard { get; set; }
        public Timer GameTimer { get; set; }
        private int TimeElapsed { get; set; }
        private int LinesCleared { get; set; }
        private Random rand = new Random();
        public Tetrimino CurrentTetrimino { get; set; }
        private ScoreManager _sm = new ScoreManager();
        private int _timedModeTimeLimit = 120;
        private int _marathonModeLineLimit = 50;
        private int _linesBeforeSpeedUp = 5;
        private bool _isToppedOut = false;

        public Game()
        {
            //default to a 1 second interval
            GameBoard = new TetrisBoard();
            GameTimer = new Timer();
            GameTimer.Interval = 1000;
            GameTimer.Elapsed += Tick;
            CurrentScore = 0;
        }

        public Game(GameMode mode)
        {
            //default to a 1 second interval
            GameBoard = new TetrisBoard();
            GameTimer = new Timer();
            GameTimer.Interval = 500;
            GameTimer.Elapsed += Tick;
            this.Mode = mode;
            CurrentScore = 0;
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

        public void Start()
        {
            GameTimer.Enabled = true;
        }

        public void Stop()
        {
            GameTimer.Enabled = false;

        }

        /// <summary>
        /// This method contains the actual game logic, and will be called on each tick of the GameTimer.
        /// </summary>
        public void Tick(object sender, ElapsedEventArgs e)
        {
            //Drop first tetrimino
            if (CurrentTetrimino == null)
            {
                AddRandomTetrimino();
            }

            bool endGame = EndConditionsMet();
            if (endGame || _isToppedOut)
            {
                GameTimer.Stop();
                if (GameEnd != null)
                {
                    GameEnd();
                }
            }

            //keep track of how long the game has been running
            TimeElapsed += (int)GameTimer.Interval;

            if (Mode == GameMode.Classic || Mode == GameMode.Timed)
            {
                //Check LinesCleared to see if the timer interval needs to be
                //decreased
                if (LinesCleared > 0 && LinesCleared % _linesBeforeSpeedUp == 0)
                {
                    //Makes the drop interval half a second shorter,
                    //This will probably need to be adjusted
                    if (GameTimer.Interval > 50)
                    {
                        GameTimer.Interval -= 50;
                        LinesCleared = 0;
                    }
                }
            }

            bool collision = false;

            List<Points> lowestPoints = new List<Points>(CurrentTetrimino.Blocks);
            foreach (Points p in lowestPoints.ToList())
            {
                foreach (Points p2 in lowestPoints.ToList())
                {
                    if (p.X == p2.X && p.Y > p2.Y)
                    {
                        lowestPoints.Remove(p2);
                    }
                }
            }

            foreach (Points p in lowestPoints)
            {
                if (!CanFall(p))
                {
                    collision = true;
                }
            }

            if (collision)
            {
                List<int> cleared = CheckRowsCleared();
                //

                //
                foreach (int i in cleared)
                {
                    ClearRow(i);
                    LinesCleared++;
                    MoveDownStartingFrom(i);
                }
                AddRandomTetrimino();
            }
            else
            {
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

        private void MoveDownStartingFrom(int i)
        {
            IEnumerable<Points> p =
                from Tetrimino t in GameBoard
                from Points pt in t.Blocks
                where pt.Y < i && pt.Y > 0
                select pt;
            foreach (Points point in p.ToList())
            {
                point.Y++;
            }
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

            foreach(Points ps in bl.ToList())
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
            foreach (Tetrimino t in GameBoard.ToList())
            {
                foreach (Points p in t.Blocks.ToList())
                {
                    if (p.Y == y)
                    {
                        t.Blocks.Remove(p);
                    }
                }
            }
            LinesCleared++;
        }

        public void AddRandomTetrimino()
        {
            int index = rand.Next(tBag.Count);

            Tetrimino randT = null;
            switch (index)
            {
                case 0: randT = new i_Tetrimino();
                    break;
                case 1: randT = new j_Tetrimino();
                    break;
                case 2: randT = new l_Tetrimino();
                    break;
                case 3: randT = new o_Tetrimino();
                    break;
                case 4: randT = new s_Tetrimino();
                    break;
                case 5: randT = new t_Tetrimino();
                    break;
                case 6: randT = new z_Tetrimino();
                    break;
            }

            CurrentTetrimino = randT;
            GameBoard.Add(CurrentTetrimino);
            foreach (Tetrimino t in GameBoard.ToList())
            {
                if (t != CurrentTetrimino)
                {
                    foreach (Points p in t.Blocks.ToList())
                    {
                        foreach (Points newPoint in CurrentTetrimino.Blocks.ToList())
                        {
                            if (newPoint.X == p.X && newPoint.Y == p.Y)
                            {
                                _isToppedOut = true;
                            }
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
            if (CurrentTetrimino != null)
            {
                bool canMove = true;
                IEnumerable<Points> allBlocksExceptCurrent =
                    from tet in GameBoard
                    from pt in tet.Blocks
                    where tet != CurrentTetrimino
                    select pt;

                foreach (Points p in CurrentTetrimino.Blocks.ToList())
                {
                    foreach (Points p2 in allBlocksExceptCurrent.ToList())
                    {
                        if (p.Y == p2.Y && p.X == p2.X + 1)
                        {
                            canMove = false;
                        }
                    }

                    if (p.X <= 0)
                    {
                        canMove = false;
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
        }

        public void MoveRight()
        {
            if (CurrentTetrimino != null)
            {
                bool canMove = true;
                IEnumerable<Points> allBlocksExceptCurrent =
                    from tet in GameBoard
                    from pt in tet.Blocks
                    where tet != CurrentTetrimino
                    select pt;

                foreach (Points p in CurrentTetrimino.Blocks.ToList())
                {
                    foreach (Points p2 in allBlocksExceptCurrent.ToList())
                    {
                        if (p.Y == p2.Y && p.X == p2.X - 1)
                        {
                            canMove = false;
                        }
                    }

                    if (p.X >= 9)
                    {
                        canMove = false;
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
        }

        public void StartHardDrop()
        {
            if (CurrentTetrimino != null)
            {
                CurrentTetrimino.Fall();
            }
        }

        //public void StopHardDrop()
        //{
        //    throw new NotImplementedException();
        //}

        public void RotateCurrent()
        {
            //Rotates the current tetrimino
            CurrentTetrimino.Rotate();
        
            /*
             * This doesn't work, commented out for testing purposes.
             * 
             * 
             */
            ////Checks to see if there are any non-current tetriminos that are in the same space as block 1 of the current tetrimino
            //List<Points> block1 = (List<Points>)
            //            from t in GameBoard
            //            from pt in t.Blocks
            //            where (pt.X == CurrentTetrimino.Blocks[0].X) && (pt.Y == CurrentTetrimino.Blocks[0].Y)
            //            select pt;
            ////Checks to see if there are any non-current tetriminos that are in the same space as block 2 of the current tetrimino
            //List<Points> block2 = (List<Points>)
            //            from t in GameBoard
            //            from pt in t.Blocks
            //            where (pt.X == CurrentTetrimino.Blocks[1].X) && (pt.Y == CurrentTetrimino.Blocks[1].Y)
            //            select pt;
            ////Checks to see if there are any non-current tetriminos that are in the same space as block 3 of the current tetrimino
            //List<Points> block3 = (List<Points>)
            //            from t in GameBoard
            //            from pt in t.Blocks
            //            where (pt.X == CurrentTetrimino.Blocks[2].X) && (pt.Y == CurrentTetrimino.Blocks[2].Y)
            //            select pt;
            ////Checks to see if there are any non-current tetriminos that are in the same space as block 4 of the current tetrimino
            //List<Points> block4 = (List<Points>)
            //            from t in GameBoard
            //            from pt in t.Blocks
            //            where (pt.X == CurrentTetrimino.Blocks[3].X) && (pt.Y == CurrentTetrimino.Blocks[3].Y)
            //            select pt;

            ////Rotates the current tetrimino back to its previous position if collision is founds
            //if ((block1.Count == 0) &&
            //    (block2.Count == 0) &&
            //    (block3.Count == 0) &&
            //    (block4.Count == 0))
            //{
            //    CurrentTetrimino.RotateBack();
           
        }
    }
}
