using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
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
    /// Interaction logic for SinglePlayerGame.xaml
    /// </summary>
    public partial class SinglePlayerGame : UserControl
    {
        public Game SoloGame { get; set; }
        public System.Timers.Timer PaintTimer { get; set; }
        public bool _rainbowMode = false;
        private Rectangle[,] _rectangleBoard = new Rectangle[10, 20];
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
        private SolidColorBrush _borderBrush = new SolidColorBrush(Colors.Black);

        public SinglePlayerGame()
        {
            InitializeComponent();
        }

        public void NewGame(GameMode type)
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    Rectangle r = new Rectangle();
                    _rectangleBoard[i, j] = r;
                    SPG_playerOne_grid.Children.Add(r);
                    Grid.SetColumn(r, i);
                    Grid.SetRow(r, j);
                }
            }
            PaintTimer = new System.Timers.Timer(100);
            PaintTimer.Elapsed += PaintTimer_Elapsed;
            SoloGame = new Game(type);
            SoloGame.Start();
            PaintTimer.Start();
        }

        public void PaintTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Dispatcher.Invoke((Action)(() => { UpdateUI(); }));
        }

        public GameMode GetGameMode()
        {
            return SoloGame.Mode;
        }

        public void PauseGame()
        {
            PaintTimer.Stop();
            SoloGame.Stop();
        }

        public void ResumeGame()
        {
            PaintTimer.Start();
            SoloGame.Start();
        }

        public void UpdateUI()
        {
            //Display user's current score
            SPG_playerOne_score.Content = SoloGame.CurrentScore.ToString();

            //Display lines cleared
            LinesClearedLabel.Content = SoloGame.LinesCleared.ToString();

            //Display timer
            TimeSpan time;
            switch (SoloGame.Mode)
            {
                case GameMode.Timed:
                    time = TimeSpan.FromMilliseconds(SoloGame._timedModeTimeLimit - SoloGame.TimeElapsed);
                    break;
                default:
                    time = TimeSpan.FromMilliseconds(SoloGame.TimeElapsed);
                    break;
            }
            string mins = time.Minutes > 9 ? time.Minutes.ToString() : "0" + time.Minutes.ToString();
            string secs = time.Seconds > 9 ? time.Seconds.ToString() : "0" + time.Seconds.ToString();
            TimerLabel.Content = string.Concat(mins, ":" + secs);

            //Set all rectangles to a white fill and thin border
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    _rectangleBoard[i, j].Fill = _tetriminoColors.ElementAt(7);
                    _rectangleBoard[i, j].Stroke = _tetriminoColors.ElementAt(8);
                    _rectangleBoard[i, j].StrokeThickness = 0.3;
                }
            }

            //Color in rectangles according to game state
            foreach (Tetrimino t in SoloGame.GameBoard.ToList())
            {
                foreach (Tetris.Models.TetriminoBag.Points p in t.Blocks.ToList())
                {

                    Rectangle currentRectangle = _rectangleBoard[p.X, p.Y];
                    if (_rainbowMode)
                    {
                        currentRectangle.Fill = _tetriminoColors.ElementAt(_gen.Next(0, 7));
                    }
                    else
                    {
                        if (t.GetType() == typeof(i_Tetrimino))
                        {
                            currentRectangle.Fill = _tetriminoColors.ElementAt(0);
                        }
                        else if (t.GetType() == typeof(j_Tetrimino))
                        {
                            currentRectangle.Fill = _tetriminoColors.ElementAt(1);
                        }
                        else if (t.GetType() == typeof(l_Tetrimino))
                        {
                            currentRectangle.Fill = _tetriminoColors.ElementAt(2);
                        }
                        else if (t.GetType() == typeof(o_Tetrimino))
                        {
                            currentRectangle.Fill = _tetriminoColors.ElementAt(3);
                        }
                        else if (t.GetType() == typeof(s_Tetrimino))
                        {
                            currentRectangle.Fill = _tetriminoColors.ElementAt(4);
                        }
                        else if (t.GetType() == typeof(t_Tetrimino))
                        {
                            currentRectangle.Fill = _tetriminoColors.ElementAt(5);
                        }
                        else if (t.GetType() == typeof(z_Tetrimino))
                        {
                            currentRectangle.Fill = _tetriminoColors.ElementAt(6);
                        }
                        else
                        {
                            currentRectangle.Fill = _tetriminoColors.ElementAt(_gen.Next(0, 7));
                        }
                    }
                    currentRectangle.Stroke = _borderBrush;
                    currentRectangle.StrokeThickness = 2.5;                    
                }
            }

            //Highlight current tetrimino hard drop
            if (SoloGame.CurrentTetrimino != null)
            {
                List<Points> highlight = new List<Points>(SoloGame.CurrentTetrimino.Blocks);
                int d = SoloGame.FindDistanceCurrentCanFall();
                foreach (Points p in highlight)
                {
                    Rectangle currentRectangle = _rectangleBoard[p.X, p.Y + d];
                    currentRectangle.StrokeThickness = 2.5;
                }
            }
        }
    }
}