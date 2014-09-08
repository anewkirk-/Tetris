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
        private Rectangle[,] _nextBoard = new Rectangle[7, 2];
        private Random _gen = new Random();
        private Sound _soundManager = new Sound();

        private List<SolidColorBrush> _tetriminoColors = new List<SolidColorBrush>() {
            new SolidColorBrush(Colors.Cyan),
            new SolidColorBrush(Colors.Blue),
            new SolidColorBrush(Colors.Orange),
            new SolidColorBrush(Colors.Yellow),
            new SolidColorBrush(Colors.Lime),
            new SolidColorBrush(Colors.DarkMagenta),
            new SolidColorBrush(Colors.Red),
            Application.Current.FindResource("Brush_GridBackground") as SolidColorBrush,
            new SolidColorBrush(Colors.Black)
    };
        private SolidColorBrush _borderBrush = Application.Current.FindResource("Brush_GridBorders") as SolidColorBrush;
        private SolidColorBrush _nxtBorderBrush = new SolidColorBrush(Color.FromArgb(144, 0, 0, 0));

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

            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    Rectangle r = new Rectangle();
                    _nextBoard[i, j] = r;
                    NextTetriminoGrid.Children.Add(r);
                    Grid.SetColumn(r, i);
                    Grid.SetRow(r, j);
                }
            }
            ClearRectangleBoard();
            PaintTimer = new System.Timers.Timer(100);
            PaintTimer.Elapsed += PaintTimer_Elapsed;
            SoloGame = new Game(type);
            _soundManager.PlayGameStartSFX();
            SoloGame.Start();
            PaintTimer.Start();
            SoloGame.MakeTetriminoBag();
        }

        public void PaintTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            try
            {
                Dispatcher.Invoke((Action)(() => { UpdateUI(); }));
            }
            catch
            {
                //Task cancelled, nothing to do here
            }
        }

        public GameMode GetGameMode()
        {
            return SoloGame.Mode;
        }

        public void PauseGame()
        {

            if (PaintTimer != null && SoloGame != null)
            {
                PaintTimer.Stop();
                SoloGame.Stop();
            }
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

            ClearRectangleBoard();

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
                UpdateNextTetrimino();
            }

            //Highlight current tetrimino hard drop
            if (SoloGame.CurrentTetrimino != null)
            {
                List<Points> highlight = new List<Points>(SoloGame.CurrentTetrimino.Blocks);
                int d = SoloGame.FindDistanceCurrentCanFall();
                foreach (Points p in highlight)
                {
                    int newY = p.Y + d;
                    if (newY >= 0 && newY <= 19)
                    {
                        Rectangle currentRectangle = _rectangleBoard[p.X, p.Y + d];
                        currentRectangle.StrokeThickness = 1.8;
                    }
                }
            }
        }

        public void UpdateNextTetrimino()
        {
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    if (i >= 3)
                    {
                        Rectangle rct = _nextBoard[i, j];
                        rct.Fill = Application.Current.FindResource("Brush_GridBackground") as SolidColorBrush;
                        rct.StrokeThickness = 0;
                    }
                }
            }

            foreach (Tetris.Models.TetriminoBag.Points p in SoloGame.NextTetrimino.Blocks.ToList())
            {
                Rectangle nxtRectangle = _nextBoard[p.X, p.Y];
                if (SoloGame.NextTetrimino.GetType() == typeof(i_Tetrimino))
                {
                    nxtRectangle.Fill = _tetriminoColors.ElementAt(0);
                }
                else if (SoloGame.NextTetrimino.GetType() == typeof(j_Tetrimino))
                {
                    nxtRectangle.Fill = _tetriminoColors.ElementAt(1);
                }
                else if (SoloGame.NextTetrimino.GetType() == typeof(l_Tetrimino))
                {
                    nxtRectangle.Fill = _tetriminoColors.ElementAt(2);
                }
                else if (SoloGame.NextTetrimino.GetType() == typeof(o_Tetrimino))
                {
                    nxtRectangle.Fill = _tetriminoColors.ElementAt(3);
                }
                else if (SoloGame.NextTetrimino.GetType() == typeof(s_Tetrimino))
                {
                    nxtRectangle.Fill = _tetriminoColors.ElementAt(4);
                }
                else if (SoloGame.NextTetrimino.GetType() == typeof(t_Tetrimino))
                {
                    nxtRectangle.Fill = _tetriminoColors.ElementAt(5);
                }
                else if (SoloGame.NextTetrimino.GetType() == typeof(z_Tetrimino))
                {
                    nxtRectangle.Fill = _tetriminoColors.ElementAt(6);
                }
                else
                {
                    nxtRectangle.Fill = _tetriminoColors.ElementAt(_gen.Next(0, 7));
                }
                nxtRectangle.Stroke = _borderBrush;
                nxtRectangle.StrokeThickness = 1;
            }
        }

        private void ClearRectangleBoard()
        {
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
        }
    }
}