using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Timers;
//using System.Threading;
//using System.Threading.Tasks;
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
        public Game soloGame { get; set; }
        public System.Timers.Timer PaintTimer { get; set; }
        private Rectangle[,] rectangleBoard = new Rectangle[10, 20];

        List<SolidColorBrush> _tetriminoColors = new List<SolidColorBrush>() {
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
        SolidColorBrush _borderBrush = new SolidColorBrush(Colors.Black);

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
                    rectangleBoard[i, j] = r;
                    SPG_playerOne_grid.Children.Add(r);
                    Grid.SetColumn(r, i);
                    Grid.SetRow(r, j);
                }
            }
            PaintTimer = new System.Timers.Timer(100);
            PaintTimer.Elapsed += PaintTimer_Elapsed;
            soloGame = new Game(type);
            SPG_playerOne_score.DataContext = soloGame;
            soloGame.Start();
            PaintTimer.Start();
        }

        public void PaintTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Dispatcher.Invoke((Action)(() => { DisplayTetriminos(); }));
        }

        public GameMode GetGameMode()
        {
            return soloGame.Mode;
        }

        public void PauseGame()
        {
            PaintTimer.Stop();
            soloGame.Stop();
        }

        public void ResumeGame()
        {
            PaintTimer.Start();
            soloGame.Start();
        }

        public Rectangle CreateRectangle()
        {
            Rectangle rect = new Rectangle();
            rect.Fill = (new SolidColorBrush(Colors.AliceBlue));
            return rect;
        }

        public void DisplayTetriminos()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    rectangleBoard[i, j].Fill = _tetriminoColors.ElementAt(7);
                    rectangleBoard[i, j].Stroke = _tetriminoColors.ElementAt(8);
                    rectangleBoard[i, j].StrokeThickness = 0.3;
                }
            }

            foreach (Tetrimino t in soloGame.GameBoard.ToList())
            {
                foreach (Tetris.Models.TetriminoBag.Points p in t.Blocks.ToList())
                {

                    Rectangle currentRectangle = rectangleBoard[p.X, p.Y];

                    if (t.GetType() == typeof(i_Tetrimino))
                    {
                        currentRectangle.Fill = _tetriminoColors.ElementAt(0);
                    }
                    if (t.GetType() == typeof(j_Tetrimino))
                    {
                        currentRectangle.Fill = _tetriminoColors.ElementAt(1);
                    }
                    if (t.GetType() == typeof(l_Tetrimino))
                    {
                        currentRectangle.Fill = _tetriminoColors.ElementAt(2);
                    }
                    if (t.GetType() == typeof(o_Tetrimino))
                    {
                        currentRectangle.Fill = _tetriminoColors.ElementAt(3);
                    }
                    if (t.GetType() == typeof(s_Tetrimino))
                    {
                        currentRectangle.Fill = _tetriminoColors.ElementAt(4);
                    }
                    if (t.GetType() == typeof(t_Tetrimino))
                    {
                        currentRectangle.Fill = _tetriminoColors.ElementAt(5);
                    }
                    if (t.GetType() == typeof(z_Tetrimino))
                    {
                        currentRectangle.Fill = _tetriminoColors.ElementAt(6);
                    }
                    currentRectangle.Stroke = _borderBrush;
                    currentRectangle.StrokeThickness = 2.5;                    
                }
            }
        }
    }
}