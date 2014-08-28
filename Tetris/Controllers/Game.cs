using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Tetris.Models;
using Tetris.Models.TetriminoBag;
using Tetris.Views.GameScreens;
using System.Windows.Threading;

namespace Tetris.Controllers
{

    public delegate void GameEndHandler();
    public delegate void TetrisHandler();

    public class Game
    {
        public event TetrisHandler ScoredTetris;
        public event GameEndHandler GameEnd;
        public int CurrentScore { get; set; }
        public GameMode Mode { get; set; }
        public TetrisBoard GameBoard { get; set; }
        public Timer GameTimer { get; set; }
        public Tetrimino CurrentTetrimino { get; set; }
        public int LinesCleared { get; set; }
        public int TimeElapsed { get; set; }
        public int _timedModeTimeLimit = 120000;
        private Random _rand = new Random(Guid.NewGuid().GetHashCode());
        private int _linesBeforeSpeedUp = 5;
        private int _currentLevel = 1;
        private bool _isToppedOut = false;
        public Tetrimino NextTetrimino { get; set; }

        public Game(GameMode mode = GameMode.Classic)
        {
            //default to a 1 second interval
            GameBoard = new TetrisBoard();
            GameTimer = new Timer();
            GameTimer.Interval = 500;
            GameTimer.Elapsed += Tick;
            this.Mode = mode;
            CurrentScore = 0;
            randomBag = new List<Tetrimino>();
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

            //check for end game conditions
            bool endGame = EndConditionsMet();
            if (endGame)
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
                    }
                }
            }

            //Check for collisions on the current tetrimino
            bool collision = false;
            List<Points> lowestPoints = FindLowestPoints(CurrentTetrimino);

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
                //Add to CurrentScore here!
                //Determine score
                switch (cleared.Count())
                {
                    //Single line cleared
                    case 1:
                        CurrentScore += (_currentLevel * 40) + 40;
                        break;
                    //Two lines cleared
                    case 2:
                        CurrentScore += (_currentLevel * 100) + 100;
                        break;
                    //Three lines cleared
                    case 3:
                        CurrentScore += (_currentLevel * 300) + 300;
                        break;
                    //Four lines cleared ("Tetris")
                    case 4:
                        CurrentScore += (_currentLevel * 1200) + 1200;
                        FireScoredTetris();
                        break;
                }
                //Clear lines
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
                //if no collision, let the current tetrimino keep falling
                CurrentTetrimino.Fall();
            }
        }

        public void FireScoredTetris()
        {
            if (ScoredTetris != null)
            {
                ScoredTetris();
            }
        }

        private List<Points> FindLowestPoints(Tetrimino t)
        {
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
            return lowestPoints;
        }

        public int FindDistanceCurrentCanFall()
        {
            List<Points> lowestPoints = FindLowestPoints(CurrentTetrimino);
            int lowest = lowestPoints.OrderByDescending(a => a.Y).First().Y;
            int distance = 19 - lowest;
            IEnumerable<Points> blocksBelow;
            //This needs to be in a try/catch block
            foreach (Points p in lowestPoints)
            {
                blocksBelow = from t in GameBoard
                              from pt in t.Blocks
                              where pt.X == p.X
                              where pt.Y > p.Y
                              where t != CurrentTetrimino
                              select pt;
                if (blocksBelow.Count() > 0)
                {
                    Points highest = blocksBelow.OrderBy(a => a.Y).First();
                    if (highest.Y - p.Y - 1 < distance)
                    {
                        distance = highest.Y - p.Y - 1;
                    }
                }
            }
            return distance;
        }

        //returns a list of Y coordinates of full rows
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

        //moves all tetriminos down that are above the given rows
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

        //checks if any end-game conditions are met
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
                default:
                    break;
            }
            if (_isToppedOut)
                endGame = true;
            return endGame;
        }

        //determines if a given block can move down by one cell
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
        }

        //Bag of Tetriminos that holds the preset random order of 
        //the Tetriminos that are to be spawned in that order
        public List<Tetrimino> randomBag { get; set; }

        //Populates the randomBag with the randomly ordered Tetriminos
        public void MakeTetriminoBag()
        {
            //Temorary bag of Tetriminos that will be pulled from so
            //that no duplicates will be added to the bag
            List<Tetrimino> Bag = new List<Tetrimino>
                {
                    new i_Tetrimino(),
                    new j_Tetrimino(),
                    new l_Tetrimino(),
                    new o_Tetrimino(),
                    new s_Tetrimino(),
                    new t_Tetrimino(),
                    new z_Tetrimino()
                };

            //Loop that populates the bag
            int i = 0;
            while (i < 7)
            {
                //Randomly grabs an index from Bag 
                int index = _rand.Next(0, Bag.Count);
                //Temp tetrimino that is set to the random index from the Bag
                Tetrimino tracker = Bag[index];
                //Removes the tetrimino at the index so that is will not be used again
                Bag.RemoveAt(index);

                //Checks what kind of tetrimino the random tetrimino is and adds the
                //that kind of tetrimino to the randomBag
                switch (tracker.Name)
                {
                    case "i_Tetrimino":
                        randomBag.Add(new i_Tetrimino());
                        break;
                    case "j_Tetrimino":
                        randomBag.Add(new j_Tetrimino());
                        break;
                    case "l_Tetrimino":
                        randomBag.Add(new l_Tetrimino());
                        break;
                    case "o_Tetrimino":
                        randomBag.Add(new o_Tetrimino());
                        break;
                    case "s_Tetrimino":
                        randomBag.Add(new s_Tetrimino());
                        break;
                    case "t_Tetrimino":
                        randomBag.Add(new t_Tetrimino());
                        break;
                    case "z_Tetrimino":
                        randomBag.Add(new z_Tetrimino());
                        break;
                }
                i++;
            }
            //Sets NextTetrimino to the first tetrimino in the randomBag
            NextTetrimino = randomBag[0];
        }

        public void AddRandomTetrimino()
        {
            //Sets randT to the NextTetrimino
            Tetrimino randT = NextTetrimino;
            //Removes the first tetrimino in the bag
            randomBag.RemoveAt(0);

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
                                GameBoard.Remove(CurrentTetrimino);
                            }
                        }
                    }
                }
            }

            //Check to see if the randomBag is empty
            //If it is not, set Nexttetrimino to the first tetrimino in the randomBag
            //If it is then it makes a new randomBag
            if (randomBag.Count != 0)
                NextTetrimino = randomBag[0];
            else
                MakeTetriminoBag();
        }
            
     
        //Create a row of points leaving one space
        public Tetrimino RowOfBlocksMinusOne()
        {
            Tetrimino t = new Tetrimino();
            int randomY = _rand.Next(0, 10);
            
            for (int i = 0; i <= 9; i++)
            {
                if (i != randomY)
                {
                    Points p = new Points();
                    p.Y = 19;
                    p.X = i;
                    t.Blocks.Add(p);
                }
            }
            return t;
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
            Tetrimino newRow = RowOfBlocksMinusOne();
            GameBoard.Add(newRow);
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

        public void HardDrop()
        {
            if (CurrentTetrimino != null)
            {
                int d = FindDistanceCurrentCanFall();
                foreach (Points p in CurrentTetrimino.Blocks)
                {
                    p.Y += d;
                }
            }
        }

        public void RotateCurrent()
        {
            if (CurrentTetrimino != null)
            {
                //Rotates the current tetrimino
                CurrentTetrimino.Rotate();
                //Checks to see if there are any non-current tetriminos that are in the same space as block 1 of the current tetrimino
                IEnumerable<Points> block1 =
                        from tet in GameBoard
                        from pt in tet.Blocks
                        where pt.X.Equals(CurrentTetrimino.Blocks[0].X) && pt.Y.Equals(CurrentTetrimino.Blocks[0].Y)
                        select pt;
                //Checks to see if there are any non-current tetriminos that are in the same space as block 2 of the current tetrimino
                IEnumerable<Points> block2 =
                            from t in GameBoard
                            from pt in t.Blocks
                            where (pt.X == CurrentTetrimino.Blocks[1].X) && (pt.Y == CurrentTetrimino.Blocks[1].Y)
                            select pt;
                //Checks to see if there are any non-current tetriminos that are in the same space as block 3 of the current tetrimino
                IEnumerable<Points> block3 =
                            from t in GameBoard
                            from pt in t.Blocks
                            where (pt.X == CurrentTetrimino.Blocks[2].X) && (pt.Y == CurrentTetrimino.Blocks[2].Y)
                            select pt;
                //Checks to see if there are any non-current tetriminos that are in the same space as block 4 of the current tetrimino
                IEnumerable<Points> block4 =
                            from t in GameBoard
                            from pt in t.Blocks
                            where (pt.X == CurrentTetrimino.Blocks[3].X) && (pt.Y == CurrentTetrimino.Blocks[3].Y)
                            select pt;

                for (int i = 0; i < 4; i++)
                {
                    if ((CurrentTetrimino.Blocks[i].Y < 0) || (CurrentTetrimino.Blocks[i].Y > 19))
                    {
                        CurrentTetrimino.RotateBack();
                        break;
                    }
                    if ((CurrentTetrimino.Blocks[i].X < 0) || (CurrentTetrimino.Blocks[i].X > 9))
                    {
                        CurrentTetrimino.RotateBack();
                        break;
                    }
                }

                //Rotates the current tetrimino back to its previous position if collision is found
                if ((block1.Count() != 1) ||
                    (block2.Count() != 1) ||
                    (block3.Count() != 1) ||
                    (block4.Count() != 1))
                {
                    CurrentTetrimino.RotateBack();
                }
            }
           
        }

        public void MoveCurrentDown()
        {
            if(FindDistanceCurrentCanFall() > 0)
            {
                CurrentTetrimino.Fall();
            }
        }

        public void QuitGame()
        {
            GameEnd();
        }
    }
}
