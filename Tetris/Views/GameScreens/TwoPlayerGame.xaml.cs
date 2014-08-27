using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Tetris.Controllers;
using Tetris.Models.TetriminoBag;

namespace Tetris.Views.GameScreens
{
    /// <summary>
    /// Interaction logic for TwoPlayerGame.xaml
    /// </summary>
    public partial class TwoPlayerGame : UserControl
    {
        public Game PlayerOneGame { get; set; }
        public Game PlayerTwoGame { get; set; }
        public System.Timers.Timer PaintTimer { get; set; }
        private Rectangle[,] _playerOneRectangles = new Rectangle[10, 20];
        private Rectangle[,] _playerTwoRectangles = new Rectangle[10, 20];
        private SolidColorBrush _borderBrush = new SolidColorBrush(Colors.Black);
        private Random _gen = new Random();

        private List<SolidColorBrush> _tetriminoColors = new List<SolidColorBrush>() {
            new SolidColorBrush(Colors.Cyan),
            new SolidColorBrush(Colors.Blue),
            new SolidColorBrush(Colors.Orange),
            new SolidColorBrush(Colors.Yellow),
            new SolidColorBrush(Colors.Lime),
            new SolidColorBrush(Colors.DarkMagenta),
            new SolidColorBrush(Colors.Red),
            new SolidColorBrush(Colors.White),
            new SolidColorBrush(Colors.Black)
    };

        public TwoPlayerGame()
        {
            InitializeComponent();
        }

        public void NewGame(GameMode type)
        {
            PlayerOneGame = new Game(type);
            PlayerTwoGame = new Game(type);
            PlayerOneGame.ScoredTetris += PlayerOneTetris;
            PlayerTwoGame.ScoredTetris += PlayerTwoTetris;
            SetUpGameBoards();
            PaintTimer = new System.Timers.Timer(100);
            PaintTimer.Elapsed += PaintTimer_Elapsed;
            PlayerOneGame.MakeTetriminoBag();
            PlayerTwoGame.MakeTetriminoBag();
            PlayerOneGame.Start();
            PlayerTwoGame.Start();
            PaintTimer.Start();
        }

        public GameMode GetGameMode()
        {
            return PlayerOneGame.Mode;
        }

        public void PauseGame()
        {
            PlayerOneGame.Stop();
            PlayerTwoGame.Stop();
        }

        public void ResumeGame()
        {
            PlayerOneGame.Start();
            PlayerTwoGame.Start();
        }

        private void SetUpGameBoards()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    Rectangle r = new Rectangle();
                    _playerOneRectangles[i, j] = r;
                    TPG_playerOne_grid.Children.Add(r);
                    Grid.SetColumn(r, i);
                    Grid.SetRow(r, j);

                    Rectangle r2 = new Rectangle();
                    _playerTwoRectangles[i, j] = r2;
                    TPG_playerTwo_grid.Children.Add(r2);
                    Grid.SetColumn(r2, i);
                    Grid.SetRow(r2, j);
                }
            }
        }

        public void PaintTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            try
            {
                Dispatcher.Invoke((Action)(() => { UpdateUI(); }));
            }
            catch 
            {
                //Task was cancelled, nothing to do here. Probably.
            }
        }

        private void PlayerOneTetris()
        {
            PlayerTwoGame.AddRowSansOne();
        }

        private void PlayerTwoTetris()
        {
            PlayerOneGame.AddRowSansOne();
        }

        private void UpdateUI()
        {
            //Display current scores
            TPG_playerOne_score.Content = PlayerOneGame.CurrentScore.ToString();
            TPG_playerTwo_score.Content = PlayerTwoGame.CurrentScore.ToString();

            //Display lines cleared
            p1_LinesClearedLabel.Content = PlayerOneGame.LinesCleared.ToString();
            p2_LinesClearedLabel.Content = PlayerTwoGame.LinesCleared.ToString();

            //Display timer
            //Display timer
            TimeSpan time;
            switch (PlayerOneGame.Mode)
            {
                case GameMode.Timed:
                    time = TimeSpan.FromMilliseconds(PlayerOneGame._timedModeTimeLimit - PlayerOneGame.TimeElapsed);
                    break;
                default:
                    time = TimeSpan.FromMilliseconds(PlayerOneGame.TimeElapsed);
                    break;
            }
            string mins = time.Minutes > 9 ? time.Minutes.ToString() : "0" + time.Minutes.ToString();
            string secs = time.Seconds > 9 ? time.Seconds.ToString() : "0" + time.Seconds.ToString();
            TimerLabel.Content = string.Concat(mins, ":" + secs);


            //Empty grids
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    //Player 1
                    _playerOneRectangles[i, j].Fill = _tetriminoColors.ElementAt(7);
                    _playerOneRectangles[i, j].Stroke = _tetriminoColors.ElementAt(8);
                    _playerOneRectangles[i, j].StrokeThickness = 0.3;

                    //Player 2
                    _playerTwoRectangles[i, j].Fill = _tetriminoColors.ElementAt(7);
                    _playerTwoRectangles[i, j].Stroke = _tetriminoColors.ElementAt(8);
                    _playerTwoRectangles[i, j].StrokeThickness = 0.3;
                }
            }

            //Color in blocks
            //Player 1
            foreach (Tetrimino t in PlayerOneGame.GameBoard.ToList())
            {
                foreach (Points p in t.Blocks.ToList())
                {
                    Rectangle currentRectangle = _playerOneRectangles[p.X, p.Y];
                    ColorBlock(t, currentRectangle);
                }
            }

            //Player 2
            foreach (Tetrimino t in PlayerTwoGame.GameBoard.ToList())
            {
                foreach (Points p in t.Blocks.ToList())
                {
                    Rectangle currentRectangle = _playerTwoRectangles[p.X, p.Y];
                    ColorBlock(t, currentRectangle);
                }
            }

            //Highlight hard drop locations
            //player 1
            if (PlayerOneGame.CurrentTetrimino != null)
            {
                List<Points> highlight = new List<Points>(PlayerOneGame.CurrentTetrimino.Blocks);
                int d = PlayerOneGame.FindDistanceCurrentCanFall();
                foreach (Points p in highlight)
                {
                    Rectangle currentRectangle = _playerOneRectangles[p.X, p.Y + d];
                    currentRectangle.StrokeThickness = 2.5;
                }
            }

            //player 2
            if (PlayerTwoGame.CurrentTetrimino != null)
            {
                List<Points> highlight = new List<Points>(PlayerTwoGame.CurrentTetrimino.Blocks);
                int d = PlayerTwoGame.FindDistanceCurrentCanFall();
                foreach (Points p in highlight)
                {
                    Rectangle currentRectangle = _playerTwoRectangles[p.X, p.Y + d];
                    currentRectangle.StrokeThickness = 2.5;
                }
            }
        }

        private void ColorBlock(Tetrimino t, Rectangle r)
        {
            if (t.GetType() == typeof(i_Tetrimino))
            {
                r.Fill = _tetriminoColors.ElementAt(0);
            }
            else if (t.GetType() == typeof(j_Tetrimino))
            {
                r.Fill = _tetriminoColors.ElementAt(1);
            }
            else if (t.GetType() == typeof(l_Tetrimino))
            {
                r.Fill = _tetriminoColors.ElementAt(2);
            }
            else if (t.GetType() == typeof(o_Tetrimino))
            {
                r.Fill = _tetriminoColors.ElementAt(3);
            }
            else if (t.GetType() == typeof(s_Tetrimino))
            {
                r.Fill = _tetriminoColors.ElementAt(4);
            }
            else if (t.GetType() == typeof(t_Tetrimino))
            {
                r.Fill = _tetriminoColors.ElementAt(5);
            }
            else if (t.GetType() == typeof(z_Tetrimino))
            {
                r.Fill = _tetriminoColors.ElementAt(6);
            }
            else
            {
                r.Fill = _tetriminoColors.ElementAt(_gen.Next(0, 7));
            }
            r.Stroke = _borderBrush;
            r.StrokeThickness = 1.8; 
        }
    }
}